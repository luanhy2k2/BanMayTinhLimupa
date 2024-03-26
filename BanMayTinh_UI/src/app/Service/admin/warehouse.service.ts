import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
const url = 'https://localhost:7261';
@Injectable({
  providedIn: 'root'
})
export class WareHouseService {

  constructor(private http: HttpClient) { }
  getWareHouse(pageIndex:number): Observable<any> {
    return this.http.get<any>(`${url}/api/warehouse/getAll/${pageIndex}/8`);
  }
}
