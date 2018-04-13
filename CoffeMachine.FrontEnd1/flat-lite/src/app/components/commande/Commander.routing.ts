import {Routes} from '@angular/router';
import {Commande1Component} from './Commande/Commande.component';

export const CommanderRoutes: Routes = [
    {
      path: '',
      component: Commande1Component,
      data: {
        breadcrumb: 'commande',
        status: true
      }
    }
]
