import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HomeGetDataService } from 'src/app/Service/Client/HomePage/Home-getData';
import { UserService } from 'src/app/Service/UserService';

@Component({
  selector: 'app-header-client',
  templateUrl: './header-client.component.html',
  styleUrls: ['./header-client.component.scss']
})
export class HeaderClientComponent {
  constructor(private homeService: HomeGetDataService, private userService:UserService, private router:Router) {
  }
  name: string = "";
  user:any;
  search(){
    this.router.navigate(['/client/search',this.name]);
  }
  branch: any[] = [];
  ngOnInit() {
    this.loadBranch();
    this.user = this.userService.getUser(); 
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
