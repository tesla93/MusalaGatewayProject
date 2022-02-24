import { Gateway } from './../gateway.model';
import { Component, HostListener, Inject, OnInit, ViewChild } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { ActivatedRoute, NavigationEnd, Router, Params } from '@angular/router';
import { filter, take } from 'rxjs/operators';
import { GatewayService } from 'src/app/Gateway/gateway.service';
import { HttpError } from 'src/app/shared/models/httpError.model';
import { NgForm } from '@angular/forms';

type RequestInfo = {
  next: string;
};

@Component({
  selector: 'app-gateway-list',
  templateUrl: './gateway-list.component.html',
})
export class GatewayListComponent implements OnInit {
  gateways: Gateway[] = [];
  displayStyle = "none";
  @ViewChild('f') theForm: NgForm



  showGoUpButton = false;

  private hideScrollHeight = 200;
  private showScrollHeight = 500;

  constructor(@Inject(DOCUMENT) private document:Document,
  private gatewaySvc: GatewayService,
  private route: ActivatedRoute,
  private router: Router,) {  }

  ngOnInit(): void {
    this.getGateways();
  }




  onScrollTop():void{
    this.document.body.scrollTop = 0;
    this.document.documentElement.scrollTop = 0;
  }



  private getGateways(): void {
    this.route.queryParams.pipe(take(1)).subscribe((params: Params) => {
      this.getDataFromService();
    });
  }

  private getDataFromService() {
    this.gatewaySvc
      .searchGateways()
      .pipe(take(1))
      .subscribe((res: any) => {
        if (res?.length) {
          this.gateways = [...res];
        } else {
          this.gateways = [];
        }
      }, (error:HttpError) => console.log((error.message)));
  }

  closePopup() {
    this.displayStyle = "none";
  }

  onAddGateway(){
    this.displayStyle = "block";
  }

  onSaveGateway(){
    if(this.theForm.valid){
      let gw=new Gateway();
      gw.name=this.theForm.value.name;
      gw.ipAddress=this.theForm.value.ipAddress;
      this.gatewaySvc.addGateway(gw);
      window.location.reload();
      this.theForm.reset();
    }
    else{
      alert("Please fill all the fields correctly");
    }

  }

}
