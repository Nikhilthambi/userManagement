import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EdituserComponent } from './edituser/edituser.component';
import { LoginComponent } from './login/login.component';
import { UserlistComponent } from './userlist/userlist.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'list', component: UserlistComponent },
  { path: 'edit/:userID', component: EdituserComponent },
  { path: '', redirectTo: 'login', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
