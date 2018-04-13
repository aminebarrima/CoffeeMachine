import { Injectable } from '@angular/core';

import { Commande } from '../Dto/Commande';
import { HttpClient, HttpHeaders } from '@angular/common/http';
//import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import { environment } from '../../environments/environment';
@Injectable()
export class CommandeService {
   
  private CoffeeMachineApiUrl= environment.API_URL+'/api/Commandes';;
  
  
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'my-auth-token'
    })
  };

  constructor(private httpclient: HttpClient) { }
  
  AddCommande(commande: Commande): Observable<any> {
    // let headers = new Headers({ 'Authorization': 'Bearer ' + this.authenticationService.token });
    // let options = new RequestOptions({ headers: headers });
    const result = this.httpclient.post(this.CoffeeMachineApiUrl, commande, this.httpOptions) ;
   
    return result
  }
  
  /*postCommande(commande: Commande){
    var body = JSON.stringify(commande);
    var headerOptions = new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method : RequestMethod.Post,headers : headerOptions});
    return this.http.post('http://localhost:28750/api/Employee',body,requestOptions);//.map(x => x.json());
  }*/

  getMemoeryCommandeByBadge (BadgeId: number): Observable<Commande> {
     
    const url = `${this.CoffeeMachineApiUrl}/${BadgeId}`;     
    return this.httpclient.get<Commande>(url);
    //return this.http.get(url).subscribe((response: Response) => response.json())
  }

}
