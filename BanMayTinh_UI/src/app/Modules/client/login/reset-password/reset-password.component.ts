import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/Service/UserService';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent {
  constructor(private route:ActivatedRoute, private UserService:UserService){}
  passWord:string = "";
  code:string = "";
  email:string = "";
  ngOnInit(){
    this.route.params.subscribe(params => {
      this.email = params['email']; // Thay 'yourParamName' bằng tên param bạn đang sử dụng
      this.code = params['code']; 
    });
  }
  ResetPassword(){
    this.UserService.ResetPassword(this.email,this.code,this.passWord).subscribe(
      (res) =>{
        console.log(res);
        alert("Đổi mật khẩu thành công!");
      },
      (err) =>{
        console.log(err)
        alert("Lỗi khi thay đổi mật khẩu!");
      }
    )
  }
}
