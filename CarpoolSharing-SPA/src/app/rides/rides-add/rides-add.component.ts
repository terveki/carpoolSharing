import { Component, OnInit } from '@angular/core';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Car } from 'src/app/_models/car';
import { CarService } from 'src/app/_services/car.service';
import { DatesToBeSend } from 'src/app/_models/DatesToBeSend';
import { Employee } from 'src/app/_models/employee';
import { EmployeeService } from 'src/app/_services/employee.service';
import { Ride } from 'src/app/_models/ride';

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

  constructor(private alertify: AlertifyService, private carService: CarService,
        private employeeService: EmployeeService) {
    this.minDate = new Date();
    this.minDate.setDate(this.minDate.getDate() + 1);
  }

  ngOnInit() {
  }

  chooseTime() {

    this.datesToBeSend.startDate = this.daterangepickerModel[0].toJSON();
    this.datesToBeSend.endDate = this.daterangepickerModel[1].toJSON();

    this.carService.getAvailableCars(this.datesToBeSend).subscribe((cars: Car[]) => {
      this.cars = cars;
    }, error => {
      this.alertify.error(error);
    });

    this.employeeService.getAvailableEmployees(this.datesToBeSend).subscribe((employees: Employee[]) => {
      this.employees = employees;
    }, error => {
      this.alertify.error(error);
    });
  }

  onChange() {
    this.alertify.message('pomalo auto: ' + this.ride.carId);
  }
 // TODO: fetch selected car and employees
 // TODO2: map dates to json and send it to API
  addNewRide() {
    this.alertify.message('pomalo');
  }
}
