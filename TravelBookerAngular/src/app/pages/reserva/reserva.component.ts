import { CommonModule, DatePipe } from '@angular/common';
import { Component, OnInit, Renderer2, inject } from '@angular/core';
import { TravelBookerServiceService } from '../../services/travel-booker-service.service';
import { ILocalidad } from '../../models/localidad.model';
import { IReserva } from '../../models/reserva.model';
import { IViaje } from '../../models/viaje.model';
import { Router } from '@angular/router';
import { RouterOutlet } from '@angular/router';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-reserva',
  standalone: true,
  imports: [CommonModule,RouterOutlet],
  templateUrl: './reserva.component.html',
  styleUrl: './reserva.component.css'
})
export class ReservaComponent implements OnInit{

  private _router = inject(Router);
  private _travelBookerService = inject(TravelBookerServiceService);
  viaje = inject(TravelBookerServiceService);
  butacasReservadas: number[]= [0];
  butacaSeleccionada: number = 0;
  horaSalida: string = "";
  precioButaca: number = 0;
  determinarHoraSalida(){
    this._travelBookerService.getViajeById(this._travelBookerService.idViaje()).subscribe({
      next: (respuesta: any) => {
        if (respuesta && respuesta.data && respuesta.data.fechaYHora) {
          const fechaYHoraArray = respuesta.data.fechaYHora.split('T');
          const fechaYHora = new Date(Date.parse(`${fechaYHoraArray[0]} ${fechaYHoraArray[1]}`));
          const newDate = new Date(fechaYHora.getTime() + (24 * 60 * 60 * 1000));
          this.horaSalida = `${newDate.getFullYear()}-${String(newDate.getMonth() + 1).padStart(2, '0')}-${String(newDate.getDate() + 1).padStart(2, '0')}T${newDate.getHours().toString().padStart(2, '0')}:${newDate.getMinutes().toString().padStart(2, '0')}:${newDate.getSeconds().toString().padStart(2, '0')}`;
        } else {
          console.log("No se encontró el viaje con el ID proporcionado");
        }
      },
      error: (error) => {
        console.log("Hubo un error al obtener el viaje:", error);
      }
    });
  }

  nuevaReserva: IReserva = {
    id:0,
    nombreUsuario: "",
    apellidoUsuario: "",
    dniUsuario: "",
    mayorDeEdad: true,
    idButaca: 0,
    idViaje: 0,
    precioTotal:0,
  }
  ngOnInit(): void {
    this.cargarButacasReservadas()
    this.determinarHoraSalida();
    this.determinarPrecioReserva();
  }
  cargarButacasReservadas() {
    this._travelBookerService.getButacasReservadas(this._travelBookerService.idViaje()).subscribe({
      next: (respuesta: number[]) => {
        if (Array.isArray(respuesta)) {
          this.butacasReservadas = respuesta;
        }
      },
      error: (error) => {
        console.log("Hubo un error cargando las butacas reservadas:", error)
      }
    });
  }

  determinarPrecioButaca(){
    this._travelBookerService.getButacaById(this.butacaSeleccionada).subscribe({
      next: (respuesta: any) => {
        const categoriaButaca = respuesta.data.idCategoria;
        this._travelBookerService.getCategoriaById(categoriaButaca).subscribe({
          next: (respuesta: any) => {
            this.viaje.precioButaca.update(x=>respuesta.data.precio);
            this.determinarPrecioReserva();
          }
        })
        
      }
    })
  }
  determinarPrecioReserva(){
    const precioReserva = this._travelBookerService.precio()+this.viaje.precioButaca();
    this.viaje.precioReserva.update(x=>precioReserva);
  }
  
  seleccionarButaca(numeroButaca: number) {
    if(!this.butacasReservadas.includes(numeroButaca)){
      this.butacaSeleccionada = numeroButaca;
      this.determinarPrecioButaca();   
    }
  }
  
  volverAlHome(){
    this._router.navigate(['/home']);
  }
  reservarButaca() {
    this._travelBookerService.guardarButaca(this._travelBookerService.idViaje(), this.butacaSeleccionada).subscribe({});
    Swal.fire({
      title: 'Reserva realizada con éxito!',
      text: 'Recordá asistir a la hora de salida con tu DNI para efectivizar el pago.',
      icon: 'success',
      confirmButtonText: 'OK'
    })
    // alert("Reserva realizada con exito! Recordá asistir a la hora de salida con tu DNI para efectivizar el pago.");
    
  }
  reservar(nombreUsuario: string, apellidoUsuario: string, dniUsuario: string, mayorDeEdad: boolean): void {
    this.nuevaReserva= {
      id:0,
      nombreUsuario: nombreUsuario,
      apellidoUsuario: apellidoUsuario,
      dniUsuario: dniUsuario,
      mayorDeEdad: mayorDeEdad,
      idButaca: this.butacaSeleccionada,
      idViaje: this._travelBookerService.idViaje(),
      precioTotal:this._travelBookerService.precioReserva(),
    }
    this.nuevaReserva.idButaca = this.butacaSeleccionada; 
    if(this.nuevaReserva.idButaca!=0 && this.nuevaReserva.idViaje!=0){
      this._travelBookerService.agregarReserva(this.nuevaReserva).subscribe(
        (respuesta: any) => {
            this.reservarButaca();          
          // console.log("Datos enviados de la reserva: ", respuesta);
          //alert("Reserva realizada con exito");
        },
        (error) => {
          // alert("Ha ocurrido un error al realizar la reserva");
          console.log("Error: ", error)
        }
      );
    }
    else{
      if(this.nuevaReserva.idButaca==0){
        Swal.fire({
          title: 'Error!',
          text: 'Debe seleccionar una butaca para continuar',
          icon: 'error',
          confirmButtonText: 'OK'
        })
        // alert("Debe seleccionar una butaca");
      }
      if(this.nuevaReserva.idViaje==0){
        
        Swal.fire({
          title: 'Error!',
          text: 'Debe seleccionar un viaje para continuar',
          icon: 'error',
          confirmButtonText: 'OK'
        })
        // alert("Debe seleccionar un viaje");
        this.volverAlHome();
      }
      
    }
    
    this.volverAlHome();
  }
  
}
