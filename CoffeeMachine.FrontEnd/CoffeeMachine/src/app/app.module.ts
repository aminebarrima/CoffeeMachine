import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
 
import { AppComponent } from './app.component';
import { CommandeComponent } from './commande/commande.component';
import { BoissonService } from './Services/boisson.service';
import { FormsModule }    from '@angular/forms';
import { HttpClientModule }    from '@angular/common/http';
import { CommandeService } from './Services/commande.service';
import { ShowErrorsComponent } from './show-errors/show-errors.component';
import { BadgeService } from './Services/badge.service';

@NgModule({
  declarations: [
    AppComponent,
    CommandeComponent,
    ShowErrorsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [BoissonService,CommandeService,BadgeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
