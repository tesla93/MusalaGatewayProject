import { ChangeDetectionStrategy, Component, Input, OnChanges, OnInit } from '@angular/core';
import { Gateway } from '../gateway.model';

@Component({
  selector: 'app-gateway-item',
  templateUrl: './gateway-item.component.html',
  changeDetection:ChangeDetectionStrategy.OnPush
})
export class GatewayItemComponent implements OnInit{

  @Input() gatewayItem :Gateway;
  gatewayImage: string;
  uriEncoded: string;

  gatewayImages: string[]=[
    'https://cdn.pixabay.com/photo/2012/04/11/17/19/router-29021__340.png',
    'https://cdn.pixabay.com/photo/2013/07/13/10/42/router-157597__340.png',
    'https://cdn.pixabay.com/photo/2016/11/18/12/09/white-male-1834131__340.jpg'
]




ngOnInit(): void {
    let lastIpNumber=this.gatewayItem.ipAddress.split('.').pop() ?? 0;
    this.gatewayImage=this.gatewayImages[+lastIpNumber%3];
    this.uriEncoded =encodeURIComponent(this.gatewayItem.serialNumber)

}

}
