import { NgModule } from "@angular/core";
import { BranchComponent } from './branch/branch.component';
import { FormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { AdminRoutingModule } from "./admin-routing.module";
import { ProductComponent } from './product/product.component';
import { OrderComponent } from './order/order.component';
import { OrderDetailComponent } from './order/order-detail/order-detail.component';
import { HttpClientModule } from "@angular/common/http";
import { EditBranchComponent } from './branch/edit-branch/edit-branch.component';


@NgModule({
    declarations:[
    BranchComponent,
    ProductComponent,
   
    OrderComponent,
    OrderDetailComponent,
    EditBranchComponent
  ],
    imports:[
        FormsModule,
        CommonModule,
        HttpClientModule,
        AdminRoutingModule
    ]
})
export class AdminModule{}