import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CapitalViewModel } from './capitals.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CapitalsService {

  constructor(private http: HttpClient) { }

  getCapitalsByCountry(country: string) : Observable<CapitalViewModel[]>{
    return this.http.get<CapitalViewModel[]>(`${environment.apiUrl}countries/${country}/capitals`)
  }
}
