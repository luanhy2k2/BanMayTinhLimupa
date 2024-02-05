import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { product } from 'src/app/Models/product.entity';
import { UserService } from 'src/app/Service/UserService';
import { productService } from 'src/app/Service/admin/productService';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent {
  constructor(private productService: productService, private user: UserService, private route: ActivatedRoute) { }
  product: any[] = [];
  pageIndex: number = 1;
  branch:any[] = [];
  company:any[] = [];
  totalPageArray: number[] = []
  name: string = "";
  users:any = "";
  requestData = {
      sanpId: 0,
      sanpName: '',
      loaiId: '',
      nsxId: '',
      tomtat: '',
      namsx: '',
      ram:'',
      rom:'',
      cpu:'',
      card:'',
      battery:'',
      display:'',
      image: '',
      gia: ''
    
    
  };
  selectedFile!: File;
  ngOnInit() {
    var userString = localStorage.getItem('user');
    this.users = userString ? JSON.parse(userString) : null;
    this.getproduct();
    this.getBranch();
    this.getCompany();
  }
  getproduct() {
    this.productService.getproduct(this.pageIndex).subscribe(res => {
      var total = Number(res.totalCount);
      var toatlPage = Math.ceil(total / 5);
      this.totalPageArray = Array.from({ length: toatlPage }, (_, index) => index + 1);
      this.product = res.results;
      console.log(this.product);
    })
  }
  getproductByName() {
    this.productService.getBrandbyName(this.name).subscribe(data => {
      this.product = data;
    });
  }
  getBranch() {
    this.productService.getBranch().subscribe(data => {
      this.branch = data.data;
    });
  }
  getCompany() {
    this.productService.getCompany().subscribe(data => {
      this.company = data;
    });
  }
  nextPage() {
    this.pageIndex++;
    this.getproduct();
  }
  openModel(id:number) {
   
    this.productService.getProductById(id).subscribe(res=>{
      this.requestData = res;
      console.log(this.requestData);
    })
  } 


  previousPage() {
    this.pageIndex--;
    this.getproduct();
  }
  setPage(pageInDex: any) {
    this.pageIndex = pageInDex;
    this.getproduct();
  }
  onFileChanged(event: any) {
    this.selectedFile = event.target.files[0];
  }
  addproduct() {
    this.user.uploadFile(this.selectedFile).subscribe(
      response => {
        console.log(response);
        this.requestData.image = response.filename.originalname;
        if(!this.users){
          alert("Bạn cần phải đăng nhập!")
        }
        else{
          this.productService.addproduct(this.requestData, this.users).subscribe(response => {
            alert("Thêm sản phẩm thành công!");
            this.getproduct();
          })
        }
      },
    );
  }
  updateProduct() {
    if(!this.selectedFile){
      this.productService.editproduct(this.requestData).subscribe(response=>{
        alert("Sửa sản phẩm thành công");
        this.getproduct();
      })
    }
    else{
      this.user.uploadFile(this.selectedFile).subscribe(
        response => {
          console.log(response);
          this.requestData.image = response.fileName;
          this.productService.editproduct(this.requestData).subscribe(response=>{
            alert("Sửa sản phẩm thành công");
            this.getproduct();
          })
        },
      );
    }
     
    
   }
  deleteproduct(id: number) {
    const isConfirmed = confirm('Bạn có chắc muốn xoá không?');
    if (isConfirmed) {
      this.productService.deleteproduct(id).subscribe(response => {
        alert("Xoá sản phẩm thành công");
        this.getproduct();
      })
    }
  }
}


