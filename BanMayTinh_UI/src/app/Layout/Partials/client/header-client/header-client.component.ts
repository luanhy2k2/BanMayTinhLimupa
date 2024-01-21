import { Component } from '@angular/core';
import { HomeGetDataService } from 'src/app/Service/Client/HomePage/Home-getData';

@Component({
  selector: 'app-header-client',
  templateUrl: './header-client.component.html',
  styleUrls: ['./header-client.component.scss']
})
export class HeaderClientComponent {
  constructor(private homeService: HomeGetDataService) {
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
