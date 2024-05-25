import { HttpClient } from '@angular/common/http';
import { Injectable, WritableSignal, inject, signal } from '@angular/core';
import { Observable } from 'rxjs';
import { ILocalidad } from '../models/localidad.model';
import { IReserva } from '../models/reserva.model';
import { IViaje } from '../models/viaje.model';
import { ICategoriaButaca } from '../models/categoriasButacas.model';
import { IButaca } from '../models/butaca.model';

@Injectable({
  providedIn: 'root'
})
export class TravelBookerServiceService {

  private _http=inject(HttpClient);
  private apiUrl:string ="https://localhost:7139/api";


  guardarButaca(idViaje: number, numeroButaca: number) {
    const url = `${this.apiUrl}/Viaje/${idViaje}/AgregarButaca?numeroButaca=${numeroButaca}`;
    return this._http.post<any>(url, null);
  }

  getLocalidades(): Observable<ILocalidad[]>{
    return this._http.get<ILocalidad[]>(`${this.apiUrl}/Localidad/GetLocalidades`);
  }
  
  // getViajes(): Observable<IViaje[]>{
  //   return this._http.get<IViaje[]>(`${this.apiUrl}/Viaje/GetViajes`);
  // }

  // actualizarButacasReservadas(idViaje: number, butacasReservadas: number[]): Observable<any> {
  //   const url = `${this.apiUrl}/Viaje/viajes/${idViaje}/butacas`;
  //   return this._http.put(url, butacasReservadas);
  // }

  actualizarLocalidad(localidad: ILocalidad): Observable<ILocalidad> {
    const url = `${this.apiUrl}/Localidad/PutLocalidad`;
    return this._http.put<ILocalidad>(url, localidad);
  }

  actualizarViaje(viaje:IViaje):Observable<IViaje>{
    const url = `${this.apiUrl}/Viaje/PutViaje`;
    return this._http.put<IViaje>(url, viaje);
  }
  actualizarEstadoColectivo(idColectivo: number, estado: boolean): Observable<any> {
    const url = `${this.apiUrl}/Colectivo/colectivo/${idColectivo}/completo`;
    return this._http.put(url, estado);
  }
  getLocalidadById(id:string): Observable<ILocalidad>{
    return this._http.get<ILocalidad>(`${this.apiUrl}/Localidad/GetLocalidadById/${id}`)
  }
  getColectivoById(id:number): Observable<any>{
    return this._http.get<any>(`${this.apiUrl}/Colectivo/GetColectivoById/${id}`)
  }
  getViajeById(id:number): Observable<IViaje>{
    return this._http.get<IViaje>(`${this.apiUrl}/Viaje/GetViajeById/${id}`);
  }

  getButacaById(id:number): Observable<IButaca>{
    return this._http.get<IButaca>(`${this.apiUrl}/Butaca/GetButacaById/${id}`);
  }
  getCategoriaById(id:number): Observable<ICategoriaButaca>{
    return this._http.get<ICategoriaButaca>(`${this.apiUrl}/CategoriaButaca/GetCategoriaButacaById/${id}`);
  }
  getButacasReservadas(id:number): Observable<number[]>{
    return this._http.get<number[]>(`${this.apiUrl}/Viaje/GetButacas/${id}/butacas`);
  }

  getLocalidadByName(name:string): Observable<ILocalidad>{
    return this._http.get<ILocalidad>(`${this.apiUrl}/Localidad/GetLocalidadByName/${name}`)
  }


<<<<<<< HEAD
  // agregarLocalidad(localidad: ILocalidad): Observable<any> {
  //   const url = `${this.apiUrl}/Localidad/PostLocalidad`;
  //   return this._http.post<any>(url, localidad);
  // }

  agregarReserva(reserva: IReserva):Observable<any>{
    const url = `${this.apiUrl}/Reserva/PostReserva`;
    return this._http.post<any>(url, reserva);
  }


  getViajesByLocalidades(origen:string,destino:string): Observable<any>{
    return this._http.get<IViaje[]>(`${this.apiUrl}/Viaje/GetViajesByLocalidades/${origen}/${destino}`);
  }


  getViajesByLocalidadesYFecha(origen:string,destino:string,fecha:string): Observable<any>{
    return this._http.get<IViaje[]>(`${this.apiUrl}/Viaje/GetViajesByLocalidades/${origen}/${destino}/${fecha}`);
  }

  // postReserva(id:number,idUsuario:number, idButaca:number,idLocalidad:string,fechaYHora:Date,importe:number): Observable<IReserva> {
  //   const url = `${this.apiUrl}/Reserva/PostReserva`;
  //   const reserva: IReserva = {id,idUsuario, idButaca, idLocalidad, fechaYHora, importe };
  //   return this._http.post<IReserva>(url, reserva);
  // }

=======
  //CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
  //Método para agregar localidad
  agregarLocalidad(localidad: ILocalidad): Observable<any> {
    const url = `${this.apiUrl}/Localidad/PostLocalidad`;
    return this._http.post<any>(url, localidad);
  }
  //CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC

  agregarReserva(reserva: IReserva):Observable<any>{
    const url = `${this.apiUrl}/Reserva/PostReserva`;
    return this._http.post<any>(url, reserva);
  }


  getViajesByLocalidades(origen:string,destino:string): Observable<any>{
    return this._http.get<IViaje[]>(`${this.apiUrl}/Viaje/GetViajesByLocalidades/${origen}/${destino}`);
  }


  getViajesByLocalidadesYFecha(origen:string,destino:string,fecha:string): Observable<any>{
    return this._http.get<IViaje[]>(`${this.apiUrl}/Viaje/GetViajesByLocalidades/${origen}/${destino}/${fecha}`);
  }

  // postReserva(id:number,idUsuario:number, idButaca:number,idLocalidad:string,fechaYHora:Date,importe:number): Observable<IReserva> {
  //   const url = `${this.apiUrl}/Reserva/PostReserva`;
  //   const reserva: IReserva = {id,idUsuario, idButaca, idLocalidad, fechaYHora, importe };
  //   return this._http.post<IReserva>(url, reserva);
  // }

>>>>>>> e869578d8ea772c899111e2359066bfcd0b4d222
  // agregarReserva(id:number,nombreUsuario:string,apellidoUsuario:string,dniUsuario:string,fechaNacimiento:Date,idButaca:number,idViaje:string,precioFinal:number){
  //   const url = `${this.apiUrl}/Reserva/PostReserva`;
  //   const reserva: IReserva = {id,nombreUsuario,apellidoUsuario,dniUsuario,fechaNacimiento,idButaca, idViaje,precioFinal };
  //   return this._http.post<IReserva>(url, reserva);
  // }




  precioReserva = signal(0); //precio total
  idViaje = signal(0);
  idColectivo = signal(0);
  origen = signal("");
  destino = signal("");
  fechaSalida = signal("");
  horaSalida = signal("");
  nombreUsuario = signal("");
  apellidoUsuario = signal("");
  dniusuario = signal("");
  precioFinal = signal(0);
  precio = signal(0); //precio del viaje
  precioButaca = signal(0); //precio de la butaca
  butaca = signal(0);
  





}
