import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Car } from '../_models/car';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCars(): Observable<Car[]> {
    return this.http.get<Car[]>(this.baseUrl + 'cars');
  }

  getCar(id): Observable<Car> {
    return this.http.get<Car>(this.baseUrl + 'cars/' + id);
  }

  getAvailableCars(timesDates): Observable<Car[]> {
    return this.http.post<Car[]>(this.baseUrl + 'cars/getAvailableCars/', timesDates);
  }
}
