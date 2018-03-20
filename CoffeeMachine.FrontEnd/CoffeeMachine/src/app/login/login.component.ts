import { Component, OnInit } from '@angular/core';
import { environment } from '../../environments/environment';
import { RegisterBindingModel } from '../Dto/register.model';
import { Credentials } from '../Dto/Credentials';
import { LoginService } from '../Services/login.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  brandNew: boolean;
  errors: string;
  isRequesting: boolean;
  submitted: boolean = false;
  credentials: Credentials = { email: '', password: '' };
  constructor(private LoginService:LoginService,private router: Router) { }

  ngOnInit() {
  }

  register() {
    this.router.navigate(['/registre']);     
}
  login({ value, valid }: { value: Credentials, valid: boolean }) {
    this.submitted = true;
    this.isRequesting = true;
    this.errors='';
    if (valid) {
      this.LoginService.login(value.email, value.password)
        
        .subscribe(
        result => {         
          if (result) {
            this.isRequesting = false,
             this.router.navigate(['/Commande']);             
          }
        },
        error => this.errors = error);
    }
}
}
