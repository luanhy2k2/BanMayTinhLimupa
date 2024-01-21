import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { branch } from "src/app/Models/branch.entity";
const url = 'https://localhost:7261';
@Injectable({
    providedIn: "root"
})

export class branchService{
    constructor(private http:HttpClient){}
    getBranch(pageIndex: any):Observable<branch[]>{
        return this.http.get<branch[]>(`${url}/api/loaisp/getAll/${pageIndex}/5`);
    }
    countBranch(){
        return this.http.get(`${url}/api/loaisp/count`);
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
        return this.http.post<any>(`${url}/api/loaisp/update`, branch)
    }
}