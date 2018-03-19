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
<<<<<<< HEAD
import { ToastrModule } from 'ngx-toastr';
=======

import { RegisterComponent } from './register/register.component';
import { RegisterService } from './Services/register.service';
import { LoginComponent } from './login/login.component';

import { RouterModule, Routes } from '@angular/router';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const appRoutes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'Register',      component: RegisterComponent },
  {
    path: 'Commande',
    component: CommandeComponent,
    data: { title: 'Heroes List' }
  },
  { path: '',
    redirectTo: '/Commande',
    pathMatch: 'full'
  },
  { path: '**', component: PageNotFoundComponent }
];



>>>>>>> 22271d5e0059381b3032ba12d95920d67a94f97e
@NgModule({
  declarations: [
    AppComponent,
    CommandeComponent,
    ShowErrorsComponent,
    RegisterComponent,
    LoginComponent,
    PageNotFoundComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
<<<<<<< HEAD
    BrowserAnimationsModule,
    ToastrModule.forRoot()
=======
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true } // <-- debugging purposes only
    )
>>>>>>> 22271d5e0059381b3032ba12d95920d67a94f97e
  ],
  providers: [BoissonService,CommandeService,BadgeService,RegisterService],
  bootstrap: [AppComponent]
})
export class AppModule { }
