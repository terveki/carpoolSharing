import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Ride } from '../_models/ride';
import { RideService } from '../_services/ride.service';
import { AlertifyService } from '../_services/alertify.service';
import { catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';

@Injectable()
export class RideDetailResolver implements Resolve<Ride> {
    constructor(private rideService: RideService, private router: Router,
             private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Ride> {
        return this.rideService.getRide(route.params['id']).pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['/rides']);
                return of(null);
            })
        );
    }
}