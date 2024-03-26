import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HomeGetDataService } from 'src/app/Service/Client/HomePage/Home-getData.service.';
import { UserService } from 'src/app/Service/User.service';
import { AuthService } from 'src/app/Service/auth.service';

@Component({
  selector: 'app-header-client',
  templateUrl: './header-client.component.html',
  styleUrls: ['./header-client.component.scss']
})
export class HeaderClientComponent {
  constructor(private homeService: HomeGetDataService, private authService:AuthService,
     private userService:UserService, private router:Router) {
  }
  name: string = "";
  user:any;
  search(){
    this.router.navigate(['/client/search',this.name]);
  }
  branch: any[] = [];
  ngOnInit() {
    this.loadBranch();
    const user = this.userService.getUser(); 
    const email = this.authService.getEmailFromToken(user.token)
    this.userService.getUserById(email).subscribe(res =>{
      this.user = res.userInfo;
    })
  }
  loadBranch() {
    this.homeService.getCategories().subscribe(res => {
      this.branch = res.data;
    })
  }
  logOut(){
    localStorage.removeItem('user');
    alert("Đăng xuất thành công");
    window.location.reload();
  }

}
