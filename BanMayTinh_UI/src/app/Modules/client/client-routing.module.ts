import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { NgModule } from "@angular/core";
import { ProductComponent } from "./product/product.component";
import { CartComponent } from "./cart/cart.component";
import { PaymentComponent } from "./payment/payment.component";
import { ProductSearchComponent } from "./product-search/product-search.component";
import { ProductCategoryComponent } from "./product-category/product-category.component";
import { ProductDetailComponent } from "./product-detail/product-detail.component";
import { LoginComponent } from "./login/login.component";
import { MyOrderComponent } from "./my-order/my-order.component";
import { SignUpComponent } from "./sign-up/sign-up.component";
import { ResetPasswordComponent } from "./login/reset-password/reset-password.component";
import { AccountComponent } from "./account/account.component";

const routes: Routes = [
    {
        path: 'Home',
        component:HomeComponent,
        title:'IPM'
    },
    {
        path: 'Product',
        component:ProductComponent
    },
    {
        path: 'myOrder',
        component:MyOrderComponent
    },
    {
        path: 'login',
        component:LoginComponent
    },
    {
        path: 'account',
        component:AccountComponent
    },
    {
        path: 'resetPassword/:email/:code',
        component:ResetPasswordComponent
    },
    {
        path: 'signUp',
        component:SignUpComponent
    },
    {
        path:'Cart',
        component:CartComponent
    },
    {
        path:'Pay',
        component:PaymentComponent
    },
    {
        path:'search/:name',
        component:ProductSearchComponent
    },
    {
        path:'productCategory/:id',
        component:ProductCategoryComponent
    },
    {
        path:'detail/:id',
        component:ProductDetailComponent
    }
    
]
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
export class ClientRoutingModule { }