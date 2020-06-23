import { Injectable, Inject } from '@angular/core';
import { Cotizacion, Compra } from '../Interfaces';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from '../../environments/environment';

const httpHeader = new HttpHeaders({
    'Content-Type': 'application/json',
    'withCredentials': 'true',
    'Access-Control-Allow-Origin':'*',
    'Accept': 'application/json',
    'Access-Control-Allow-Credentials': 'true',
    'Access-Control-Allow-Methods': 'POST, GET, OPTIONS, PUT'
});

@Injectable({
  providedIn: 'root'
})
export class OperacionesService {  
  baseUrl: string;

  constructor(protected http: HttpClient) {
    this.baseUrl = environment.BASE_URL;
  }

  public GetCotizacion(codigoMoneda: string): Observable<Cotizacion> {    
    return this.http.get<Cotizacion>(this.baseUrl + "api/cotizacion/"+codigoMoneda);
  }


  public Comprar(idUsuario, montoEnPesos, codigoMoneda): Observable<string> {
    console.log(idUsuario + montoEnPesos + codigoMoneda);
    return this.http.post<string>
       (this.baseUrl + 'api/transacciones',
         { 'IdUsuario': idUsuario, 'MontoEnPesos': Number(montoEnPesos), 'CodigoMoneda': codigoMoneda },  {headers: httpHeader});       

  }
}
