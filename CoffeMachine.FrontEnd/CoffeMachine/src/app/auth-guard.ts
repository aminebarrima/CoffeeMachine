import { Injectable } from '@angular/core';
import { Router, CanActivate, CanActivateChild } from '@angular/router';
 
@Injectable()
export class AuthGuard implements CanActivate {
 
    constructor(private router: Router) { }
 
    canActivate() {
        console.log('je suis rentrer au AuthGuard');
        if (localStorage.getItem('currentUser')) {
            // logged in so return true
            return true;
        }
 
        // not logged in so redirect to login page
        this.router.navigate(['authentication/login']);
        return false;
    }
}

@Injectable()
export class AuthGuardChild implements CanActivateChild {
 
    constructor(private router: Router) { }
 
    canActivateChild() {
        console.log('je suis rentrer au AuthGuard');
        if (localStorage.getItem('currentUser')) {
            // logged in so return true
            return true;
        }
 
        // not logged in so redirect to login page
        this.router.navigate(['authentication/login']);
        return false;
    }
}