import { Component } from '@angular/core';
import { CartService } from 'src/app/Service/Client/form/Cart.service';
import { PaymentService } from 'src/app/Service/Client/form/Payment.service';
import { UserService } from 'src/app/Service/User.service';
import { AuthService } from 'src/app/Service/auth.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.scss']
})
export class PaymentComponent {
  constructor(private cartService: CartService, private authService:AuthService,
    private userService:UserService, private PayService: PaymentService) { }
  total: number = 0;
  email: string = "";
  user:any = this.userService.getUser();
  payForm = {
    customer: {
      tenKhachHang: "",
      diaChi: "",
      email: "",
      sdt: ""
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
    this.loadData();
    this.total = this.cartService.getTotalPrice();
  }
  loadData() {
    const cartData = this.cartService.getCart()
    if (cartData !== null) {
      this.products = JSON.parse(cartData);
    }
    this.email = this.authService.getEmailFromToken(this.user.token);
    this.userService.getUserById(this.email).subscribe(res =>{
      this.payForm.customer.tenKhachHang = res.userInfo.hoTen;
      this.payForm.customer.diaChi = res.userInfo.address;
      this.payForm.customer.email = res.userInfo.email;
      this.payForm.customer.sdt = res.userInfo.phoneNumber;
    })
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
          return acc + product.price * product.soLuong;
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
