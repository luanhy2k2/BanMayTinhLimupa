import { Component } from '@angular/core';
import { PaymentService } from 'src/app/Service/Client/form/PaymentService';
import { UserService } from 'src/app/Service/UserService';
import { orderService } from 'src/app/Service/admin/orderService';

@Component({
  selector: 'app-my-order',
  templateUrl: './my-order.component.html',
  styleUrls: ['./my-order.component.scss']
})
export class MyOrderComponent {
  constructor(private service: PaymentService, private us:UserService, private orderService:orderService) { }
  order: any
  sdt: string = "";
  pageIndex:number = 1;
  ngOnInit() {
    this.loadData();
  }
  loadData() {
    const us = this.us.getUser();
    this.sdt = us.sdt;
    this.service.getOrder(this.sdt, this.pageIndex).subscribe(res => {
      this.order = res.results;
      console.log(res.results[0].chiTietDonHangs)
    })
  }
  
  completeOrder(id:number){
    this.orderService.completeOrder(id);
    this.loadData();
  }

}
