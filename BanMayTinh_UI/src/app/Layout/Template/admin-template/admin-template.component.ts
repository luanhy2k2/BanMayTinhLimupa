import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-template',
  templateUrl: './admin-template.component.html',
  styleUrls: ['./admin-template.component.css']
})
export class AdminTemplateComponent {
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
