import { Injectable } from '@angular/core';

import { Boisson } from '../Dto/Boisson';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable()
export class BoissonService {
  private CoffeeMachineApiUrl = 'http://localhost:26691/api/Boissons';  
  constructor( private http: HttpClient) { }

  getBoissons (): Observable<Boisson[]> {
    return this.http.get<Boisson[]>(this.CoffeeMachineApiUrl)
     ;
  }

 
}
