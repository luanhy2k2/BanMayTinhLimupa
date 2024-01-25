import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { commentProduct } from 'src/app/Models/commentProduct.entity';
import { product } from 'src/app/Models/product.entity';
import { productDetail } from 'src/app/Models/productDetail.entity';
import { CartService } from 'src/app/Service/Client/form/CartService';
import { ProductDetailService } from 'src/app/Service/Client/form/ProductDetail-getData';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent {
  constructor(
    private productDetailService: ProductDetailService,
    private route: ActivatedRoute,
    private cartService: CartService
  ) {}

  routeParams = this.route.snapshot.paramMap;
  productDetail!: any;
  comment: commentProduct[] = [];

  addCommentEntity = {
    sanpId: this.routeParams.get('id'),
    maNguoiDung: 2,
    noiDung: ""
  }
  ngOnInit() {
    const productId = this.routeParams.get('id');
    this.productDetailService.getProductById(productId).subscribe(
      (res) => {
        this.productDetail = res;
        // this.getComment(res.sanpId);
      },
      
      (error) => {
        console.error('Error fetching product:', error);
      }
    );
  }
  getComment(productId: any) {
    this.productDetailService.getCommentProduct(productId).subscribe(
      (respon) => {
        this.comment = respon;
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
      },
      (error) => {
        console.error('Error adding comment:', error);
      }
    );
  }

  addToCart() {
    this.cartService.addToCart(this.productDetail);
  }
}
