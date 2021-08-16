import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { UserDetail } from './user-detail.model';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {

  constructor(private http: HttpClient) { }

  formData: UserDetail= new UserDetail();
  readonly baseURL = 'https://localhost:44337/api/User';
  list : UserDetail[];

  postUserDetail() {
    return this.http.post(this.baseURL, this.formData);
  }
  putUserDetail() {
    return this.http.put(`${this.baseURL}/${this.formData.userID}`, this.formData);
  }
  deleteUsertDetail(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  editUsertDetail(id: number) {
    return this.http.get(`${this.baseURL}/${id}`);
  }

  refreshList() {
    this.http.get(this.baseURL)
      .toPromise()
      .then(res =>this.list = res as UserDetail[]);
  }

  validateUser(email:string, password:string) {
    return this.http.post('https://localhost:44337/api/User/UserValidation',{
      UserName:email,
      Password:password
    }).toPromise();
   
  }
}
