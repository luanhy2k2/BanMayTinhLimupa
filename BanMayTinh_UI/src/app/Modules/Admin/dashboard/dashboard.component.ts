import { Component } from '@angular/core';
import { HomeGetDataService } from 'src/app/Service/Client/HomePage/Home-getData.service.';
import { DashboardService } from 'src/app/Service/admin/dashboard.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {
  constructor(private dashboardService:DashboardService, private homService:HomeGetDataService){}
  totalProduct:number = 0;
  totalUser:number = 0;
  productSelling:any;
  orderDuringDay:number = 0;
  orderDuringMonth:number = 0;
  revenueDuringDay:number = 0;
  revenueDuringMonth:number = 0;
  ngOnInit(){
    this.LoadData();
  }
  LoadData(){
    this.dashboardService.GetOrderDUringDay().subscribe(res =>{
      this.orderDuringDay = res;
    })
    this.homService.getProductSelling().subscribe(res =>{
      this.productSelling = res.results;
    })
    this.dashboardService.GetOrderDuringMonth().subscribe(res =>{
      this.orderDuringMonth = res;
    })
    this.dashboardService.GetRevenueDuringDay().subscribe(res =>{
      this.revenueDuringDay = res;
    })
    this.dashboardService.GetRevenueDuringMonth().subscribe(res =>{
      this.revenueDuringMonth = res;
    })
    this.dashboardService.GetToTalProduct().subscribe(res =>{
      this.totalProduct = res;
    })
    this.dashboardService.GetToTalUser().subscribe(res =>{
      this.totalUser = res;
    })
  }
}
