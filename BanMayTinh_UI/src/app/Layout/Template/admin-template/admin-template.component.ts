import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ChatMessage } from 'src/app/Models/ChatMessage.entity';
import { ChatRoom } from 'src/app/Models/ChatRoom.entity';
import { ChatUser } from 'src/app/Models/ChatUser.entity';
import { UserService } from 'src/app/Service/User.service';
import { AuthService } from 'src/app/Service/auth.service';
import { ChatHubService } from 'src/app/Service/chatHub.service';
import { RoomService } from 'src/app/Service/room.service';

@Component({
  selector: 'app-admin-template',
  templateUrl: './admin-template.component.html',
  styleUrls: ['./admin-template.component.css']
})
export class AdminTemplateComponent {
  constructor(private route: Router, private chatService: ChatHubService,
    private roomService: RoomService,private userService:UserService, private authService:AuthService){}
  user: any;
  connection!: signalR.HubConnection;
  message: string = "";
  chatRooms: ChatRoom[] = [];
  chatMessages: ChatMessage[] = [];
  joinedRoom: string = "";
  joinedRoomId: string = "";
  myName: string = "";
  myAvatar: string = "avatar1.png";
  isLoading: boolean = true;
 
  ngOnInit(){
    const user = this.userService.getUser(); 
    const email = this.authService.getEmailFromToken(user.token)
    this.userService.getUserById(email).subscribe(res =>{
      this.user = res.userInfo;
    })
    this.chatService.startConnection();
    this.roomList();
 
    this.chatService.addNewMessageListener((messageView: any) => {
      let isMine = messageView.user === this.myName;
      let message = new ChatMessage(
          messageView.content,
          messageView.timestamp,
          messageView.user,
          isMine,
          messageView.avartar
      );
      this.chatMessages.push(message);
      const roomIndex = this.chatRooms.findIndex(room => room.name == messageView.room);
      if (roomIndex !== -1) {
          // Lưu trữ phần tử cần di chuyển
          const roomToMove = this.chatRooms.splice(roomIndex, 1)[0];
          // Chèn phần tử vào đầu mảng
          this.chatRooms.unshift(roomToMove);
          this.chatRooms[0].message = messageView.content; // Cập nhật nội dung tin nhắn mới
      }
  });
  
    this.chatService.addProfileInfoListener((displayName: any) => {
      this.myName = displayName;
      // this.myAvatar = avatar;
      console.log(this.myAvatar)
      this.isLoading = false;
    });
  }
  sendNewMessage() {
    if (this.message.startsWith("/")) {
      const receiver = this.message.substring(this.message.indexOf("(") + 1, this.message.indexOf(")"));
      const messageContent = this.message.substring(this.message.indexOf(")") + 1, this.message.length);
      this.sendPrivate(receiver.trim(), messageContent.trim());
    }
    else {
      this.sendToRoom(this.joinedRoom, this.message);
    }
    this.message = "";
  }
  sendToRoom(roomName: string, message: string) {
    this.roomService.createMessage(roomName, message).subscribe(res => {
    })
  }

  sendPrivate(receiver: string, message: string): void {
    this.chatService.sendPrivate(receiver, message)
      .then(() => {
        // Handle success if needed
      })
      .catch(error => console.error("Error sending private message: ", error));
  }

  joinRoom(room: ChatRoom) {
    this.toggleDiv();
    this.chatService.joinRoom(room.fromUser)
      .then(() => {
        this.joinedRoom = room.fromUser;
        this.joinedRoomId = room.id;
        this.messageHistory();
      })
      .catch(error => console.error("Error joining room: ", error));
  }
  roomList() {
    this.roomService.GetRoom()
      .subscribe(data => {
        this.chatRooms = data.items.map((room:any) => new ChatRoom(room.id, room.name,room.message,room.fromUser));
        console.log(this.chatRooms)
        
      });
  }
  messageHistory() {
    this.roomService.GetMessageRoom(this.joinedRoom)
      .subscribe((data:any) => {
        console.log(data)
        this.chatMessages = data.items.map((message: any) => {
          const isMine = message.user === this.myName;
          return new ChatMessage(
            message.content,
            message.timestamp,
            message.user,
            isMine,
            message.avartar
          );
        });
        const chatBody = document.querySelector('.chat-body');
        if (chatBody) {
          chatBody.scrollTop = chatBody.scrollHeight;
        }
      });
  }
  roomAdded(room: ChatRoom) {
    this.chatRooms.push(room);
  }
  isHidden: boolean = true;
  toggleDiv() {
    this.isHidden = !this.isHidden;
  }
  logOut(){
    localStorage.removeItem('user');
    alert("Đăng xuất thành công");
    this.route.navigate(['/client/Home']);
  }
}
