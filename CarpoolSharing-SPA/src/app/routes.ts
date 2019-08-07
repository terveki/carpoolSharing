import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CarsComponent } from './cars/cars.component';
import { EmployeesComponent } from './employees/employees.component';
import { RidesComponent } from './rides/rides.component';

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'cars', component: CarsComponent },
    { path: 'employees', component: EmployeesComponent },
    { path: 'rides', component: RidesComponent },
    { path: '**', redirectTo: 'home', pathMatch: 'full' }
];
