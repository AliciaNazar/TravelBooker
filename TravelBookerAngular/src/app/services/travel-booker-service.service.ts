import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { ILocalidad } from '../models/localidad.model';

@Injectable({
  providedIn: 'root'
})
export class TravelBookerServiceService {

  // private _http=inject(HttpClient);
  // private apiUrl:string ="https://localhost:7139/api";

  // getLocalidades(): Observable<ILocalidad[]>{
  //   return this._http.get<ILocalidad[]>(`${this.apiUrl}/Localidad/GetLocalidades`);
  // }

  // getLocalidadById(id:number): Observable<ILocalidad>{
  //   return this._http.get<ILocalidad>(`${this.apiUrl}/Localidad/GetLocalidadById/${id}`)
  // }

  // getLocalidadByName(name:string): Observable<ILocalidad>{
  //   return this._http.get<ILocalidad>(`${this.apiUrl}/Localidad/GetLocalidadByName/${name}`)
  // }


}
