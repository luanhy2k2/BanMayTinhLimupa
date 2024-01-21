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
  username: any;
  password: any;
  login() {
    this.userService.login(this.username, this.password).subscribe(res => {
      console.log(res.loaiQuyen);
     if(res.message === "Tài khoản hoặc mật khẩu không đúng"){
      alert('Thông tin đăng nhập không chính xác');
     }
      else {
        
        localStorage.setItem("user", JSON.stringify(res));
        if (res.loaiQuyen === "admin") {
          this.router.navigate(['/admin/product']);
        } else {
          this.router.navigate(['/client/Home']);
        }
      } 
    })
  }
}
