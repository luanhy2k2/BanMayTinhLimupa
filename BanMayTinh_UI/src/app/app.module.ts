import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { TemplateModule } from './Layout/Template/template.module';
import { TemplateRoutingModule } from './Layout/Template/template-routing.module';
import { ClientModule } from './Modules/client/client.module';
import { ClientRoutingModule } from './Modules/client/client-routing.module';
import { AdminModule } from './Modules/Admin/admin.module';
import { AdminRoutingModule } from './Modules/Admin/admin-routing.module';


@NgModule({
  declarations: [
    AppComponent,
  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    TemplateModule,
    TemplateRoutingModule,
    ClientModule,
    ClientRoutingModule,
    AdminModule,
    AdminRoutingModule
   
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
