import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { branch } from "src/app/Models/branch.entity";
const url = 'https://localhost:7261';
@Injectable({
    providedIn: "root"
})
export class orderService{
    constructor(private http:HttpClient){}
    getOrder(pageIndex: any):Observable<any[]>{
        return this.http.get<any[]>(`${url}/api/order/getall/${pageIndex}/8`);
    }
    countOrder(){
        return this.http.get(`${url}/api/order/count`);
    }
    getOrderById(id: any):Observable<branch[]>{
        return this.http.get<branch[]>(`${url}/api/order/getOrderById/${id}`);
    };
    getOrderDetailById(id: any):Observable<branch[]>{
        return this.http.get<branch[]>(`${url}/api/order/getOrderDetailById/${id}`);
    }
    
}