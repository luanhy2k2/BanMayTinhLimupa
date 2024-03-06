import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { loaisp } from 'src/app/Models/loaisp.entity';
import { product } from 'src/app/Models/product.entity';
import { HomeGetDataService } from 'src/app/Service/Client/HomePage/Home-getData';

@Component({
  selector: 'app-product-search',
  templateUrl: './product-search.component.html',
  styleUrls: ['./product-search.component.scss']
})
export class ProductSearchComponent {
  constructor(private HomeService:HomeGetDataService, private route: ActivatedRoute){}
  products:product[] = [];
  pageInDex: number = 1;
  totalPagesArray: number[] = [];
  total!: number;
  loaisp!: loaisp[];
  ngOnInit() {
    this.loadData();
    this.HomeService.getCategories().subscribe(res=>{
      this.loaisp = res;
    })
  }
  previousPage() {
    this.pageInDex--
    this.loadData()
  }
  nextPage() {
      this.pageInDex++;
      this.loadData()
  }
  setCurrentPage(page: number) {
    this.pageInDex = page-1;
    this.loadData()
  }
  loadData() {
    this.route.params.subscribe(params => {
        const paramValue = params['name']; 
        this.HomeService.getProductByName(paramValue, this.pageInDex).subscribe(res => {
            const productCount = Number(res.total);
            this.total = Math.ceil(productCount / 15)
            this.totalPagesArray = Array.from({ length: this.total }, (_, index) => index + 1);
            this.products = res.items;
            console.log(res)
          })
      });
  }
}
