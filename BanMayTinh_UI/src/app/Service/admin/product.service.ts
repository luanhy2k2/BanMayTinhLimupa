import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { product } from "src/app/Models/product.entity";
import { UserService } from "../User.service";

const url = 'https://localhost:7261';
@Injectable({
    providedIn: "root"
})

export class productService{
    constructor(private http:HttpClient, private userService:UserService){}
    getproduct(pageIndex: any):Observable<any>{
        return this.http.get<any>(`${url}/api/product/getAll/${pageIndex}/5`);
    }
    getBrandbyName(name: string): Observable<any[]>{
        return this.http.get<any[]>(`${url}/api/product/search/${name}/0/8`)
    }
    addproduct(product: any,us:any ) {
        return this.http.post<any>(`${url}/api/product/create`, product,{
            headers: {
                Authorization: `Bearer ${us.token}`
            }
        });
    }
    editproduct(product: any) {
        return this.http.post<any>(`${url}/api/product/update`, product, {headers: this.userService.addHeaderToken()});
    }
    deleteproduct(id: any) {
        return this.http.delete<any>(`${url}/api/product/delete/${id}`);
    }
    getProductById(id:any):Observable<any>{
        return this.http.get<any>(`${url}/api/product/getById/${id}`)
    }
    getBranch():Observable<any>{
        return this.http.get<any>(`${url}/api/loaisp/getAll/1/20`);
    }
    getCompany():Observable<product[]>{
        return this.http.get<any[]>(`${url}/api/publishingCompany/getAll/0/20`);
    }
}