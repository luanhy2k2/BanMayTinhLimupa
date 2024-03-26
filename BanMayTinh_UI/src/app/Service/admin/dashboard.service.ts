import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  url:string = "https://localhost:7261/api/dashboard";
  constructor(private http:HttpClient) { }
  GetToTalProduct():Observable<any>{
    return this.http.get<number>(`${this.url}/totalProduct`);
  }
  GetToTalUser(){
    return this.http.get<number>(`${this.url}/totalUser`);
  }
  GetOrderDUringDay(){
    return this.http.get<number>(`${this.url}/orderDuringDay`);
  }
  GetOrderDuringMonth(){
    return this.http.get<number>(`${this.url}/orderDuringMonth`);
  }
  GetRevenueDuringDay(){
    return this.http.get<number>(`${this.url}/RevenueDuringDay`);
  }
  GetRevenueDuringMonth(){
    return this.http.get<number>(`${this.url}/RevenueDuringMonth`);
  }
}
