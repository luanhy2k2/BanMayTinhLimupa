import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { InvoiceService } from 'src/app/Service/admin/invoice.service';

@Component({
  selector: 'app-import-invoice-detail',
  templateUrl: './import-invoice-detail.component.html',
  styleUrls: ['./import-invoice-detail.component.scss']
})
export class ImportInvoiceDetailComponent {
  constructor(private invoiceService:InvoiceService, private http:HttpClient,private route :ActivatedRoute){}
  requestData = {
    soHoaDon: this.route.snapshot.paramMap.get('id'),
    sanpId: null,
    nsxId:null,
    soLuong: null
  };
  invoiceDetail!: any[];

  ngOnInit(){
    this.getOrderDetail();
   }
  getOrderDetail(){

    this.route.params.subscribe(params => {
      const paramValue = params['id']; 
      this.invoiceService.getImportInvoiceDetailById(paramValue).subscribe(res=>{
        this.invoiceDetail = res;
      });
    });
  };
  addInvoiceDetail(){
    this.invoiceService.addImportInvoiceDetail(this.requestData).subscribe(res=>{
      alert("Thêm chi tiết thành công!");
      this.getOrderDetail();
    },
    err =>{
      if(err.status == 401 || err.status == 403){
        alert("Bạn không có quyền");
      }
    })
  }
}
