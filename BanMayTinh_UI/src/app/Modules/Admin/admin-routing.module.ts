import { RouterModule, Routes } from "@angular/router";
import { BranchComponent } from "./branch/branch.component";
import { NgModule } from "@angular/core";
import { ProductComponent } from "./product/product.component";

import { OrderDetailComponent } from "./order/order-detail/order-detail.component";
import { OrderComponent } from "./order/order.component";


const routes: Routes = [
    {
        path: 'branch',
        component:BranchComponent
        
    },
    {
        path: 'product',
        component:ProductComponent
        
    },
    {
        path: 'order',
        component:OrderComponent
        
    },
    {
        path: 'orderDetail/:id',
        component:OrderDetailComponent
        
    }
    ,
   
]
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
export class AdminRoutingModule { }