import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { commentProduct } from "src/app/Models/commentProduct.entity";
import { product } from "src/app/Models/product.entity";
import { productDetail } from "src/app/Models/productDetail.entity";

@Injectable({
    providedIn: "root"
})
export class UserService{
    constructor(private httpClient: HttpClient){}
    login(taiKhoan1: string, matKhau:string):Observable<any>{
        return this.httpClient.post<any>('https://localhost:7261/api/User/login', {taiKhoan1,matKhau})
    }
    uploadFile(file: File): Observable<any> {
        const formData: FormData = new FormData();
        formData.append('file', file);
    
        return this.httpClient.post<any>("https://localhost:7261/api/User/uploadfile", formData);
      }
      getUser() {
        var userString = localStorage.getItem('user');
        return userString ? JSON.parse(userString) : null;
    }
    
    
    
}