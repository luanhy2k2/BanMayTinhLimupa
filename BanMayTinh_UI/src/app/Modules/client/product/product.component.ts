import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { loaisp } from 'src/app/Models/loaisp.entity';
import { product } from 'src/app/Models/product.entity';
import { HomeGetDataService } from 'src/app/Service/Client/HomePage/Home-getData.service.';
import { productService } from 'src/app/Service/admin/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent {
  constructor(private service: HomeGetDataService) { }
  pageInDex: number = 1
  totalPagesArray: number[] = [];
  products!: product[]
  total!: number;
  loaisp!: loaisp[];
  ramOptions: string[] = ['8 GB', '16 GB'];
  romOptions: string[] = ['SSD 256GB','SSD 512GB', 'SSD 1TB', 'SSD 2TB'];
  selectedRam: string[] = [];
  selectedRom: string[] = [];
  ngOnInit(): void {
    this.loadData();
    this.service.getCategories().subscribe(res=>{
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
    this.service.getproduct(this.pageInDex).subscribe(res => {
      console.log(res)
      const productCount = Number(res.total);
      this.products = res.items;
      this.total = Math.ceil(productCount / 15)
      this.totalPagesArray = Array.from({ length: this.total }, (_, index) => index + 1);
    })
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
    this.service.getFilteredProducts(this.selectedRam, this.selectedRom, this.pageInDex)
      .subscribe((data: any) => {
        const productCount = Number(data.total);
            this.total = Math.ceil(productCount / 15)
            this.totalPagesArray = Array.from({ length: this.total }, (_, index) => index + 1);
            this.products = data.results;
      });
  }
}
