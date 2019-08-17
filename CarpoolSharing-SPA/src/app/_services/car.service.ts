import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Car } from '../_models/car';
import { Stats } from '../_models/stats';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCars(): Observable<Car[]> {
    return this.http.get<Car[]>(this.baseUrl + 'cars/getCars');
  }

  getCar(id: number): Observable<Car> {
    return this.http.get<Car>(this.baseUrl + 'cars/' + id);
  }

  getAvailableCars(timesDates: any): Observable<Car[]> {
    return this.http.post<Car[]>(this.baseUrl + 'cars/getAvailableCars/', timesDates);
  }

  getCarStatistics(carId: number): Observable<Stats[]> {
    return this.http.get<Stats[]>(this.baseUrl + 'cars/GetCarStatistics/' + carId);
  }
}
