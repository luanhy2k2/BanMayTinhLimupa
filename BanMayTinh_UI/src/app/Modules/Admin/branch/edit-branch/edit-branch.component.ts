import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { branchService } from 'src/app/Service/admin/brandService';

@Component({
  selector: 'app-edit-branch',
  templateUrl: './edit-branch.component.html',
  styleUrls: ['./edit-branch.component.scss']
})
export class EditBranchComponent {
  constructor(private service: branchService, private route: ActivatedRoute) { }
  category: any;
  ngOnInit() {
    // Sử dụng ActivatedRoute để theo dõi thay đổi params
    this.route.params.subscribe(params => {
      const paramValue = params['id']; // Thay 'yourParamName' bằng tên param bạn đang sử dụng
      this.loadData(paramValue);
    });
  }
  loadData(paramValue: string) {
    this.service.getBrandbyId(paramValue).subscribe(data => {
      this.category = data;
    });
  }
  editBranch() {
    this.service.editBranch(this.category).subscribe(response => {
      alert("Sửa sản phẩm thành công");
    })
  }
}
