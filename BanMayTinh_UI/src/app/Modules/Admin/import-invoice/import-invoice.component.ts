import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { UserService } from 'src/app/Service/UserService';
import { InvoiceService } from 'src/app/Service/admin/invoiceService';

@Component({
  selector: 'app-import-invoice',
  templateUrl: './import-invoice.component.html',
  styleUrls: ['./import-invoice.component.scss']
})
export class ImportInvoiceComponent {
  constructor(private http:HttpClient, private userService:UserService, private InvoiceService: InvoiceService){}
  requestData = {
    maNguoiDung: this.userService.getUser().id,
  };
  total:number = 0;
  totalPageArray: any[] = [];
  
  pageIndex:number = 1;
  ImportInvoice:any[] = [];
  ngOnInit(){
    this.getInvoice();
  }
  getInvoice(){
    this.InvoiceService.getImportInvoice(this.pageIndex).subscribe(res => {
      const productCount = Number(res.total);
      console.log(productCount);
      this.total = Math.ceil(productCount / 5)
      this.totalPageArray = Array.from({ length: this.total }, (_, index) => index + 1);
      console.log(this.totalPageArray)
      this.ImportInvoice = res.results;
    })
  }
  nextPage(){
    if(this.pageIndex<this.total){
      this.pageIndex++;
      this.getInvoice();
    }
  }
  previousPage(){
      this.pageIndex--;
      this.getInvoice();
  }
  setPage(pageInDex:any){
    this.pageIndex = pageInDex;
    this.getInvoice();
  }
  addinvoice(){
    this.InvoiceService.addImportInvoice(this.requestData).subscribe(res=>{
      alert("Thêm hoá đơn thành công!");
      this.getInvoice();
    },
    err =>{
      if(err.status == 403){
        alert("Bạn không có quyền!");
      }
    })
  }
}
