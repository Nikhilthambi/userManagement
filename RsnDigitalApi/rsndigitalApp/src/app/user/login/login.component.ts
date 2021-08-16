import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IdentityService } from 'src/app/shared/identity.service';
import { UserServiceService } from '../shared/user-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  emailRegx = /^(([^<>+()\[\]\\.,;:\s@"-#$%&=]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,3}))$/;
  showTable: boolean=true;
  user: any;
  data: any;

  constructor(
    private formBuilder: FormBuilder,
    private service:UserServiceService,
    private router:Router,
    private identity:IdentityService
  ) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: [null, [Validators.required, Validators.pattern(this.emailRegx)]],
      password: [null, Validators.required]
    });
  }

  async submit() {
    if (!this.loginForm.valid) {
      return;
    }
    this.user = this.loginForm.value;
    this.showTable=false;
    this.data =await  this.getUserValidate(this.user);
    debugger;
    if(this.data.email==null || this.data.userID==0 ){
      this.showTable=true;
      localStorage.removeItem('token');
      localStorage.removeItem('userID');
      this.router.navigateByUrl('/login');
      alert("User not Exist");
    }else{
      localStorage.setItem('token',this.data.token);
      localStorage.setItem('userID',this.data.userID);
      this.identity.UserId=this.data.userID;
      this.identity.TokenId=this.data.token;
      this.showTable=true;
      this.identity.TokenUpdate.next('token updated');
      this.router.navigateByUrl('/user/list');
    }
    
  }

  async getUserValidate(user:any) {
    return await this.service.validateUser(user.email, user.password);
   }

}
