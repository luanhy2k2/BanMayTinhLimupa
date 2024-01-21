import { Component } from '@angular/core';
import { loaisp } from 'src/app/Models/loaisp.entity';
import { HomeGetDataService } from 'src/app/Service/Client/HomePage/Home-getData';

@Component({
  selector: 'app-category-client',
  templateUrl: './category-client.component.html',
  styleUrls: ['./category-client.component.scss']
})
export class CategoryClientComponent {
  constructor(private getData: HomeGetDataService){
    
  }
  loaisp: loaisp[] = []
  ngOnInit(){
    this.getData.getCategories().subscribe(res =>{this.loaisp = res})
  }
}
