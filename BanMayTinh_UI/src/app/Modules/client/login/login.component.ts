import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { UserService } from 'src/app/Service/UserService';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  constructor(private userService: UserService, private router: Router) { }
  email: any;
  password: any;
  login() {
    this.userService.login(this.email, this.password).subscribe(res => {
      console.log(res.role);
      if (res.message === "Tài khoản hoặc mật khẩu không đúng") {
        alert('Thông tin đăng nhập không chính xác');
      } else {
        localStorage.setItem("user", JSON.stringify(res));
        
        // Kiểm tra xem "admin" có tồn tại trong mảng role hay không
        if (res.role.includes("Customer")) {
          this.router.navigate(['/client/Home']);
        } else {
          this.router.navigate(['/admin/product']);
        }
      } 
    });
  }
  
}
