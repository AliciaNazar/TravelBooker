import { CommonModule, DatePipe } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { TravelBookerServiceService } from '../../services/travel-booker-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ILocalidad } from '../../models/localidad.model';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { debounceTime, distinctUntilChanged, map } from 'rxjs/operators'; //prueba formulario
import { Observable } from 'rxjs';
import { startWith} from 'rxjs/operators';
import {AsyncPipe} from '@angular/common';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule,FormsModule,ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatAutocompleteModule,
    AsyncPipe,],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{

  myControl = new FormControl();

  // fechaSeleccionada: Date | undefined;





  
  private _travelBookerService = inject(TravelBookerServiceService);
  private _route = inject(ActivatedRoute);
  private _router = inject(Router);

  public localidad?: ILocalidad;

  localidadess: ILocalidad[] = [];
  localidadSeleccionada: ILocalidad | undefined;
  nuevoNombre: string = '';
  localidades: ILocalidad | undefined;

  ciudades: string[] =[];
  userInput: string = '';

  


  
  ngOnInit(): void {
    


    this._travelBookerService.getLocalidades().subscribe(
      (res: any) => {
        if (res?.data instanceof Array) {
          this.localidadess = res.data;
          this.localidadess.forEach(element => {
            this.ciudades?.push(element.nombreLocalidad)
          });
        } else {
          console.error('Error: No se pudo cargar la lista de localidades.');
        }
      },
      (error: any) => {
        console.error(error);
      }
    );
  }


  obtenerFecha():string{
    const today = new Date();
    const year = today.getFullYear();
    let month: string | number = today.getMonth() + 1;
    let day: string | number = today.getDate();
    if (month < 10) {
      month = '0' + month;
    }
    if (day < 10) {
      day = '0' + day;
    }
    return `${year}-${month}-${day}`;
  }

  buscarViaje(origen: string, destino: string, fecha: string) {
    this.buscarCiudad(origen);
    this.buscarCiudad(destino);
    this._router.navigate(['/viaje'], { 
      queryParams: { 
        origen: origen,
        destino: destino,
        fecha: fecha
      } 
    });
  }

  buscarCiudad(ciudad: string) {
    this._travelBookerService.getLocalidadByName(ciudad).subscribe(
      (res: ILocalidad) => {
        this.localidades = res;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  guardarCambios(): void {
    if (!this.localidadSeleccionada || !this.nuevoNombre) {
      console.error('Error: Debes seleccionar una localidad y proporcionar un nuevo nombre.');
      return;
    }
    this.localidadSeleccionada.nombreLocalidad = this.nuevoNombre;
    this._travelBookerService.actualizarLocalidad(this.localidadSeleccionada).subscribe(
      (res: any) => {
        console.log('Localidad actualizada correctamente:', res);
      },
      (error: any) => {
        console.error('Error al actualizar la localidad:', error);
      }
    );
  }

}



