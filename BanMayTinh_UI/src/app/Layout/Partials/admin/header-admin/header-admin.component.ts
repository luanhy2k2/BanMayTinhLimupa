import { Component } from '@angular/core';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-header-admin',
  templateUrl: './header-admin.component.html',
  styleUrls: ['./header-admin.component.scss']
})
export class HeaderAdminComponent {
  constructor(private route: Router){}
  user: any;
  ngOnInit(){
    var userString = localStorage.getItem('user');
    this.user = userString ? JSON.parse(userString) : null;
  }
  logOut(){
    localStorage.removeItem('user');
    alert("Đăng xuất thành công");
    this.route.navigate(['/client/Home']);
  }
}
