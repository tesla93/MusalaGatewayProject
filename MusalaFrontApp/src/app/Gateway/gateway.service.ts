import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { throwError, Observable, catchError } from 'rxjs';
import { Gateway } from "./gateway.model";
import { HttpError } from "../shared/models/httpError.model";
import { environment } from "src/environments/environment";


@Injectable({
  providedIn: 'root',
})
export class GatewayService{
  constructor(private httpClient: HttpClient) {}



  searchGateways():Observable<Gateway[] | HttpError> {
    return this.httpClient.get<Gateway[]>(`${environment.baseUrl}gateway`)
    .pipe(catchError((err) => this.handleHttpError(err)));
  }

  getDetails(guid: string):Observable<Gateway | HttpError> {
    return this.httpClient.get<Gateway>(`${environment.baseUrl}gateway/${guid}`)
    .pipe(catchError((err) => this.handleHttpError(err)));
  }
  addGateway(gw: Gateway){
    this.httpClient.post<any>(`${environment.baseUrl}gateway/`, gw)
      .subscribe();
  }


  private handleHttpError(
    error:HttpErrorResponse
  ):Observable<HttpError>{
    return throwError(()=>new HttpError(
      error.status,
      error.statusText
    ));
  }



}
