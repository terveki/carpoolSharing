import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Ride } from '../_models/ride';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RideService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getRides(): Observable<Ride[]> {
    return this.http.get<Ride[]>(this.baseUrl + 'rides');
  }

  getRide(id): Observable<Ride> {
    return this.http.get<Ride>(this.baseUrl + 'rides/' + id);
  }


}
