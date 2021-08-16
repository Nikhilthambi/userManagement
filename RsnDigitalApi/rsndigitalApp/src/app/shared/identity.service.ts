import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class IdentityService {
  UserId:number=0;
  TokenId:string="";
  TokenUpdate:BehaviorSubject<string>=new BehaviorSubject<string>('');
  TokenUpdate$:Observable<string>;
  constructor() { 
    this.TokenUpdate$=this.TokenUpdate.asObservable();
  }
}
