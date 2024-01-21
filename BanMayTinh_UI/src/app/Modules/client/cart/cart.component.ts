import { Component } from '@angular/core';
import { CartService } from 'src/app/Service/Client/form/CartService';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent {
  constructor(private service: CartService){}
  products! :any[]
  total:number = 0;
  ngOnInit(){
    this.loadCart()
    this.total = this.service.getTotalPrice();
  }
  loadCart(){
    const cartData = this.service.getCart()
    if (cartData !== null) {
      this.products = JSON.parse(cartData);
    }
  }
  removeProduct(id:any) {
   
    this.service.removeItem(id);
    this.loadCart()

  }
}
