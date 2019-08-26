import { Component, OnInit } from '@angular/core';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Ride } from 'src/app/_models/ride';
import { Car } from 'src/app/_models/car';
import { CarService } from 'src/app/_services/car.service';
import { DatesToBeSend } from 'src/app/_models/DatesToBeSend';
import { Employee } from 'src/app/_models/employee';
import { EmployeeService } from 'src/app/_services/employee.service';
import { RideService } from 'src/app/_services/ride.service';

@Component({
  selector: 'app-rides-edit',
  templateUrl: './rides-edit.component.html',
  styleUrls: ['./rides-edit.component.css']
})
export class RidesEditComponent implements OnInit {
  ride: Ride;
  cars: Car[];
  datesToBeSend: DatesToBeSend = {};
  employees: Employee[];
  driverExist = false;

  constructor(private route: ActivatedRoute, private alertify: AlertifyService,
              private carService: CarService, private employeeService: EmployeeService,
              private rideService: RideService, private router: Router) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.ride = data['ride'];
    });

    this.datesToBeSend.startDate = this.ride.startDate;
    this.datesToBeSend.endDate = this.ride.endDate;

    this.carService.getAvailableCars(this.datesToBeSend).subscribe((cars: Car[]) => {
    this.cars = cars;
    if (this.cars.length === 0) {
      this.alertify.error('No available cars for that date');
      return;
    }
    this.cars.push(this.ride.car);
    }, error => {
      this.alertify.error(error);
    });

    this.employeeService.getAvailableEmployees(this.datesToBeSend).subscribe((employees: Employee[]) => {
      this.employees = employees;
      if (this.employees.length === 0) {
        this.alertify.error('No available employees for that date');
        return;
      }
      this.ride.employees.forEach(empl => {
        this.employees.push(empl);
      });
    }, error => {
      this.alertify.error(error);
    });

    this.ride.carId = this.ride.car.carId;
  }

  isSelectedEmployee (employee: Employee): boolean {
    let result = false;
    this.ride.employees.forEach(empl => {
                if (empl === employee) {
                  result = true;
                }
              });
    return result;
  }

  onEmployeeChange(event, emp) {
    if (event.target.checked) {
      this.ride.employees.push({employeeId: emp.employeeId, isDriver: emp.isDriver, name: emp.name});
    }
    if (!event.target.checked) {
      this.ride.employees = this.ride.employees.filter(e => e.employeeId !== emp.employeeId);
    }
  }

  checkForDriver() {
    for (const empl of this.ride.employees) {
      if (empl.isDriver === true) {
        this.driverExist = true;
      }
    }
  }

  checkNumberOfSeats() {
    const theCar = this.cars.find(c => {
      return c.carId == this.ride.carId;
    });

    if ( this.ride.employees.length > theCar.noOfSeats) {
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
    if (this.ride.carId === undefined || this.ride.startLocation === ""
          || this.ride.endLocation === "" ) {
            this.alertify.error('All fields must be filled');
            return false;
          }
    if (this.checkNumberOfSeats() === false) {
      return false;
    }
    return true;
  }

  editRide() {
    this.driverExist = false;

    if (this.checkAllIn() === false) {
      console.log('Something is wrong with your input');
    } else {
      this.rideService.updateRide(this.ride).subscribe(next => {
        this.alertify.success('Ride updated successfully');
        this.router.navigate(['/rides/GetRide/' + this.ride.rideId]);
      }, error => {
        this.alertify.error(error);
      });
    }

  }
}
