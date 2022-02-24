import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { GatewayListComponent } from './Gateway/gateway-list/gateway-list.component';
import { GatewayDetailComponent } from './Gateway/gateway-detail/gateway-detail.component';
import { AppRoutingModule } from './app-routing.module';
import { GatewayItemComponent } from './Gateway/gateway-item/gateway-item.component';
import { HttpClientModule } from '@angular/common/http';
import { PeripheralDeviceComponent } from './peripheral-device/peripheral-device.component';
import { PeripheralDeviceItemComponent } from './peripheral-device/peripheral-device-item/peripheral-device-item.component';
import { FormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    GatewayListComponent,
    GatewayDetailComponent,
    GatewayItemComponent,
    PeripheralDeviceComponent,
    PeripheralDeviceItemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,

  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
