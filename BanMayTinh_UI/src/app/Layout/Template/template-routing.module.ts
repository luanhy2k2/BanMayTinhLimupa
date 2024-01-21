
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientTemplateComponent } from './client-template/client-template.component';
import { AdminTemplateComponent } from './admin-template/admin-template.component';


const routes: Routes = [
  {
    path: '',
    component: ClientTemplateComponent,
    children: [
      {
        path:'client',
        loadChildren: () =>
          import('../../Modules/client/client.module').then(
            (x) => x.ClientModule
          ),
      },
      
    ],
  },
  {
    path: '',
    component: AdminTemplateComponent,
    children: [
      {
        path:'admin',
        loadChildren: () =>
          import('../../Modules/Admin/admin.module').then(
            (x) => x.AdminModule
          ),
      },
      
    ],
  },
  
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TemplateRoutingModule {}
