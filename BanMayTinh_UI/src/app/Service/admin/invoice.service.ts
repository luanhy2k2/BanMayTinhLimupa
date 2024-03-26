import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { branch } from "src/app/Models/branch.entity";
import { UserService } from "../User.service";
const url = 'https://localhost:7261';
@Injectable({
    providedIn: "root"
})

export class InvoiceService{
    constructor(private http:HttpClient, private userService:UserService){}
    getImportInvoice(pageInDex:any):Observable<any>{
        return this.http.get<any>(`${url}/api/importInvoice/getAll/${pageInDex}/5`);
    }
    addImportInvoice(invoice: any) {
        invoice.ngayNhap = new Date();
        invoice.total = 0;
        return this.http.post<any>(`${url}/api/importInvoice/createInvoice`, invoice, {headers:this.userService.addHeaderToken()});
    }
    addImportInvoiceDetail(invoiceDetail: any) {
        return this.http.post<any>(`${url}/api/importInvoice/createInvoiceDetail`, invoiceDetail,{headers:this.userService.addHeaderToken()});
    }
    getImportInvoiceDetailById(id: any):Observable<any[]>{
        return this.http.get<any[]>(`${url}/api/importInvoice/getInvoiceDetailById/${id}`);
    }
    getExportInvoice(pageInDex:any):Observable<any>{
        return this.http.get<any>(`${url}/api/exportInvoice/getAll/${pageInDex}/8`);
    }
    getExportInvoiceById(id:any):Observable<any>{
        return this.http.get<any>(`${url}/api/exportInvoice/getById/${id}`);
    }
    getExportInvoiceDetailById(id: any):Observable<any[]>{
        return this.http.get<any[]>(`${url}/api/exportInvoice/getInvoiceDetailById/${id}`);
    }
    
}