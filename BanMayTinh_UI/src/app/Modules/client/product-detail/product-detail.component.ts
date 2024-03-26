import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { commentProduct } from 'src/app/Models/commentProduct.entity';
import { product } from 'src/app/Models/product.entity';
import { productDetail } from 'src/app/Models/productDetail.entity';
import { HomeGetDataService } from 'src/app/Service/Client/HomePage/Home-getData.service.';
import { CartService } from 'src/app/Service/Client/form/Cart.service';
import { ProductDetailService } from 'src/app/Service/Client/form/ProductDetail-getData.service';
import { UserService } from 'src/app/Service/User.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent {
  constructor(
    private productDetailService: ProductDetailService,
    private route: ActivatedRoute,
    private homeService:HomeGetDataService,
    private cartService: CartService,
    private userService:UserService
  ) {}

  routeParams = this.route.snapshot.paramMap;
  productDetail!: any;
  pageIndex: number = 1;
  commentIndex:number = 1;
  comment: commentProduct[] = [];
  productSameCategory:any;
  user = this.userService.getUser();
  addCommentEntity = {
    sanpId: this.routeParams.get('id'),
    maNguoiDung: this.user.id,
    noiDung: ""
  }
  ngOnInit() {
    const productId = this.routeParams.get('id');
    this.productDetailService.getProductById(productId).subscribe(
      (res) => {
        this.productDetail = res;
        console.log(res)
        this.GetProductSameCategory(this.productDetail.loaiId)
        this.getComment();
      },
      
      (error) => {
        console.error('Error fetching product:', error);
      }
    );
  }
  GetProductSameCategory(id:number){
    this.homeService.getProductByLoaiId(id,this.pageIndex).subscribe(
      res =>{
        this.productSameCategory = res.results
      },
      err =>{
        console.log(err);
      }
    )
  }
  getComment() {
    this.productDetailService.getCommentProduct(this.productDetail.sanpId, this.commentIndex).subscribe(
      (respon) => {
        this.comment = respon.results;
        console.log(respon.results)
      },
      (error) => {
        console.error('Error fetching comments:', error);
      }
    );
  }
  addComment() {
    this.productDetailService.addCommentProduct(this.addCommentEntity).subscribe(
      (response) => {
        console.log('Comment added successfully:', response);
        alert("Comment added successfully!")
        this.getComment();
      },
      (error) => {
        console.error('Error adding comment:', error);
      }
    );
  }

  addToCart(x:any) {
    this.cartService.addToCart(x);
  }
}
