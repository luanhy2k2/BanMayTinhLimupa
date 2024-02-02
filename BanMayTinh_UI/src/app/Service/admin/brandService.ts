import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { branch } from "src/app/Models/branch.entity";
import { UserService } from "../UserService";
const url = 'https://localhost:7261';
@Injectable({
    providedIn: "root"
})

export class branchService{
    constructor(private http:HttpClient, private userService:UserService){}
    getBranch(pageIndex: any):Observable<any>{
        return this.http.get<any>(`${url}/api/loaisp/getAll/${pageIndex}/5`);
    }
    getBrandbyName(name: string): Observable<branch[]>{
        return this.http.get<branch[]>(`${url}/api/loaisp/timKiem/${name}/0/8`)
    }
    getBrandbyId(id: any): Observable<any>{
        return this.http.get<any>(`${url}/api/loaisp/layLoaiBangId/${id}`)
    }
    addBranch(branch: any) {
        return this.http.post<any>(`${url}/api/loaisp/create`, branch);
    }
    deleteBranch(id: any) {
        return this.http.delete<any>(`${url}/api/loaisp/delete/${id}`);
    }
    editBranch(branch:any){
        return this.http.post<any>(`${url}/api/loaisp/update`, branch, {headers: this.userService.addHeaderToken()})
    }
}