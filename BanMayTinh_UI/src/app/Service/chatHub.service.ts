import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import * as signalR from '@microsoft/signalr';
import { UserService } from './User.service';
import { ChatUser } from '../Models/ChatUser.entity';
@Injectable({
  providedIn: 'root'
})
export class ChatHubService {
  private connection!: signalR.HubConnection;

  constructor(private http: HttpClient, private userService: UserService) { }

   startConnection() {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl("https://localhost:7261/chatHub", {
        accessTokenFactory: () => this.userService.getUser().token
      }).withAutomaticReconnect()
      .build();
      return this.connection.start();
   
  }

  async addNewMessageListener(callback: (messageView: any) => void) {
    this.connection.on("newMessage", callback);
  }

  async addProfileInfoListener(callback: (displayName: any) => void) {
    this.connection.on("getProfileInfo", callback);
  }

  async addRemoveUserListener(callback: (user: any) => void) {
    this.connection.on("removeUser", callback);
  }

  async addAddUserListener(callback: (user: any) => void) {
    this.connection.on("addUser", callback);
  }
  async addEditRoomListener(callback: (room: any) => void) {
    this.connection.on("updateChatRoom", callback);
    console.log(this.connection.on("updateChatRoom", callback))
  }
  async addChatRoomListener(callback: (room: any) => void) {
    this.connection.on("addChatRoom", callback);
  }
  async addDeleteRoomListener(callback: (roomId: any) => void) {
     this.connection.on("removeChatRoom", callback);
  }
  async joinRoom(roomName: string) {
    try {
      return await this.connection.invoke("Join", roomName);
    } catch (err) {
      console.error('Error while joining room:', err);
      throw err; // Re-throw the error to be handled by the caller if necessary
    }
  }
  
  async sendPrivate(receiver: string, message: string): Promise<void> {
    if (receiver.length > 0 && message.length > 0) {
      return await this.connection.invoke("SendPrivate", receiver.trim(), message.trim());
    } else {
      return Promise.reject("Receiver or message is empty");
    }
  }
  getUserList(roomName: string): Promise<ChatUser[]> {
    return this.connection.invoke("GetUsers", roomName);
  }
}
