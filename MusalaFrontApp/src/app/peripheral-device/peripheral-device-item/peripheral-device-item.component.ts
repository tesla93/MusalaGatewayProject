import { DatePipe } from '@angular/common';
import { ApplicationRef, Component, Input, OnInit } from '@angular/core';
import { PeripheralDevice } from '../peripheralDevice.model';
import { PeripheralDeviceService } from '../peripheralDevice.service';

@Component({
  selector: 'app-peripheral-device-item',
  templateUrl: './peripheral-device-item.component.html',
})
export class PeripheralDeviceItemComponent implements OnInit {
  @Input() peripheralDevice: PeripheralDevice;
  dateDisplayed:string;


  pdImage: string;

pdImages: string[]=[
  'https://cdn.pixabay.com/photo/2013/07/13/11/47/computer-158675__340.png',
  'https://cdn.pixabay.com/photo/2013/07/13/12/10/print-159336__340.png',
  'https://cdn.pixabay.com/photo/2012/04/13/20/24/laptop-33521__340.png'
]
constructor(private pdService: PeripheralDeviceService, private datePipe: DatePipe)
{}


  ngOnInit(): void {
    this.pdImage=this.pdImages[+this.peripheralDevice.id %3];
    // this.dateDisplayed=this.peripheralDevice.dateCreated.toDateString();
    this.dateDisplayed = this.datePipe.transform(this.peripheralDevice.dateCreated,'dd/MM/yyyy') ?? '';
  }



  deleteDevice(){
    alert(`Peripheral device ${this.peripheralDevice.vendor.toUpperCase()} will be deleted`);
    this.pdService.deletePeripheralDevice(this.peripheralDevice.id)
    window.location.reload();
  }

}
