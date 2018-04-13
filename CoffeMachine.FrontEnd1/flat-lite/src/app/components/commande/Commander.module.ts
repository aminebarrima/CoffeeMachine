import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CommanderComponent } from './Commander.component';
import {RouterModule} from '@angular/router';
import {CommanderRoutes} from './Commander.routing';
import { Commande1Component } from './Commande/Commande.component';
import {SharedModule} from '../../shared/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
   
    FormsModule,
    HttpClientModule, 
    HttpModule,
    CommonModule,
    RouterModule.forChild(CommanderRoutes),   
    SharedModule  
  ],
  declarations: [
      CommanderComponent,
      Commande1Component
  ]
})
export class CommanderModule { }
