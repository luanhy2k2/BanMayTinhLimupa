
import { Component } from '@angular/core';
import { orderService } from 'src/app/Service/admin/orderService';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent {
  constructor(private orderService:orderService){}
  order!: any[];
  total:number = 0;
  orderById!: any;
  pageIndex: number = 1;
  totalPageArray: number[] = [];
  ngOnInit(){
    this.getOrder();
   }
  getOrder(){
    this.orderService.getOrder(this.pageIndex).subscribe(res => {
      const productCount = Number(res.total);
      this.total = Math.ceil(productCount / 8)
      this.totalPageArray = Array.from({ length: this.total }, (_, index) => index + 1);
      this.order = res.results;
      console.log(this.totalPageArray)
    })
  }
  nextPage(){
    this.pageIndex++;
    this.getOrder();
  }
  previousPage(){
    this.pageIndex--;
    this.getOrder();
  }
  setPage(pageInDex:any){
    this.pageIndex = pageInDex;
    this.getOrder();
  }
  onChangeTrangThai(x: any): void {
    if (x.trangThai === 'Đã xác nhận') {
      this.conFirmOrder(x.maDonHang);
    }
  }
  updateDelivery(id:number, status:string){
    const isConfirmed = confirm('Bạn có chắc muốn cập nhật trạng thái giao hàng này không?');
    if (isConfirmed) {
      this.orderService.updateDelivery(id, status).subscribe(res =>{
        alert("Cập nhật trạng thái giao hàng thành công!");
      })
    }
  }
  onChangeGiaoHang(x: any): void {
    if (x.trangThaiGiaoHang === "Chưa giao hàng") {
      this.updateDelivery(x.maDonHang, "Chưa giao hàng");
    }
    else if (x.trangThaiGiaoHang === "Đang giao hàng") {
      this.updateDelivery(x.maDonHang, "Đang giao hàng");
    }
    else if (x.trangThaiGiaoHang === "Giao hàng không thành công") {
      this.updateDelivery(x.maDonHang, "Giao hàng không thành công");
    }
    else if (x.trangThaiGiaoHang === "Giao hàng thành công") {
      this.updateDelivery(x.maDonHang, "Giao hàng thành công");
      this.click(x.maDonHang);
    }
  }
  conFirmOrder(id: any) {
    const isConfirmed = confirm('Bạn có chắc muốn xác nhận đơn hàng này không?');
    if (isConfirmed) {
      this.orderService.confirmOrder(id).subscribe(res =>{
        alert("Xác nhận đơn hàng thành công!");
      })
    }
  }
  click(id: number) {
    setTimeout(() => {
      this.completeOrder(id);
    }, 3000); // 1 giờ = 60 phút * 60 giây * 1000 milliseconds
    this.getOrder();
  }
  completeOrder(id: number) {
    this.orderService.completeOrder(id);
    this.getOrder();
  }
}
