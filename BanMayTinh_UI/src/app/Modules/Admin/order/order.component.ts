import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { orderService } from 'src/app/Service/admin/orderService';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent {
  constructor(private orderService:orderService, private http:HttpClient){}
  order!: any[];
  total:number = 0;
  orderById!: any;
  pageIndex: number = 1;
  totalPageArray: number[] = [];
  ngOnInit(){
    this.getOrder();
   }
  getOrder(){
    this.http.get<any>("https://localhost:7261/api/order/count").subscribe(res => {
      const productCount = Number(res);
      this.total = Math.ceil(productCount / 8)
      this.totalPageArray = Array.from({ length: this.total }, (_, index) => index + 1);
      console.log(this.totalPageArray)
    })
    this.orderService.getOrder(this.pageIndex).subscribe((data) => {
      this.order = data;
    });
  }
  
  nextPage(){
    this.pageIndex++;
    this.getOrder();
  }
  previousPage(){
    this.pageIndex--;
    this.getOrder();
  }
  setPage(pageInDex:any){
    this.pageIndex = pageInDex;
    this.getOrder();
  }
}
