import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Badge} from '../Dto/Badge';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable()
export class BadgeService {
  private CoffeeMachineApiUrl = 'http://localhost:26691/api/Badges';  
  constructor( private http: HttpClient) { }

  getBadges (): Observable<Badge[]> {
    return this.http.get<Badge[]>(this.CoffeeMachineApiUrl)     ;
  }
}