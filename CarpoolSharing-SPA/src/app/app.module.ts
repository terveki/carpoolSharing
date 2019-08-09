import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ValueComponent } from './value/value.component';
import { NavComponent } from './nav/nav.component';
import { AlertifyService } from './_services/alertify.service';
import { CarsComponent } from './cars/cars.component';
import { EmployeesComponent } from './employees/employees.component';
import { RidesListComponent } from './rides/rides-list/rides-list.component';
import { RidesCardComponent } from './rides/rides-card/rides-card.component';

import { HomeComponent } from './home/home.component';
import { appRoutes } from './routes';
import { CarService } from './_services/car.service';
import { RideService } from './_services/ride.service';
import { EmployeeService } from './_services/employee.service';
import { RidesDetailComponent } from './rides/rides-detail/rides-detail.component';
import { RideListResolver } from './_resolvers/ride-list.resolver';
import { RideDetailResolver } from './_resolvers/ride-detail.resolver';

@NgModule({
   declarations: [
      AppComponent,
      ValueComponent,
      NavComponent,
      CarsComponent,
      EmployeesComponent,
      RidesListComponent,
      HomeComponent,
      RidesCardComponent,
      RidesDetailComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
      AlertifyService,
      CarService,
      RideService,
      EmployeeService,
      RideListResolver,
      RideDetailResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
