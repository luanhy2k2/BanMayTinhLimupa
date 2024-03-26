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
import { JWT_OPTIONS, JwtHelperService, JwtModule } from '@auth0/angular-jwt';

export function jwtOptionsFactory() {
  return {
    tokenGetter: () => {
      var userString = localStorage.getItem('user');
      var user = userString ? JSON.parse(userString) : null;
      return user.token;
    }
  };
}
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
    AdminRoutingModule,
    JwtModule.forRoot({
      jwtOptionsProvider: {
        provide: JWT_OPTIONS,
        useFactory: jwtOptionsFactory
      }
    })
  ],
  providers: [
    JwtHelperService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
