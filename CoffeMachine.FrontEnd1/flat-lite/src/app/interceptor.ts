
import { LoginService } from "./Services/login.service";
import {  HttpRequest,    HttpHandler,    HttpEvent,    HttpInterceptor } from "@angular/common/http";
import { Observable } from "rxjs/Observable";

export class Interceptor implements HttpInterceptor {
    constructor(private LoginService:LoginService){}
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    
        request = request.clone({
          setHeaders: {
            Authorization: `Bearer ${this.LoginService.getToken()}`
          }
        });
        return next.handle(request);
      }

}
