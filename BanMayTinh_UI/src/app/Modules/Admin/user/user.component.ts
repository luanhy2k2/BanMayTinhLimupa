import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/Service/UserService';
import { productService } from 'src/app/Service/admin/productService';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent {
  constructor(private productService: productService, private userService: UserService, private route: ActivatedRoute) { }
  accounts: any[] = [];
  pageIndex: number = 1;
  totalPageArray: number[] = []
  name: string = "";
  newUser = {
    hoTen: "",
    email:"",
    password:"",
    phoneNumber:"",
    address:"",
    confirmPassword:""
  }
  user:any = "";
  ngOnInit() {
    this.user = this.userService.getUser();
    this.getAllAccount();
  }
  getAllAccount() {
    this.userService.getAllAccount(this.pageIndex).subscribe(res => {
      var total = Number(res.total);
      var toatlPage = Math.ceil(total / 8);
      this.totalPageArray = Array.from({ length: toatlPage }, (_, index) => index + 1);
      this.accounts = res.results;
      console.log(this.accounts);
    })
  }
  nextPage() {
    this.pageIndex++;
    this.getAllAccount();
  }
  previousPage() {
    this.pageIndex--;
    this.getAllAccount();
  }
  setPage(pageInDex: any) {
    this.pageIndex = pageInDex;
    this.getAllAccount();
  }
  deleteAccount(id: number) {
    const isConfirmed = confirm('Bạn có chắc muốn xoá không?');
    if (isConfirmed) {
      this.userService.deleteAccountById(id).subscribe(response => {
        alert("Xoá sản phẩm thành công");
        this.getAllAccount();
      })
    }
  }
  createAccount(){
    this.userService.CreateStaff(this.newUser).subscribe((res) =>{
      alert("Tạo tài khoản thành công");
      this.getAllAccount();
    },
    (err) =>{
      console.log(err);
      alert("Lỗi khi tạo tài khoản");
    })
  }
}
