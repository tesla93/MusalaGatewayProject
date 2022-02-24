import { PeripheralDevice } from './../../peripheral-device/peripheralDevice.model';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, take } from 'rxjs';
import {Location} from '@angular/common';
import { GatewayService } from 'src/app/Gateway/gateway.service';
import { HttpError } from 'src/app/shared/models/httpError.model';
import { Gateway } from '../gateway.model';

@Component({
  selector: 'app-gateway-detail',
  templateUrl: './gateway-detail.component.html',
})
export class GatewayDetailComponent implements OnInit {
  gateway$: Observable<Gateway>;

  constructor(private route:ActivatedRoute,
    private gatewaySvc: GatewayService,
    private location:Location) { }

  ngOnInit(): void {
    this.route.params.pipe( take(1)).subscribe((params) => {
      const guid = params['guid'];
      this.gateway$ = this.gatewaySvc.getDetails(guid) as Observable<Gateway>;
    });
  }

  onGoBack():void{
    this.location.back();
  }



}
