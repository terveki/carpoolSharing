import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {
  cars: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getCars();
  }

  getCars() {
    this.http.get('http://localhost:5001/api/cars').subscribe(response => {
      this.cars = response;
    }, error => {
      console.log(error);
    });
  }
}
