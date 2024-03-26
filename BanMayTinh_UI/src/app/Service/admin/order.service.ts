import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Component } from '@angular/core';
import { Observable } from "rxjs";
import { branch } from "src/app/Models/branch.entity";
import { UserService } from "../User.service";
const url = 'https://localhost:7261';
@Injectable({
  providedIn: "root"
})
export class orderService {
  constructor(private http: HttpClient, private userService: UserService) { }
  user = this.userService.getUser();
  headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': `Bearer ${this.user.token}`
  });
  getOrder(pageIndex: any): Observable<any> {
    return this.http.get<any>(`${url}/api/order/getall/${pageIndex}/8`);
  }
  confirmOrder(id: number): Observable<any> {
    
    return this.http.post<any>(`${url}/api/order/confirmOrder/${id}`,null, {headers: this.headers });
  }
  updateDelivery(id: number, status: string): Observable<any> {
    return this.http.post<any>(`${url}/api/order/updateDelivery/${id}/${status}`,null, {headers: this.headers });
  }
  updatePaymentStatus(id: number): Observable<any> {
    const status = "Đã thanh toán";
    return this.http.post<any>(`${url}/api/order/updatePaymentStatus/${id}/${status}`,null, {headers: this.headers });
  }
  createInvoice(data: any): Observable<any> {
    return this.http.post<any>(`${url}/api/exportInvoice/createInvoice`, data, {headers: this.headers });
  }
  createInvoiceDetail(data: any): Observable<any> {
    return this.http.post<any>(`${url}/api/exportInvoice/createInvoiceDetail`, data, {headers: this.headers });
  }
  getOrderById(id: any): Observable<any> {
    return this.http.get<any>(`${url}/api/order/getOrderById/${id}`);
  };
  getOrderDetailById(id: any): Observable<any[]> {
    return this.http.get<any[]>(`${url}/api/order/getOrderDetailById/${id}`);
  }
  completeOrder(orderId: number): void {
    this.getOrderById(orderId).subscribe(response => {
      const data = {
        maKhachHang: response.maKhachHang,
        total: response.toTal,
        ngayBan: new Date()
      };
      this.createInvoice(data).subscribe((res) => {
        this.getOrderDetailById(orderId).subscribe(details => {
          details.forEach((e: any) => {
            const dt = {
              soHoaDon: res.soHoaDon,
              sanpId: e.sanpId,
              soLuong: e.soLuong,
              giaBan: e.giaMua
            };
            this.createInvoiceDetail(dt).subscribe(() => {
              this.updatePaymentStatus(orderId).subscribe(() => {

              })
            });
          });
        });
      });
      //   this.confirmOrder(orderId).subscribe(() => {
      //     alert('Hoàn tất đơn hàng');
      //   });
    });
  }

}