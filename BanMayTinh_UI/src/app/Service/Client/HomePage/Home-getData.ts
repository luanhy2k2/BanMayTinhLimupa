import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError, map } from "rxjs";
import { loaisp } from "src/app/Models/loaisp.entity";
import { product } from "src/app/Models/product.entity";
const host = "https://localhost:7261"
@Injectable({
  providedIn: "root"
})

export class HomeGetDataService {
  constructor(private httpClient: HttpClient) { }
  getCategories(): Observable<any> {
    return this.httpClient.get<any>(`${host}/api/loaisp/getAll/1/10`);
  }
  getProductSelling(): Observable<any> {
    return this.httpClient.get<any>(`${host}/api/Home/banChay/1/5`)
  }
  getNewProducts(): Observable<any> {
    return this.httpClient.get<any>(`${host}/api/Home/sanPhamMoi/1/5`)
  }

  getProductByName(name: string, pageIndex:number): Observable<any> {
    return this.httpClient.get<any>(`${host}/api/product/search/${name}/${pageIndex}/15`)
  }
  getProductByLoaiId(id: any, pageIndex:number): Observable<any> {
    return this.httpClient.get<any>(`${host}/api/Home/getProductByCategory/${id}/${pageIndex}/15`)
  }
  getAllProduct(pageIndex: any): Observable<any[]> {

    return this.httpClient.get<any[]>(`${host}/api/Home/laySanPham/${pageIndex}/2`)
  }
  getProductData(criteria: string, quantity: number): Observable<any[]> {
    const url = `${host}/api/Home/${criteria}/${quantity}/5`;

    return this.httpClient.get<any[]>(url)
      .pipe(
        map((response: any) => response),
        catchError((error: any) => {
          console.error('Error fetching product data:', error);
          throw error;
        })
      );
  }
  getProductsCategory(categoryId: number, quantity: number): Observable<any[]> {
    const url = `${host}/api/Home/laySpByLoai/${categoryId}/${quantity}`;
    return this.httpClient.get<any[]>(url)
      .pipe(
        map((response: any) => response),
        catchError((error: any) => {
          console.error('Error fetching product data by category:', error);
          throw error;
        })
      );
  }


}