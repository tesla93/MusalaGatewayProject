import { DatePipe } from '@angular/common';
import { ChangeDetectorRef, Component, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Gateway } from '../Gateway/gateway.model';
import { PeripheralDevice } from './peripheralDevice.model';
import { PeripheralDeviceService } from './peripheralDevice.service';

@Component({
  selector: 'app-peripheral-device',
  templateUrl: './peripheral-device.component.html',
})
export class PeripheralDeviceComponent implements OnInit {
@Input() gateway: Gateway;
@ViewChild('f') theForm: NgForm
displayStyle = "none";
cover="none"
dateNow:Date
pdToSave: PeripheralDevice


constructor(private pdService: PeripheralDeviceService, private datePipe: DatePipe){}


  ngOnInit(): void {

  }

  onAddNewDevice(){
    this.dateNow=new Date(Date.now());
    this.displayStyle = "block";
    this.cover="black"

  }


  closePopup() {
    this.displayStyle = "none";
  }


  onSave(){
    if(this.theForm.valid){
      this.pdToSave=new PeripheralDevice(
        this.theForm.value.vendor =='' ? 'Nokia': this.theForm.value.vendor,
        this.theForm.value.dateCreated == ''? this.datePipe.transform(Date.now(),'yyyy-MM-dd') : this.theForm.value.dateCreated,
        this.theForm.value.status =='' ? false : this.theForm.value.status,
        this.gateway.serialNumber)
        this.pdService.addPeripheralDevice(this.pdToSave);
        window.location.reload();
    }
    else{
      alert('Please fill correctly all the fields');
    }


  }
}
