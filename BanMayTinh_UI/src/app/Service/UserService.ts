import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { commentProduct } from "src/app/Models/commentProduct.entity";
import { product } from "src/app/Models/product.entity";
import { productDetail } from "src/app/Models/productDetail.entity";
const host = "https://localhost:7261"
@Injectable({
    providedIn: "root"
})

export class UserService {
    constructor(private httpClient: HttpClient) { }
    signUp(user: any): Observable<any> {
        return this.httpClient.post<any>(`${host}/api/account/signup`, user)
    }
    login(email: string, password: string): Observable<any> {
        return this.httpClient.post<any>(`${host}/api/account/signin`, { email, password })
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
    getAllAccount(pageIndex: number): Observable<any> {
        return this.httpClient.get<any>(`${host}/api/account/getAll/${pageIndex}/8`)
    }
    getAllRole(): Observable<any> {
        return this.httpClient.get<any>(`${host}/api/account/getAllRole`)
    }
    getUserById(id: any): Observable<any> {
        return this.httpClient.get<any>(`${host}/api/account/getById/${id}`)
    }
    deleteAccountById(id: number): Observable<any> {
        return this.httpClient.delete<any>(`${host}/api/account/delete/${id}`)
    }
    RemoveUserRole(id: string, role:string): Observable<any> {
        return this.httpClient.delete<any>(`${host}/api/account/removeUserRole/${id}/${role}`,{headers:this.addHeaderToken()})
    }
    updateAccount(account: any): Observable<any> {
        return this.httpClient.post<any>(`${host}/api/account/updateUser`, account, {headers:this.addHeaderToken()})
    }
    addManagerRoler(id: number): Observable<any> {
        return this.httpClient.post<any>(`${host}/api/account/addManagerRole/${id}`, {}, {headers:this.addHeaderToken()})
    }
    addHrRoler(id: number): Observable<any> {
        return this.httpClient.post<any>(`${host}/api/account/addHrRole/${id}`, {},{headers:this.addHeaderToken()})
    }
    addAccountantRoler(id: number): Observable<any> {
        return this.httpClient.post<any>(`${host}/api/account/addAccountantRole/${id}`, {}, {headers:this.addHeaderToken()})
    }
    addWareHouseRoler(id: number): Observable<any> {
        return this.httpClient.post<any>(`${host}/api/account/addWareHouseRole/${id}`, {}, {headers:this.addHeaderToken()})
    }
    addHeaderToken() {
        const user = this.getUser();
        const headers = new HttpHeaders({
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${user.token}`
        });
        return headers;
    }
    CreateStaff(user: any): Observable<any> {
        return this.httpClient.post<any>(`${host}/api/account/createStaff`, user, {headers:this.addHeaderToken()})
    }


}