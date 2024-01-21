import { Component } from '@angular/core';
import { product } from 'src/app/Models/product.entity';
import { BlobStorageService } from 'src/app/Service/BobService';
import { HomeGetDataService } from 'src/app/Service/Client/HomePage/Home-getData';
const url = 'https://localhost:44301/api/Home/banChay/10';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  constructor(private homeService: HomeGetDataService, private blob:BlobStorageService){}
  products: any[] = [];
  quantityProduct:number = 1;
  imageUrl!: string;
  imageName = '4671_dell_7490.jpg';
  newProduct:any[] = [];
  ngOnInit() {
    this.loadProductData();
    this.loadNewProduct();
    this.imageUrl = this.blob.getImageUrl(this.imageName);
  }

  loadNewProduct() {
    this.homeService.getNewProducts().subscribe(res => {
      this.newProduct = res.results;
    });
  }
  loadProductData() {
    this.homeService.getProductSelling().subscribe(res => {
      this.products = res.results;
    });
  }

  private loadProductByCategory(categoryId: number) {
    this.homeService.getProductsCategory(categoryId, this.quantityProduct).subscribe(res => {
      this.products = res;
    });
  }
}
