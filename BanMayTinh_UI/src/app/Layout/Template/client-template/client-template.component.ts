// import { Component } from '@angular/core';
// import { ChatMessage } from 'src/app/Models/ChatMessage.entity';
// import { ChatRoom } from 'src/app/Models/ChatRoom.entity';
// import { ChatHubService } from 'src/app/Service/chatHub.service';
// import { RoomService } from 'src/app/Service/room.service';

// @Component({
//   selector: 'app-client-template',
//   templateUrl: './client-template.component.html',
//   styleUrls: ['./client-template.component.scss']
// })
// export class ClientTemplateComponent {
//   constructor(private chatService:ChatHubService, private roomService:RoomService ){

//   }
//   user: any;
//   connection!: signalR.HubConnection;
//   message: string = "";
//   chatRooms: ChatRoom[] = [];
//   chatMessages: ChatMessage[] = [];
//   joinedRoom: string = "";
//   joinedRoomId: string = "";
//   reNameRoom: string = "";
//   myName: string = "";
//   isLoading: boolean = true;

//   ngOnInit(){
//     this.chatService.startConnection().then(() => {
//       console.log('SignalR Started...');
//       this.chatService.addNewMessageListener((messageView: any) => {
//        let isMine = messageView.user === this.myName;
//        let message = new ChatMessage(messageView.content, messageView.timestamp,
//          messageView.user, isMine, messageView.avartar);
//        this.chatMessages.push(message);
//        console.log(message);
//      });
//      this.chatService.addProfileInfoListener((displayName: any) => {
//        this.myName = displayName;

//        this.isLoading = false;
//      });
//     }).catch((err: any) => {
//       console.error(err);
//     });
//   }
//   joinRoom() {
//     this.chatService.joinRoom("Nguyễn Quang Anh")
//       .then(() => {
//         this.joinedRoom = "Nguyễn Quang Anh";
//         this.joinedRoomId = "6";
//         this.messageHistory();
//       })
//       .catch(error => console.error("Error joining room: ", error));
//   }
//   sendNewMessage() {
//     if (this.message.startsWith("/")) {
//       const receiver = this.message.substring(this.message.indexOf("(") + 1, this.message.indexOf(")"));
//       const messageContent = this.message.substring(this.message.indexOf(")") + 1, this.message.length);
//       this.sendPrivate(receiver.trim(), messageContent.trim());
//     }
//     else {
//       this.sendToRoom(this.joinedRoom, this.message);
//     }
//     this.message = "";
//   }
//   sendToRoom(roomName: string, message: string) {
//     this.roomService.createMessage(roomName, message).subscribe(res => {
//     })
//   }
//   sendPrivate(receiver: string, message: string): void {
//     this.chatService.sendPrivate(receiver, message)
//       .then(() => {
//         // Handle success if needed
//       })
//       .catch(error => console.error("Error sending private message: ", error));
//   }
//   messageHistory() {
//     this.roomService.GetMessageRoom("Nguyễn Quang Anh")
//       .subscribe((data: any) => {
//         console.log(data)
//         this.chatMessages = data.items.map((message: any) => {
//           const isMine = message.user === this.myName;
//           return new ChatMessage(
//             message.content,
//             message.timestamp,
//             message.user,
//             isMine,
//             message.avartar
//           );
//         });

//       });
//   }
// }
import { Component } from '@angular/core';
import { ChatMessage } from 'src/app/Models/ChatMessage.entity';
import { ChatRoom } from 'src/app/Models/ChatRoom.entity';
import { UserService } from 'src/app/Service/User.service';
import { ChatHubService } from 'src/app/Service/chatHub.service';
import { RoomService } from 'src/app/Service/room.service';

@Component({
  selector: 'app-client-template',
  templateUrl: './client-template.component.html',
  styleUrls: ['./client-template.component.scss']
})
export class ClientTemplateComponent {
  constructor(private chatService: ChatHubService, private userService: UserService, private roomService: RoomService) {

  }
  user: any = this.userService.getUser();
  connection!: signalR.HubConnection;
  message: string = "";
  chatRooms: ChatRoom[] = [];
  chatMessages: ChatMessage[] = [];
  joinedRoom: string = "";
  joinedRoomId: string = "";
  reNameRoom: string = "";
  myName: string = "";
  isLoading: boolean = true;

  ngOnInit() {
    this.chatService.startConnection().then(() => {
      console.log('SignalR Started...');
      this.chatService.addNewMessageListener((messageView: any) => {
        let isMine = messageView.user === this.myName;
        let message = new ChatMessage(messageView.content, messageView.timestamp,
          messageView.user, isMine, messageView.avartar);
        this.chatMessages.push(message);
        console.log(message);
      });
      this.chatService.addProfileInfoListener((displayName: any) => {
        this.myName = displayName;
        this.isLoading = false;
      });
    }).catch((err: any) => {
      console.error("err:", err);
    });
  }
  joinRoom() {
    this.roomService.GetRoomByUser(this.user.id).subscribe(res => {
      if (res != null) {
        this.chatService.joinRoom(this.user.id)
          .then(() => {
            this.joinedRoom = this.user.id;
            this.messageHistory(this.joinedRoom);
          })
          .catch(error => console.error("Error joining room: ", error));
      } 
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
  messageHistory(name: string) {
    this.roomService.GetMessageRoom(name)
      .subscribe((data: any) => {
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

      });
  }
}
