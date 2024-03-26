import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { commentProduct } from "src/app/Models/commentProduct.entity";
import { product } from "src/app/Models/product.entity";
import { productDetail } from "src/app/Models/productDetail.entity";
import { UserService } from "../../User.service";

@Injectable({
    providedIn: "root"
})
export class ProductDetailService{
    constructor(private httpClient: HttpClient, private userService:UserService){}
    getProductById(id:any):Observable<productDetail>{
        return this.httpClient.get<productDetail>(`https://localhost:7261/api/productDetail/getProductById/${id}`)
    }
    getProductSameAuthor(id:any):Observable<product[]>{
        return this.httpClient.get<product[]>(`https://localhost:7261/api/productDetail/productSameAuthor/${id}`)
    }
    getCommentProduct(id:any, pageIndex:number):Observable<any>{
        return this.httpClient.get<any>(`https://localhost:7261/api/productDetail/getComment/${id}/${pageIndex}/5`)
    }
    addCommentProduct(comment:any){
        return this.httpClient.post(`https://localhost:7261/api/productDetail/addComment`, comment, {headers:this.userService.addHeaderToken()})
    }
    
}