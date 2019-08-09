import { Component, OnInit } from '@angular/core';
import { Car } from '../_models/car';
import { CarService } from '../_services/car.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {
  cars: Car[];

  constructor(private carService: CarService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadcars();
  }

  loadcars() {
    this.carService.getCars().subscribe((cars: Car[]) => {
      this.cars = cars;
    }, error => {
      this.alertify.error(error);
    });
  }
}
