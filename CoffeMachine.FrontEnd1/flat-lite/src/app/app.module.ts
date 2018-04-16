import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppRoutes } from './app.routing';
import { AppComponent } from './app.component';
import { AdminLayoutComponent } from './layouts/admin/admin-layout.component';
import { AuthLayoutComponent } from './layouts/auth/auth-layout.component';
import { SharedModule } from './shared/shared.module';
import { BreadcrumbsComponent } from './layouts/admin/breadcrumbs/breadcrumbs.component';
import { TitleComponent } from './layouts/admin/title/title.component';
import {ScrollModule} from './scroll/scroll.module';
import {LocationStrategy, PathLocationStrategy} from '@angular/common';
import { BadgeService } from './Services/badge.service';
import { BoissonService } from './Services/boisson.service';
import { CommandeService } from './Services/commande.service';
import { LoginService } from './Services/login.service';
import { RegisterService } from './Services/register.service';
import { MessageService } from './message.service';
import { CommanderModule } from './components/commande/Commander.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthGuard, AuthGuardChild } from './auth-guard';
import { Interceptor } from './interceptor';

@NgModule({
  declarations: [
    AppComponent,
    AdminLayoutComponent,
    AuthLayoutComponent,
    BreadcrumbsComponent,
    TitleComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    SharedModule,
    RouterModule.forRoot(AppRoutes),
    FormsModule,    
    HttpClientModule, 
    HttpModule,
   
  ],
  exports: [ScrollModule],
  providers: [BadgeService,BoissonService,CommandeService,LoginService,RegisterService,MessageService,
      { provide: LocationStrategy, useClass: PathLocationStrategy },AuthGuard,AuthGuardChild,
      {
        provide: HTTP_INTERCEPTORS,
        useClass: Interceptor,
        multi: true
      }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
