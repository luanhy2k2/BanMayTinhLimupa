import { NgModule } from "@angular/core";
import { BranchComponent } from './branch/branch.component';
import { FormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { AdminRoutingModule } from "./admin-routing.module";
import { ProductComponent } from './product/product.component';
import { OrderComponent } from './order/order.component';
import { OrderDetailComponent } from './order/order-detail/order-detail.component';
import { HttpClientModule } from "@angular/common/http";
import { WarehouseComponent } from './warehouse/warehouse.component';
import { ImportInvoiceComponent } from './import-invoice/import-invoice.component';
import { ImportInvoiceDetailComponent } from './import-invoice/import-invoice-detail/import-invoice-detail.component';
import { UserComponent } from './user/user.component';



@NgModule({
    declarations:[
    BranchComponent,
    ProductComponent,
   
    OrderComponent,
    OrderDetailComponent,
    WarehouseComponent,
    ImportInvoiceComponent,
    ImportInvoiceDetailComponent,
    UserComponent,
   
   
  ],
    imports:[
        FormsModule,
        CommonModule,
        HttpClientModule,
        AdminRoutingModule
    ]
})
export class AdminModule{}