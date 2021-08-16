import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { LoginComponent } from './login/login.component';
import { UserlistComponent } from './userlist/userlist.component';
import { EdituserComponent } from './edituser/edituser.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MeterialModule } from '../meterial/meterial.module';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    LoginComponent,
    UserlistComponent,
    EdituserComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    FormsModule,
    MeterialModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class UserModule { }
