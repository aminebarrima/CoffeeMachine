import { Injectable } from '@angular/core';

import { Commande } from '../Dto/Commande';
import { HttpClient, HttpHeaders } from '@angular/common/http';
@Injectable()
export class CommandeService {
  private CoffeeMachineApiUrl = 'http://localhost:52614/api/values'; 
  constructor( private http: HttpClient) { }
getMemoeryCommandeByBadge(){



}
AddCommande(commande:Commande){
  //this.http.post(this.CoffeeMachineApiUrl,).subscribe();
}
}
