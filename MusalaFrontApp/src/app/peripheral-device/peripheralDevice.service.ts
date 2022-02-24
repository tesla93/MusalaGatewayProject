import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { PeripheralDevice } from "./peripheralDevice.model";

@Injectable({
  providedIn: 'root',
})
export class PeripheralDeviceService{

  constructor(private httpClient: HttpClient) {}

  deletePeripheralDevice(id:number){
      this.httpClient.delete(`${environment.baseUrl}peripheraldevice/${id}`).subscribe();
    }

    addPeripheralDevice(peripheralDevice: PeripheralDevice){
      this.httpClient.post<any>(`${environment.baseUrl}peripheraldevice/`, peripheralDevice)
      .subscribe();
    }



}
