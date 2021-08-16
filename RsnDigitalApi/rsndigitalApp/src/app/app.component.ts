import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IdentityService } from './shared/identity.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  IsLoggined = false;
  title = 'rsndiditalApp';
  constructor(public identity: IdentityService, private router: Router) {

  }
  ngOnInit(): void {
    if (localStorage.getItem('token')) {
      this.IsLoggined = true;
    } else {
      this.IsLoggined = false;
    }
    this.identity.TokenUpdate$.subscribe(x => {
      if (x == '') return;
      if (localStorage.getItem('token')) {
        this.IsLoggined = true;
      } else {
        this.IsLoggined = false;
      }
    });
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('userID');
    this.IsLoggined = false;
    this.router.navigate(['/user/login']);
  }
}
