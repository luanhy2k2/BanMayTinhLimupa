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
        return this.httpClient.post(`${host}/api/account/signup`, user,{responseType: 'text' })
    }
    ResetPassword(email:string, code:string,password: string): Observable<any> {
        const request = {
            email: email,
            code: code,
            newPassword: password
        }
        return this.httpClient.post(`${host}/api/account/resetPassword`, request,{responseType: 'text' });
    }
    GenerateTokenConfirmEmail(email:string){
        return this.httpClient.post(`${host}/api/account/generateConfirmTokenEmail/${email}`, {},{responseType: 'text' });
    }
     GenerateTokenResetPassword(email:string){
        return  this.httpClient.post(`${host}/api/account/generateTokenResetpassword/${email}`, {},{responseType: 'text' });
    }
    login(email: string, password: string): Observable<any> {
        return this.httpClient.post<any>(`${host}/api/account/signin`, { email, password })
    }
    uploadFile(file: File): Observable<string> {
        const formData: FormData = new FormData();
        formData.append('file', file);
        return this.httpClient.post("https://localhost:7261/api/product/uploadFile", formData,{headers:this.addHeaderToken(), responseType: 'text' });
    }
    getUser() {
        var userString = localStorage.getItem('user');
        return userString ? JSON.parse(userString) : null;
    }
    getAllAccount(pageIndex: number): Observable<any> {
        return this.httpClient.get<any>(`${host}/api/staff/getAll/${pageIndex}/8`)
    }
    getUserById(id: any): Observable<any> {
        return this.httpClient.get<any>(`${host}/api/staff/getById/${id}`)
    }
    deleteAccountById(id: number): Observable<any> {
        return this.httpClient.delete<any>(`${host}/api/staff/delete/${id}`)
    }
    RemoveUserRole(id: string, role:string): Observable<any> {
        return this.httpClient.delete<any>(`${host}/api/staff/removeUserRole/${id}/${role}`,{headers:this.addHeaderToken()})
    }
    updateAccount(account: any): Observable<any> {
        return this.httpClient.post<any>(`${host}/api/staff/updateUser`, account, {headers:this.addHeaderToken()})
    }
    addManagerRoler(id: number): Observable<any> {
        return this.httpClient.post<any>(`${host}/api/staff/addManagerRole/${id}`, {}, {headers:this.addHeaderToken()})
    }
    addHrRoler(id: number): Observable<any> {
        return this.httpClient.post<any>(`${host}/api/staff/addHrRole/${id}`, {},{headers:this.addHeaderToken()})
    }
    addAccountantRoler(id: number): Observable<any> {
        return this.httpClient.post<any>(`${host}/api/staff/addAccountantRole/${id}`, {}, {headers:this.addHeaderToken()})
    }
    addWareHouseRoler(id: number): Observable<any> {
        return this.httpClient.post<any>(`${host}/api/staff/addWareHouseRole/${id}`, {}, {headers:this.addHeaderToken()})
    }
    addHeaderToken() {
        const user = this.getUser();
        const headers = new HttpHeaders({
            'Authorization': `Bearer ${user.token}`
        });
        return headers;
    }
    CreateStaff(user: any): Observable<any> {
        return this.httpClient.post<any>(`${host}/api/staff/createStaff`, user, {headers:this.addHeaderToken()})
    }


}