import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HomeGetDataService } from 'src/app/Service/Client/HomePage/Home-getData';

@Component({
  selector: 'app-header-client',
  templateUrl: './header-client.component.html',
  styleUrls: ['./header-client.component.scss']
})
export class HeaderClientComponent {
  constructor(private homeService: HomeGetDataService, private router:Router) {
  }
  name: string = "";
  search(){
    this.router.navigate(['/client/search',this.name]);
  }
  branch: any[] = [];
  ngOnInit() {
    this.loadBranch();
  }
  loadBranch() {
    this.homeService.getCategories().subscribe(res => {
      this.branch = res.data;
    })
  }

}
