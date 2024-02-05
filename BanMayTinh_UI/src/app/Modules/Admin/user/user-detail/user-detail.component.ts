import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/Service/UserService';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.scss']
})
export class UserDetailComponent {
  constructor(private route:ActivatedRoute, private userService:UserService){

  }
  user:any;
  roles = [
    { name: 'Administrator' },
    { name: 'Accountant' },
    { name: 'Warehouse' },
    { name: 'Manager' },
    { name: 'Human Resource' },
  ];
  updateUser = {
    id: "",
    userName: "",
    email: "",
    phoneNumber: "",
    hoTen: "",
    address: ""
  }
  selectedRole: string = '';
  ngOnInit(){
    this.loadUser();
   
  }
  loadUser(){
    const id = this.route.snapshot.paramMap.get("id");
    this.userService.getUserById(id).subscribe(
      res =>{
        this.user = res;
      },
      err =>{
        console.log(err);
      }
    )
  }
  save() {
    if (this.selectedRole === 'Accountant') {
      this.addAccountantRole();
    } else if (this.selectedRole === 'Human Resource') {
      this.addHrRole();
    }
    else if (this.selectedRole === 'Manager') {
      this.addManagerRole();
    }
    else if (this.selectedRole === 'Warehouse') {
      this.addWareHouseRole();
    }
  }
  OpenModal(){
    const id = this.route.snapshot.paramMap.get("id");
    this.userService.getUserById(id).subscribe(
      res =>{
        this.updateUser = res.userInfo;
        console.log(this.updateUser);
      },
      err =>{
        console.log(err);
      }
    )
  }
  UpdateUser(){
    this.userService.updateAccount(this.updateUser).subscribe(
      res =>{
        alert("Cập nhật thông tin người dùng thành công!");
        this.loadUser();
      },
      err =>{
        if(err.status == 403){
          alert("Bạn không có quyền");
        }
        else{
          console.log(err);
          alert("Đã có lỗi xảy ra");
        }
      }
    )
  }
  addHrRole(){
    this.userService.addHrRoler(this.user.userInfo.id).subscribe(res =>{
      alert("Thêm quyền hạn thành công");
      this.loadUser();
    },
    err =>{
      alert("Có lỗi xảy ra");
    })
  }
  addManagerRole(){
    this.userService.addManagerRoler(this.user.userInfo.id).subscribe(res =>{
      alert("Thêm quyền hạn thành công");
      this.loadUser();
    },
    err =>{
      alert("Có lỗi xảy ra");
    })
  }
  addAccountantRole(){
    this.userService.addAccountantRoler(this.user.userInfo.id).subscribe(res =>{
      alert("Thêm quyền hạn thành công");
      this.loadUser();
    },
    err =>{
      alert("Có lỗi xảy ra");
    })
  }
  addWareHouseRole(){
    this.userService.addWareHouseRoler(this.user.userInfo.id).subscribe(res =>{
      alert("Thêm quyền hạn thành công");
      this.loadUser();
    },
    err =>{
      alert("Có lỗi xảy ra");
    })
  }
  RemoveUserRole(id: string, role:string){
    this.userService.RemoveUserRole(id, role).subscribe(
      res =>{
        alert("Xoá quyền người dùng thành công!");
        this.loadUser();
      },
      err =>{
        console.log(err);
        alert("Đã có lỗi xảy ra");
      }
    )
  }
}
