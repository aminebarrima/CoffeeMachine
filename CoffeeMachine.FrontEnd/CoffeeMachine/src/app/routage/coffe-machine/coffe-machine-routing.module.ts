import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from '../../login/login.component';
import { RegisterComponent } from '../../register/register.component';
import { CommandeComponent } from '../../commande/commande.component';
import { PageNotFoundComponent } from '../../page-not-found/page-not-found.component';
 

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'Register',      component: RegisterComponent },
  {
    path: 'Commande',
    component: CommandeComponent,
    data: { title: 'Commande  List' }
  },
  { path: '',
    redirectTo: '/Commande',
    pathMatch: 'full'
  },
  { path: '**', component: PageNotFoundComponent }
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CoffeMachineRoutingModule { }
