import { Component } from '@angular/core';
import { UserService } from 'src/app/Service/User.service';
import { AuthService } from 'src/app/Service/auth.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent {
  constructor(private userService:UserService, private authService:AuthService){}
  user:any = this.userService.getUser();
  UserRequest = {
    hoTen: "",
    email: "",
    userName: "",
    address: "",
    phoneNumber: ""
  }
  email:any;
  Update(){
    this.userService.updateAccount(this.UserRequest).subscribe(
      (res) =>{
        alert("Cập nhật thông tin thành công!");
        this.loadData();
      },
      (err) =>{
        alert("Đã có lỗi xảy ra:" + err);
      }
    )
  }
  loadData(){
    this.email = this.authService.getEmailFromToken(this.user.token);
    this.userService.getUserById(this.email).subscribe(res =>{
      this.UserRequest = res.userInfo;
    })
  }
  ngOnInit(){
    this.loadData();
  }
}
