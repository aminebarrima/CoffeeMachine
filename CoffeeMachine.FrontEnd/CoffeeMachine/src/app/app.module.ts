import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { CommandeComponent } from './commande/commande.component';
import { BoissonService } from './Services/boisson.service';
import { FormsModule }    from '@angular/forms';
import { HttpClientModule }    from '@angular/common/http';
import { CommandeService } from './Services/commande.service';
import { ShowErrorsComponent } from './show-errors/show-errors.component';
import { BadgeService } from './Services/badge.service';
 
import { ToastrModule, ToastrService } from 'ngx-toastr';
 

import { RegisterComponent } from './register/register.component';
import { RegisterService } from './Services/register.service';
import { LoginComponent } from './login/login.component';

import { RouterModule, Routes } from '@angular/router';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { HttpModule } from '@angular/http';
import { LoginService } from './Services/login.service';
import { MessageService } from './Services/message.service';
import { CoffeMachineModule } from './routage/coffe-machine/coffe-machine.module';


 
@NgModule({
  declarations: [
    AppComponent,
    CommandeComponent,
    ShowErrorsComponent,
    RegisterComponent,
    LoginComponent,
    PageNotFoundComponent,
    RegisterComponent
    ],
  imports: [
    CoffeMachineModule ,
    BrowserModule,
    FormsModule,
    HttpClientModule, 
    HttpModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
    
    // , 
    // RouterModule.forRoot(
    //   appRoutes,
    //   { enableTracing: true }  
    // )
 
  ],
  providers: [BoissonService,CommandeService,BadgeService,RegisterService,LoginService,MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
