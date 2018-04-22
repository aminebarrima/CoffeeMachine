import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Badge} from '../Dto/Badge';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';
import { environment } from '../../environments/environment';

@Injectable()
export class BadgeService { 
  
  private CoffeeMachineApiUrl= environment.API_URL+'/api/Badges'; 
  constructor( private http: HttpClient) { }

  getBadges (): Observable<Badge[]> {
    return this.http.get<Badge[]>(this.CoffeeMachineApiUrl)     ;
  }
}