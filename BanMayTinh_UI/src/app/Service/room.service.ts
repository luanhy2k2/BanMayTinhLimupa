import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { UserService } from "./User.service";


@Injectable({
    providedIn: 'root'
})
export class RoomService {
    constructor(private http: HttpClient, private userService: UserService) { }
    createRoom(room: any): Observable<any> {
        return this.http.post<any>(`https://localhost:7261/api/Room/create/${room}`, {}, { headers: this.userService.addHeaderToken() });
    }
    EditRoom(id: any, name:string): Observable<any> {
        const rq = {
            id: id,
            name: name
          }
        return this.http.put<any>("https://localhost:7066/api/Room", rq, { headers: this.userService.addHeaderToken() });
    }
    uploadFile(file: File): Observable<any> {
        const formData: FormData = new FormData();
        formData.append('file', file);
        
        console.log(formData)
        return this.http.post<any>("https://localhost:7066/api/UploadFile", formData, {headers:this.userService.addHeaderToken()});
      }
    GetRoom():Observable<any>{
        return this.http.get<any>('https://localhost:7261/api/Room/Get/1/5', { headers:this.userService.addHeaderToken() })
    }
    DeleteRoom(id:any):Observable<any> {
        return this.http.delete<any>(`https://localhost:7066/api/Room/${id}`, { headers:this.userService.addHeaderToken() })
    }
    GetRoomByUser(id:string):Observable<any>{
        return this.http.get<any>(`https://localhost:7261/api/Room/GetRoomByUserId/${id}`);
    }
    createMessage(roomName:string, message: string): Observable<any> {
        const req = {
            content: message,
            roomName:roomName
        }
        return this.http.post<any>("https://localhost:7261/api/Message/Create", req, { headers: this.userService.addHeaderToken() });
    }
    GetMessageRoom(room: any): Observable<any> {
        return  this.http.get<any>(`https://localhost:7261/api/Message/Get/${room}/1/100`, { headers: this.userService.addHeaderToken() });
    }


}