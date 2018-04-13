import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
 
import { HttpClient ,HttpHeaders} from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { HandleError } from '../config/config.service';
import { Observable } from 'rxjs/Observable';
@Injectable()
export class LoginService {

  loggedIn: boolean;
  private handleError: HandleError;
  public token: string;
  constructor(private httpclient: HttpClient) { 

    var currentUser = JSON.parse(localStorage.getItem('currentUser'));
    this.token = currentUser && currentUser.token;
  }

  private httpOptions = {
    headers: new HttpHeaders({
      'Accept':  'application/json',
      'Content-Type': 'application/x-www-form-urlencoded'
    })
  };


  login(username, password) : Observable<any>{
    let headers = new HttpHeaders();
    headers.append('Accept', 'application/json');
    headers.append('Content-Type', 'application/x-www-form-urlencoded');
    let grant_type='password';
    
    return this.httpclient
      .post(
        environment.API_URL + 'Token',   
         'grant_type=password'+ '&username='+username+'&password='+ password ,this.httpOptions
       
        //  JSON.stringify({username, password }),this.httpOptions
        // { headers }
      );
      // .map((response: Response) => {
      //                   // login successful if there's a jwt token in the response

      //                   let token = response.json() && response.json().token;
      //                   if (token) {
      //                       // set token property
      //                       this.token = token;
      //    
      //                       // store username and jwt token in local storage to keep user logged in between page refreshes
      //                       localStorage.setItem('currentUser', JSON.stringify({ username: username, token: token }));
      //    
      //                       // return true to indicate successful login
      //                       return true;
      //                   } else {
      //                       // return false to indicate failed login
      //                       return false;
      //                   }
      //               });

      
      
      
      // .subscribe(res => {
      //   localStorage.setItem('auth_token', res.auth_token);
      //   this.loggedIn = true;
      //   this._authNavStatusSource.next(true);
      //   return true;
      // })
      // .catch(this.handleError);
  }
  logout(): void {
    // clear token remove user from local storage to log user out
    //this.token = null;
    localStorage.removeItem('currentUser');
}
}
