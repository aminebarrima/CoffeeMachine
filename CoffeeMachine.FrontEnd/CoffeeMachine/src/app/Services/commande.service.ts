import { Injectable } from '@angular/core';

import { Commande } from '../Dto/Commande';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
@Injectable()
export class CommandeService {
  private CoffeeMachineApiUrl = 'http://localhost:52614/api/Commandes';
  private CoffeeMachineApiUrlCommandeByBadge = 'http://localhost:52614/api/getMemoeryCommandeByBadge'; 
 // private headers = new Headers({ 'Content-Type': 'application/json' });
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'my-auth-token'
    })
  };

  constructor(private http: HttpClient) { }
  
  AddCommande(commande: Commande): Observable<any> {
    const url = `${this.CoffeeMachineApiUrl}`;
    const result = this.http.post(url, commande, this.httpOptions) ;
   
    return result
  }
  
  getMemoeryCommandeByBadge (BadgeId: number): Observable<Commande> {
    const url = `${this.CoffeeMachineApiUrl}/${BadgeId}`;     
    return this.http.get<Commande>(url)     ;
  }

}
