import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { IViaje } from '../../models/viaje.model';
import { TravelBookerServiceService } from '../../services/travel-booker-service.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-viaje',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './viaje.component.html',
  styleUrl: './viaje.component.css'
})
export class ViajeComponent implements OnInit {

  private _router = inject(Router);

  viaje: IViaje | undefined;

  constructor(private route: ActivatedRoute) { }

  
  private _travelBookerService = inject(TravelBookerServiceService);
  viajes: IViaje[] = []; 
  localidadOrigen: string ="";
  localidadDestino: string ="";
  fechaSalida: string ="";
  horaSalida: string ="";
  viajesFiltrados: IViaje[] =[];


  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.fechaSalida =params['fecha'];
      this._travelBookerService.getLocalidadByName(params['origen']).subscribe(
        (resp: any) => {
          this.localidadOrigen=resp.data.nombreLocalidad;
        });
      this._travelBookerService.getLocalidadByName(params['destino']).subscribe(
        (resp: any) => {
          this.localidadDestino=resp.data.nombreLocalidad;
        });
      this._travelBookerService.getViajesByLocalidades(params['origen'], params['destino']).subscribe(
        (res: any) => {
          this.viajes = res.data; //array de viajes
          this.viajes.forEach(element => { //element es cada viaje
            this.corroborarColectivoDisponible(element.id).subscribe({
              next: (lleno) => {
                if (!lleno) {
                  if (element.fechaYHora.split('T')[0] == this.fechaSalida) {
                    this.viajesFiltrados?.push(element);
                  }
                }
              },
              error: (error) => {
                console.log("Hubo un error al verificar si el viaje está lleno:", error);
              }
            });
          });
        });
    });
  }

  determinarHora(element:IViaje): string{
    var horaSalida: string = "";
    const fechaYHoraArray = element.fechaYHora.split('T');
    const fechaYHora = new Date(Date.parse(`${fechaYHoraArray[0]} ${fechaYHoraArray[1]}`));
    const newDate = new Date(fechaYHora.getTime() + (24 * 60 * 60 * 1000));
    horaSalida = `${newDate.getFullYear()}-${String(newDate.getMonth() + 1).padStart(2, '0')}-${String(newDate.getDate() + 1).padStart(2, '0')}T${newDate.getHours().toString().padStart(2, '0')}:${newDate.getMinutes().toString().padStart(2, '0')}:${newDate.getSeconds().toString().padStart(2, '0')}`;
    return horaSalida;
  }

  corroborarColectivoDisponible(idViaje: number): Observable<boolean> {
    return new Observable<boolean>((observer) => {
      this._travelBookerService.getViajeById(idViaje).subscribe({
        next: (respuesta: any) => {
          if (respuesta && respuesta.data && respuesta.data.idColectivo) {
            let butacasReservadas = respuesta.data.butacasReservadas.length;
            if (butacasReservadas == 30) {
              observer.next(true);
            } else {
              observer.next(false);
            }
          }
        },
        error: (error) => {
          observer.error(error);
        },
        complete: () => {
          observer.complete();
        }
      });
    });
  }


  reservar(id:number,idColectivo:number,precio:number){
    this._travelBookerService.origen.update(x=>this.localidadOrigen);
    this._travelBookerService.destino.update(x=>this.localidadDestino);
    this._travelBookerService.fechaSalida.update(x=>this.fechaSalida);
    this._travelBookerService.idViaje.update(x=>id);
    this._travelBookerService.idColectivo.update(x=>idColectivo);
    this._travelBookerService.precio.update(x=>precio);
    this._router.navigate(['/reserva']);
  } 
  
}

