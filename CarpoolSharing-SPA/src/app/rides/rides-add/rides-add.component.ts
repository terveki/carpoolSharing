import { Component, OnInit } from '@angular/core';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Car } from 'src/app/_models/car';
import { CarService } from 'src/app/_services/car.service';
import { DatesToBeSend } from 'src/app/_models/DatesToBeSend';
import { Employee } from 'src/app/_models/employee';
import { EmployeeService } from 'src/app/_services/employee.service';
import { Ride } from 'src/app/_models/ride';
import { RideService } from 'src/app/_services/ride.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-rides-add',
  templateUrl: './rides-add.component.html',
  styleUrls: ['./rides-add.component.css']
})
export class RidesAddComponent implements OnInit {
  minDate: Date;
  daterangepickerModel: Date[];
  cars: Car[];
  employees: Employee[];
  datesToBeSend: DatesToBeSend = {};
  ride: Ride = {};
  driverExist = false;
  dateEntered = false;
  theCar: Car;

  constructor(private alertify: AlertifyService, private carService: CarService,
        private employeeService: EmployeeService, private rideService: RideService,
        private router: Router) {
    this.minDate = new Date();
    this.minDate.setDate(this.minDate.getDate() + 1);
    this.ride.employeeRides = [];
  }

  ngOnInit() {
  }

  chooseTime() {
    if (this.daterangepickerModel === undefined) {
      this.alertify.error('Not valid datetime');
      return;
    }

    this.datesToBeSend.startDate = this.daterangepickerModel[0].toJSON();
    this.datesToBeSend.endDate = this.daterangepickerModel[1].toJSON();
    this.ride.startDate = this.daterangepickerModel[0].toJSON();
    this.ride.endDate = this.daterangepickerModel[1].toJSON();

    this.carService.getAvailableCars(this.datesToBeSend).subscribe((cars: Car[]) => {
      this.cars = cars;
      if (this.cars.length === 0) {
        this.alertify.error('No available cars for that date');
        return;
      }
    }, error => {
      this.alertify.error(error);
    });

    this.employeeService.getAvailableEmployees(this.datesToBeSend).subscribe((employees: Employee[]) => {
      this.employees = employees;
      if (this.employees.length === 0) {
        this.alertify.error('No available employees for that date');
        return;
      }
    }, error => {
      this.alertify.error(error);
    });

    this.dateEntered = true;
  }

  onEmployeeChange(event, emp) {
    if (event.target.checked) {
      this.ride.employeeRides.push({employeeId: emp.employeeId, isDriver: emp.isDriver});
    }
    if (!event.target.checked) {
      this.ride.employeeRides = this.ride.employeeRides.filter(e => e.employeeId !== emp.employeeId);
    }
  }

  checkForDriver() {
    for (const empl of this.ride.employeeRides) {
      if (empl.isDriver === true) {
        this.driverExist = true;
      }
    }
  }

  checkNumberOfSeats() {
    const theCar = this.cars.find(c => {
      return c.carId == this.ride.carId;
    });

    if ( this.ride.employeeRides.length > theCar.noOfSeats) {
      this.alertify.error('Too many people for that car');
      return false;
    }

    return true;
  }

  checkAllIn(): boolean {
    this.checkForDriver();
    if (this.driverExist === false) {
      this.alertify.error('At least one of the emloyees must be a driver');
      return false;
    }
    if (this.ride.carId === undefined || this.ride.startLocation === undefined
          || this.ride.endLocation === undefined ) {
            this.alertify.error('All fields must be filled');
            return false;
          }
    if (this.checkNumberOfSeats() === false) {
      return false;
    }
    return true;
  }

  addNewRide() {
    if (this.checkAllIn() === false) {
      console.log('Something is wrong with your input');
    } else {
      this.rideService.addNewRide(this.ride).subscribe(() => {
        this.alertify.success('New ride added');
        this.router.navigate(['/rides']);
      }, error => {
        this.alertify.error(error);
      });
    }
  }
}
