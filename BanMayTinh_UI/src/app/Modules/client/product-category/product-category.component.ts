import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { loaisp } from 'src/app/Models/loaisp.entity';
import { product } from 'src/app/Models/product.entity';
import { HomeGetDataService } from 'src/app/Service/Client/HomePage/Home-getData.service.';

@Component({
  selector: 'app-product-category',
  templateUrl: './product-category.component.html',
  styleUrls: ['./product-category.component.scss']
})
export class ProductCategoryComponent {
  constructor(private HomeService:HomeGetDataService, private route: ActivatedRoute){}
  products:product[] = [];
  ramOptions: string[] = ['8 GB', '16 GB'];
  romOptions: string[] = ['SSD 256GB','SSD 512GB', 'SSD 1TB', 'SSD 2TB'];
  selectedRam: string[] = [];
  selectedRom: string[] = [];
  pageInDex: number = 1;
  totalPagesArray: number[] = [];
  total!: number;
  loaisp!: loaisp[];
  ngOnInit() {
    this.loadData();
    this.HomeService.getCategories().subscribe(res=>{
      this.loaisp = res.data;
      
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
        const paramValue = params['id']; // Thay 'yourParamName' bằng tên param bạn đang sử dụng
        this.HomeService.getProductByLoaiId(paramValue, this.pageInDex).subscribe(res => {
            const productCount = Number(res.total);
            this.total = Math.ceil(productCount / 15)
            this.totalPagesArray = Array.from({ length: this.total }, (_, index) => index + 1);
            this.products = res.results;
           
          })
      });
  }
  clearAllSelections() {
    this.selectedRam = [];
    this.selectedRom = [];
    this.filterProducts();
  }
  toggleRam(ram: string) {
    if (this.selectedRam.includes(ram)) {
      this.selectedRam = this.selectedRam.filter(r => r !== ram);
    } else {
      this.selectedRam.push(ram);
    }
    this.filterProducts();
  }

  toggleRom(rom: string) {
    if (this.selectedRom.includes(rom)) {
      this.selectedRom = this.selectedRom.filter(r => r !== rom);
    } else {
      this.selectedRom.push(rom);
    }
    this.filterProducts();
  }

  filterProducts() {
    this.HomeService.getFilteredProducts(this.selectedRam, this.selectedRom, this.pageInDex)
      .subscribe((data: any) => {
        const productCount = Number(data.total);
            this.total = Math.ceil(productCount / 15)
            this.totalPagesArray = Array.from({ length: this.total }, (_, index) => index + 1);
            this.products = data.results;
      });
  }
}
