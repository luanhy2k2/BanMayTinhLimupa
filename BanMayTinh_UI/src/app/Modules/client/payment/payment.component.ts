import { Component } from '@angular/core';
import { CartService } from 'src/app/Service/Client/form/CartService';
import { PaymentService } from 'src/app/Service/Client/form/PaymentService';
import { UserService } from 'src/app/Service/UserService';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.scss']
})
export class PaymentComponent {
  constructor(private cartService: CartService,private userService:UserService, private PayService: PaymentService) { }
  total: number = 0;
  user:any = this.userService.getUser();
  payForm = {
    customer: {
      tenKhachHang: this.user.hoTen,
      diaChi: this.user.address,
      email: this.user.email,
      sdt: this.user.phone
    },
    orderDetails: [
      {
        sanpId: "",
        soLuong: "",
        giaMua: ""
      }
    ],
    total: 0
  }
  products!: any[]
  ngOnInit() {
    this.loadCart();
    this.total = this.cartService.getTotalPrice();
  }
  loadCart() {
    const cartData = this.cartService.getCart()
    if (cartData !== null) {
      this.products = JSON.parse(cartData);
    }
  }
  createDonHang() {
    const cartData = this.cartService.getCart()
    if (cartData !== null) {
      const cart = JSON.parse(cartData);
      if (this.payForm.customer.diaChi == "" || this.payForm.customer.email == "" || this.payForm.customer.sdt == null || this.payForm.customer.tenKhachHang == null) {
        alert("Bạn cần nhập đủ các thông tin!");
      }
      else {
        this.payForm.orderDetails = cart;
        var totalPrice: number = cart.reduce((acc: number, product: any) => {
          return acc + product.giaMua * product.soLuong;
        }, 0);
        this.payForm.total = totalPrice;
        this.PayService.payMent(this.payForm).subscribe(
          (response) => {
            alert("Đặt hàng thành công");
            localStorage.removeItem('cart');
          },
          (err) => {
            if (err.status === 401) {
              alert("Bạn cần phải đăng nhập");
            } else {
              alert("Đã xảy ra lỗi. Vui lòng thử lại sau.");
            }
          }
        );
        
      }

    }

  }
}
