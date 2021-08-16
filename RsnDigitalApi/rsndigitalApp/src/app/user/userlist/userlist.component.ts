import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserDetail } from '../shared/user-detail.model';
import { UserServiceService } from '../shared/user-service.service';

@Component({
  selector: 'app-userlist',
  templateUrl: './userlist.component.html',
  styleUrls: ['./userlist.component.css']
})
export class UserlistComponent implements OnInit {

  constructor(public service: UserServiceService,
    private router: Router) { }

  ngOnInit(): void {
    this.service.refreshList();
  }
  populateForm(id:number) {
    //this.service.formData = Object.assign({}, selectedRecord);
    this.router.navigate(['/user/edit/',id]);
  }

  onDelete(id:number){
    if (confirm('Are you sure to delete this record ?')) {
      this.service.deleteUsertDetail(id)
        .subscribe(res => {
          this.service.refreshList();
          //this.toaster.error('Deleted Successfully', 'Payment Register');       
        },
        err => { console.log(err); })
    }
  }

  createForm(){
    
    this.router.navigate(['/user/edit/',0]);
  }
}
