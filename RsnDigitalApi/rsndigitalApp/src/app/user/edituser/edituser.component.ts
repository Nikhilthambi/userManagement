import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserDetail } from '../shared/user-detail.model';
import { UserServiceService } from '../shared/user-service.service';

@Component({
  selector: 'app-edituser',
  templateUrl: './edituser.component.html',
  styleUrls: ['./edituser.component.css']
})
export class EdituserComponent implements OnInit {

  constructor(public service:UserServiceService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.userId == 0) {
      this.insertRecord(form);
    } else {
      this.updateRecord(form);
    }
  }

  insertRecord(form: NgForm) {
    this.service.postUserDetail().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        //this.toaster.success('Submitted Successfully', 'Payment Register');
      },
      err => {
        console.log(err);
      }
    )
  }

  updateRecord(form: NgForm) {
    this.service.putUserDetail().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        //this.toaster.info('Updated Successfully', 'Payment Register');
      },
      err => {
        console.log(err);
      }
    )
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new UserDetail();
  }

}
