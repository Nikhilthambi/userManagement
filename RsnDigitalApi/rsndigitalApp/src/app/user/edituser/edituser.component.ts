import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserDetail } from '../shared/user-detail.model';
import { UserServiceService } from '../shared/user-service.service';

@Component({
  selector: 'app-edituser',
  templateUrl: './edituser.component.html',
  styleUrls: ['./edituser.component.css']
})
export class EdituserComponent implements OnInit {
  myGroup: FormGroup
  constructor(public service: UserServiceService,
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder) { }
  startDate: any;
  userID: any;
  maxDate:any;
  ngOnInit(): void {
    this.maxDate=new Date();
    this.myGroup = this.fb.group({
      dateFormCtrl: new FormControl(new Date())
    })
    this.userID = Number(this.route.snapshot.params.userID);
    if (this.userID > 0) {
      this.editRecord();
    } else {
      this.myGroup.get('dateFormCtrl')?.setValue(new Date());
      this.service.formData = new UserDetail();
    }
  }

  onSubmit(form: NgForm) {
    var date = this.myGroup.get('dateFormCtrl')?.value;
    this.service.formData.dob = date;
    if (this.service.formData.userID == 0) {
      this.insertRecord(form);
    } else {
      this.updateRecord(form);
    }
  }

  insertRecord(form: NgForm) {
    this.service.postUserDetail().subscribe(
      res => {
        //this.resetForm(form);
        this.service.refreshList();
        this.router.navigate(['/user/list/']);
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
        this.router.navigate(['/user/list/']);
        //this.resetForm(form);
        //this.service.refreshList();
        //this.toaster.info('Updated Successfully', 'Payment Register');
      },
      err => {
        console.log(err);
      }
    )
  }

  editRecord() {
    this.service.editUsertDetail(this.userID).subscribe(
      res => {
        console.log(res);
        this.service.formData = res as UserDetail;
        this.myGroup.get('dateFormCtrl')?.setValue(this.service.formData.dob);
        //this.service.refreshList();
        //this.toaster.success('Submitted Successfully', 'Payment Register');
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
  backtoForm(){
    this.router.navigate(['/user/list/']);
  }

}
