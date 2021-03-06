import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AlertifyService } from './_services/alertify.service';
import { CarsComponent } from './cars/cars-list/cars.component';
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
import { RidesAddComponent } from './rides/rides-add/rides-add.component';
import { RidesEditComponent } from './rides/rides-edit/rides-edit.component';
import { CarsStatisticsComponent } from './cars/cars-statistics/cars-statistics.component';
import { CarStatsResolver } from './_resolvers/car-stats.resolver';
import { StatisticsComponent } from './statistics/statistics.component';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      CarsComponent,
      CarsStatisticsComponent,
      EmployeesComponent,
      RidesListComponent,
      HomeComponent,
      RidesCardComponent,
      RidesDetailComponent,
      RidesEditComponent,
      RidesAddComponent,
      StatisticsComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      RouterModule.forRoot(appRoutes),
      FormsModule,
      BrowserAnimationsModule,
      BsDatepickerModule.forRoot()
   ],
   providers: [
      AlertifyService,
      CarService,
      RideService,
      EmployeeService,
      RideListResolver,
      RideDetailResolver,
      CarStatsResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
