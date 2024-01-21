import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { orderService } from 'src/app/Service/admin/orderService';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.scss']
})
export class OrderDetailComponent {
  constructor(private orderService:orderService, private http:HttpClient,private route :ActivatedRoute){}
  order!: any;
  orderDetail!: any[];
  ngOnInit(){
    this.route.params.subscribe(params => {
      const paramValue = params['id']; 
      this.getOrderDetail(paramValue);
      this.getOrderById(paramValue);
    });
   }
  getOrderDetail(id:number){

    this.orderService.getOrderDetailById(id).subscribe((data) => {
      this.orderDetail = data;
    });
  };
  getOrderById(id:number){
    
    this.orderService.getOrderById(id).subscribe((data) => {
      this.order = data;
    });
  }
  
 
}
