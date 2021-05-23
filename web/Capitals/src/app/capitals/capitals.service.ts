import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CapitalViewModel } from './capitals.model';
import { Observable,  of,  Subject } from 'rxjs';
import { catchError, switchMap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CapitalsService {

  countrySubject: Subject<string> = new Subject<string>();
  country$ = this.countrySubject.asObservable().pipe(
    switchMap(country => 
      this.getCapitalsByCountry(country).pipe(
        catchError(error => of([]))
      )
    )
  );

  constructor(private http: HttpClient) { }

  getCapitalsByCountry(country: string) : Observable<CapitalViewModel[]>{
    return this.http.get<CapitalViewModel[]>(`${environment.apiUrl}countries/${country}/capitals`)
  }

  setCountry(country: string){
    this.countrySubject.next(country);
  }
}
