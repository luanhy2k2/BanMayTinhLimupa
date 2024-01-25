import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { orderPay } from "src/app/Models/orderPay.entity";
@Injectable({
    providedIn: 'root'
})
export class PaymentService{
    constructor (private http: HttpClient){}
    payMent(orderPay:any){
        return this.http.post<any>("https://localhost:7261/api/donhang/createDonHang", orderPay);
    }
    getOrder(phone: string, pageIndex:number):Observable<any>{
        return this.http.get<any>(`https://localhost:7261/api/order/getOrder/${phone}/${pageIndex}/5`)
    }
}