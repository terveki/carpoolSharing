import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CarsComponent } from './cars/cars-list/cars.component';
import { EmployeesComponent } from './employees/employees.component';
import { RidesListComponent } from './rides/rides-list/rides-list.component';
import { RidesDetailComponent } from './rides/rides-detail/rides-detail.component';
import { RideListResolver } from './_resolvers/ride-list.resolver';
import { RideDetailResolver } from './_resolvers/ride-detail.resolver';
import { RidesEditComponent } from './rides/rides-edit/rides-edit.component';
import { RidesAddComponent } from './rides/rides-add/rides-add.component';
import { CarsStatisticsComponent } from './cars/cars-statistics/cars-statistics.component';
import { CarStatsResolver } from './_resolvers/car-stats.resolver';
import { StatisticsComponent } from './statistics/statistics.component';
import { CarStatByMonthResolver } from './_resolvers/car-stats-by-month.resolver';

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'cars', component: CarsComponent },
    { path: 'cars/statistics/:id', component: CarsStatisticsComponent, resolve: {stats: CarStatsResolver}},
    { path: 'employees', component: EmployeesComponent },
    { path: 'rides', component: RidesListComponent, resolve: {rides: RideListResolver} },
    { path: 'rides/GetRide/:id', component: RidesDetailComponent, resolve: {ride: RideDetailResolver} },
    { path: 'rides/:id/edit', component: RidesEditComponent },
    { path: 'add', component: RidesAddComponent },
    { path: 'stats', component: StatisticsComponent },
    { path: '**', redirectTo: 'home', pathMatch: 'full' }
];
