import { Component } from '@angular/core';
import { PaymentService } from 'src/app/Service/Client/form/Payment.service';
import { UserService } from 'src/app/Service/User.service';
import { orderService } from 'src/app/Service/admin/order.service';
import { AuthService } from 'src/app/Service/auth.service';

@Component({
  selector: 'app-my-order',
  templateUrl: './my-order.component.html',
  styleUrls: ['./my-order.component.scss']
})
export class MyOrderComponent {
  constructor(private service: PaymentService, private userService:UserService,
     private auth:AuthService, private orderService:orderService) { }
  order: any;
  pageIndex:number = 1;
  ngOnInit() {
    this.loadData();
  }
  loadData() {
    var sdt = this.auth.getPhoneFromToken(this.userService.getUser().token);
    this.service.getOrder(sdt, this.pageIndex).subscribe(res => {
      this.order = res.results;
      console.log(res.results[0].chiTietDonHangs)
    })
  }
  
  completeOrder(id:number){
    this.orderService.completeOrder(id);
    this.loadData();
  }

}
