import { NgModule, ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { CommandeComponent } from './commande/commande.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { AuthGuard } from './auth-guard/auth-guard';
 

const appRoutes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'Register',      component: RegisterComponent },
  {
    path: 'Commande',
    component: CommandeComponent,
    data: { title: 'Commande  List' }
  },
  { path: '',
    redirectTo: '/Commande',
    pathMatch: 'full',
    // canActivate: [
    //   'CanAlwaysActivateGuard',
    //   AuthGuard
    // ]
    
  },
  { path: '**', component: PageNotFoundComponent }
];
@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class CoffeMachineRoutingModule { }
 
