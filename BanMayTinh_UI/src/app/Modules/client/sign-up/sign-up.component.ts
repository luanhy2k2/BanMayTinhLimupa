import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/Service/UserService';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent {
  constructor(private userService: UserService, private router: Router) { }
  User = {
    email: "",
    password: "",
    phoneNumber: "",
    address: "",
    hoTen: ""
  }
  SignUp() {
    this.userService.signUp(this.User).subscribe(res => {
      console.log(res.role);
      alert("Vui lòng vào gmail để xác thực tài khoản!");
      this.userService.GenerateTokenConfirmEmail(this.User.email).subscribe(res =>{
        console.log(res)
      });
      
    });
  }
}
