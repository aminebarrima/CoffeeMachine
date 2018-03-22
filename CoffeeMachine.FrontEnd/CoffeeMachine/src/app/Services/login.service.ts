import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
 
import { HttpClient ,HttpHeaders} from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { HandleError } from '../config/config.service';
@Injectable()
export class LoginService {

  loggedIn: boolean;
  private handleError: HandleError;

  constructor(private httpclient: HttpClient) { }

  login(userName, password) {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');

    return this.httpclient
      .post(
        environment.API_URL + '/Token',
        JSON.stringify({ userName, password }),
        { headers }
      )   
      .pipe(
        catchError(this.handleError('userName ', userName))
      );
      
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
