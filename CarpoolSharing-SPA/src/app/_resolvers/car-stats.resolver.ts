import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Ride } from '../_models/ride';
import { AlertifyService } from '../_services/alertify.service';
import { catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { Stats } from '../_models/stats';
import { CarService } from '../_services/car.service';

@Injectable()
export class CarStatsResolver implements Resolve<Stats[]> {
    constructor(private carService: CarService, private router: Router,
             private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Stats[]> {
        return this.carService.getCarStatistics(route.params['id']).pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['/cars']);
                return of(null);
            })
        );
    }
}
