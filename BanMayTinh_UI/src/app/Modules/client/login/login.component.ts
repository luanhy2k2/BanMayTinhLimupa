import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { UserService } from 'src/app/Service/User.service';
import { AuthService } from 'src/app/Service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  constructor(private userService: UserService, private authService:AuthService, private router: Router) { }
  email: string = "";
  password: string = "";
  emailRecovery: string = "";
  login() {
    this.userService.login(this.email, this.password).subscribe(
      (res) => {
        console.log(res);
        if (res.message === "Tài khoản hoặc mật khẩu không đúng") {
          alert('Thông tin đăng nhập không chính xác');
        } 
        if (res === false) {
          alert('Tài khoản chưa được xácc thực');
        }
         else {
          localStorage.setItem("user", JSON.stringify(res));
          const role = this.authService.getRoleFromToken(this.userService.getUser().token)
          if (role.includes("Customer")) {
            window.location.href = "http://localhost:4200/client/Home";
          } else {
            window.location.href = "http://localhost:4200/admin/product";
            
          }
        }
      }
    );
  }
  PasswordRecovery(){
    this.userService.GenerateTokenResetPassword(this.emailRecovery).subscribe(
      (res) =>{
        alert("Vui lòng check email của bạn!");
      },
      (err) =>{
        alert("Đã có lỗi xảy ra!");
      }
    )
  }
 

}
