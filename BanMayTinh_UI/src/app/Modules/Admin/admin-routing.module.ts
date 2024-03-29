import { RouterModule, Routes } from "@angular/router";
import { BranchComponent } from "./branch/branch.component";
import { NgModule } from "@angular/core";
import { ProductComponent } from "./product/product.component";

import { OrderDetailComponent } from "./order/order-detail/order-detail.component";
import { OrderComponent } from "./order/order.component";
import { WarehouseComponent } from "./warehouse/warehouse.component";
import { ImportInvoiceComponent } from "./import-invoice/import-invoice.component";
import { ImportInvoiceDetailComponent } from "./import-invoice/import-invoice-detail/import-invoice-detail.component";
import { UserComponent } from "./user/user.component";
import { UserDetailComponent } from "./user/user-detail/user-detail.component";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { ExportInvoiceComponent } from "./export-invoice/export-invoice.component";
import { InvoiceComponent } from "./export-invoice/invoice/invoice.component";


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
    },
    {
        path: 'wareHouse',
        component:WarehouseComponent
    },
    {
        path: 'dashboard',
        component:DashboardComponent
    },
    {
        path: 'exportInvoice',
        component:ExportInvoiceComponent
    },
    {
        path: 'invoice/:id',
        component:InvoiceComponent
        
    },
    {
        path: 'account',
        component:UserComponent
    },
    {
        path: 'account/:id',
        component:UserDetailComponent
    },
    {
        path: 'importInvoice',
        component:ImportInvoiceComponent
    },
    {
        path: 'importInvoiceDetail/:id',
        component:ImportInvoiceDetailComponent
    },
   
]
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
export class AdminRoutingModule { }