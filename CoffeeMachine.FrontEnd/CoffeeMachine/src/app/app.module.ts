import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { CommandeComponent } from './commande/commande.component';
import { BoissonService } from './Services/boisson.service';
import { FormsModule }    from '@angular/forms';
import { HttpClientModule }    from '@angular/common/http';
import { CommandeService } from './Services/commande.service';

@NgModule({
  declarations: [
    AppComponent,
    CommandeComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [BoissonService,CommandeService],
  bootstrap: [AppComponent]
})
export class AppModule { }