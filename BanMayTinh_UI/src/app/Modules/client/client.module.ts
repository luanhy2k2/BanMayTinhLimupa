import { NgModule } from "@angular/core";
import { HomeComponent } from './home/home.component';
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";
import { ClientRoutingModule } from "./client-routing.module";
import { ProductComponent } from './product/product.component';
import { CartComponent } from './cart/cart.component';
import { PaymentComponent } from './payment/payment.component';
import { FormsModule } from "@angular/forms";
import { ProductCategoryComponent } from './product-category/product-category.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductSearchComponent } from './product-search/product-search.component';
import { LoginComponent } from './login/login.component';

@NgModule({
    declarations:[
    HomeComponent,
    ProductComponent,
    CartComponent,
    PaymentComponent,
    ProductCategoryComponent,
    ProductDetailComponent,
    ProductSearchComponent,
    LoginComponent
  ],
    imports:[
      ClientRoutingModule,
      CommonModule,
      FormsModule
    ]
})
export class ClientModule{}