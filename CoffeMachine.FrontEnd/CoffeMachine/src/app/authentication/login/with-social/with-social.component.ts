import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Login } from '../../../Dto/login';
import { LoginService } from '../../../Services/login.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-with-social',
  templateUrl: './with-social.component.html'
})
export class WithSocialComponent implements OnInit {

  loginForm : FormGroup;
  brandNew: boolean;
  errors: string;
  isRequesting: boolean;
  submitted: boolean = false;
  // ({
  //   userName: new FormControl(),

  // });
  constructor(private formBuilder: FormBuilder,private LoginService:LoginService,private router: Router) { }

  ngOnInit() {
   this. createForm();
  }
  createForm() {
    this.loginForm = this.formBuilder.group({
      userName:['',Validators.required],
      passWord:['',Validators.required],
      
    });
  }
  get userName() { return this.loginForm.get('userName').value; }
  get passWord() { return this.loginForm.get('passWord').value; }


  login() {
    this.submitted = true;
    this.isRequesting = true;
    this.errors='';
   
    if (this.loginForm.valid) {
      // JSON.parse(localStorage.getItem('currentUser')).result.access_token
      this.LoginService.login(this.userName,this.passWord)
       
        .subscribe(
        result => {   
                 
          if (result) {
            localStorage.setItem('currentUser',JSON.stringify({result})),
            this.isRequesting = false,
            console.log('local storage'+ localStorage.getItem('currentUser'))
             this.router.navigate([''])            
          }
        },
        error => this.errors = error);
    }
}

logout(): void {
  // clear token remove user from local storage to log user out
  
  localStorage.removeItem('currentUser');
}
}
