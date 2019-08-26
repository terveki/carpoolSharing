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
    return this.http.get<Ride[]>(this.baseUrl + 'rides/getRides');
  }

  getRide(id: number): Observable<Ride> {
    return this.http.get<Ride>(this.baseUrl + 'rides/GetRide/' + id);
  }

  addNewRide(ride: Ride) {
    console.log('sending ride: ' + ride);
    return this.http.post(this.baseUrl + 'rides/addNewRide', ride);
  }

  deleteRide(rideId: number) {
    return this.http.delete(this.baseUrl + 'rides/DeleteRide/' + rideId);
  }

  updateRide(ride: Ride) {
    return this.http.put(this.baseUrl + 'rides/UpdateRide/' + ride.rideId, ride);
  }
}
