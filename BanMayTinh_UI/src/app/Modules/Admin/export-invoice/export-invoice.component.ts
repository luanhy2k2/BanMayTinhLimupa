import { Component } from '@angular/core';
import { InvoiceService } from 'src/app/Service/admin/invoice.service';

@Component({
  selector: 'app-export-invoice',
  templateUrl: './export-invoice.component.html',
  styleUrls: ['./export-invoice.component.scss']
})
export class ExportInvoiceComponent {
  constructor(private readonly InvoiceService:InvoiceService){}
  invoice:any;
  pageIndex:number = 1;
  totalInvoice:number = 0;
  totalPageArray: any[] = [];
  ngOnInit(){
    this.getInvoice();
  }
  getInvoice(){
    this.InvoiceService.getExportInvoice(this.pageIndex).subscribe(res => {
      const productCount = Number(res.total);
      this.totalInvoice = Math.ceil(productCount / 8)
      this.totalPageArray = Array.from({ length: this.totalInvoice }, (_, index) => index + 1);
      this.invoice = res.items;
    })
  }
  nextPage(){
    if(this.pageIndex<this.totalInvoice){
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
}
