import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { branch } from 'src/app/Models/branch.entity';
import { branchService } from 'src/app/Service/admin/brandService';

@Component({
  selector: 'app-branch',
  templateUrl: './branch.component.html',
  styleUrls: ['./branch.component.scss']
})
export class BranchComponent {
  constructor(private branchService:branchService, private route :ActivatedRoute){ }
  branch: branch[] = [];
  pageIndex: number = 0;
  totalPageArray: number[] = []
  name: string = "";
  requestData = {
    loaiId: 0,
    loaiName: ''
  };
  
  ngOnInit(){
    this.getBranch();
    
  }
  getBranch(){
    this.branchService.countBranch().subscribe(res=>{
      var total = Number(res);
      var toatlPage = Math.ceil(total/5);
      this.totalPageArray = Array.from({ length: toatlPage }, (_, index) => index + 1);
      this.branchService.getBranch(this.pageIndex).subscribe(res=>{
        this.branch = res;
      })
    })
  }
  getBranchByName(){
    this.branchService.getBrandbyName(this.name).subscribe(data =>{
      this.branch = data;
    });
  }
  nextPage(){
    this.pageIndex++;
    this.getBranch();
  }
  previousPage(){
    this.pageIndex--;
    this.getBranch();
  }
  setPage(pageInDex:any){
    this.pageIndex = pageInDex-1;
    this.getBranch();
  }
  addBranch() {
    this.branchService.addBranch(this.requestData).subscribe(response=>{
      alert("suceess");
      this.getBranch();
    }
    
    );
  }
  deleteBranch(id: number) {
    const isConfirmed = confirm('Bạn có chắc muốn xoá không?');
    if (isConfirmed) {
      this.branchService.deleteBranch(id).subscribe(response=>{
        alert("Xoá thành công!");
        this.getBranch();
      })
    }
  }
}
