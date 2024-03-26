import { Component } from '@angular/core';
import { ChatMessage } from 'src/app/Models/ChatMessage.entity';
import { ChatRoom } from 'src/app/Models/ChatRoom.entity';
import { product } from 'src/app/Models/product.entity';
import { HomeGetDataService } from 'src/app/Service/Client/HomePage/Home-getData.service.';
import { UserService } from 'src/app/Service/User.service';
import { ChatHubService } from 'src/app/Service/chatHub.service';
import { RoomService } from 'src/app/Service/room.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  constructor(private homeService: HomeGetDataService) { }
  productSelling: any[] = [];
  user: any;
  quantityProduct: number = 1;
  newProduct: any[] = [];
  ngOnInit() {
    this.getProductSelling();
    this.loadNewProduct();
  }
  

  loadNewProduct() {
    this.homeService.getNewProducts().subscribe(res => {
      this.newProduct = res.results;
    });
  }
  getProductSelling() {
    this.homeService.getProductSelling().subscribe(res => {
      this.productSelling = res.results;
    });
  }
 
}
