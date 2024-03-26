import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { InvoiceService } from 'src/app/Service/admin/invoice.service';
import { PdfService } from 'src/app/Service/pdf.service';
@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.scss']
})
export class InvoiceComponent {
  constructor(private invoiceService:InvoiceService, private pdfService:PdfService, private route:ActivatedRoute){}
  invoice: any;
  invoiceDetail: any[] = [];
  ngOnInit(){
    this.route.params.subscribe(params => {
      const paramValue = params['id']; 
      this.getInvoiceDetail(paramValue);
      this.getInvoiceById(paramValue);
    });
   }
   exportToPdf(): void {
    this.pdfService.exportToPdf('invoice', `invoice.pdf`);
  }
  getInvoiceDetail(id:number){
    this.invoiceService.getExportInvoiceDetailById(id).subscribe((data) => {
      this.invoiceDetail = data;
    });
  };
  getInvoiceById(id:number){
    this.invoiceService.getExportInvoiceById(id).subscribe((data) => {
      this.invoice = data;
    });
  }
}
