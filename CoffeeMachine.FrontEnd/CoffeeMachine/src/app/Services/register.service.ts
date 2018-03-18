import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { RegisterBindingModel } from '../Dto/register.model';
@Injectable()
export class RegisterService {
  
  private CoffeeMachineApiUrl = 'http://localhost:52614/api/Account/Register';
  constructor(private http: HttpClient) { }
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
     'Accept' :'application/json, text/plain, */*'
      // 'Authorization': 'my-auth-token'
    })
  };
  register(register: RegisterBindingModel): Observable<any> {
    const url = `${this.CoffeeMachineApiUrl}`;
    const result = this.http.post(url, register, this.httpOptions) ;
   
    return result
  }
}
