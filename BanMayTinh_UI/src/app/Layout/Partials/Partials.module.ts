import { NgModule } from "@angular/core";
import { HeaderClientComponent } from "./client/header-client/header-client.component";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { FooterClientComponent } from "./client/footer-client/footer-client.component";

import { HttpClient, HttpClientModule } from '@angular/common/http';
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from '@angular/forms';

import { HeaderAdminComponent } from './admin/header-admin/header-admin.component';
import { CategoryAdminComponent } from './admin/category-admin/category-admin.component';
import { FooterComponent } from './admin/footer/footer.component';
import { SliderComponent } from './client/slider/slider.component';

@NgModule({
    declarations: [
        HeaderClientComponent,
        FooterClientComponent,
      
        HeaderAdminComponent,
        CategoryAdminComponent,
        FooterComponent,
        SliderComponent
    ],
    imports: [
        CommonModule,
        RouterModule,
        BrowserModule,
        
        FormsModule,
        HttpClientModule,
        
    ],
    exports:[
        HeaderClientComponent,
        FooterClientComponent,
      
        FooterComponent,
      
        HeaderAdminComponent,
        SliderComponent,
        CategoryAdminComponent
    ]
})
export class PartialsModule{ }