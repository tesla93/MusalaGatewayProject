import { GatewayDetailComponent } from './Gateway/gateway-detail/gateway-detail.component';
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { GatewayListComponent } from "./Gateway/gateway-list/gateway-list.component";

const appRoutes: Routes=[
  {path: '', redirectTo: '/gateways', pathMatch: 'full'},
  {path: 'gateways', component: GatewayListComponent},
  {path:'gateways/:guid', component: GatewayDetailComponent},
];


@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
  })
export class AppRoutingModule{

}
