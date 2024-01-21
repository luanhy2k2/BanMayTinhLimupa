import { NgModule } from "@angular/core";
import { ClientTemplateComponent } from './client-template/client-template.component';
import { PartialsModule } from "../Partials/Partials.module";
import { CommonModule } from "@angular/common";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { ClientRoutingModule } from "src/app/Modules/client/client-routing.module";
import { ClientModule } from "src/app/Modules/client/client.module";
import { AdminTemplateComponent } from './admin-template/admin-template.component';
import { AdminModule } from "src/app/Modules/Admin/admin.module";
import { AdminRoutingModule } from "src/app/Modules/Admin/admin-routing.module";

@NgModule({
    declarations:[
    ClientTemplateComponent,
    AdminTemplateComponent
  ],
    imports:[
      PartialsModule,
      CommonModule,
      BrowserModule,
      RouterModule,
      ClientRoutingModule,
      ClientModule,
      AdminModule,
      AdminRoutingModule
    ],
   
})
export class TemplateModule{}