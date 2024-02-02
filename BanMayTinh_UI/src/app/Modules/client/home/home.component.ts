import { Component } from '@angular/core';
import { product } from 'src/app/Models/product.entity';
import { HomeGetDataService } from 'src/app/Service/Client/HomePage/Home-getData';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  constructor(private homeService: HomeGetDataService){}
  productSelling: any[] = [];
  quantityProduct:number = 1;
  newProduct:any[] = [];
  ngOnInit() {
    this.getProductSelling();
    this.loadNewProduct();
    
  }

  loadNewProduct() {
    this.homeService.getNewProducts().subscribe(res => {
      this.newProduct = res.results;
    });
  }
  getProductSelling() {
    this.homeService.getProductSelling().subscribe(res => {
      this.productSelling = res.results;
    });
  }

  // private loadProductByCategory(categoryId: number) {
  //   this.homeService.getProductsCategory(categoryId, this.quantityProduct).subscribe(res => {
  //     this.products = res;
  //   });
  // }
}
