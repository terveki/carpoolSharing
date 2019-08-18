import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { CarService } from '../_services/car.service';
import { StatsByMonth } from '../_models/StatsByMonth';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {
  selectedMonth: string;
  monthNumber: number;
  stats: StatsByMonth[];
  days = [];
  carsInUse = [];
  chart;
  ctx;

  @ViewChild('canvasEl') canvasEl: ElementRef;
  /** Canvas 2d context */
  private context: CanvasRenderingContext2D;

  constructor(private alertify: AlertifyService, private carService: CarService) { }

  ngOnInit() {
    this.monthNumber = 0;
  }

  convertMonth() {
    switch (this.selectedMonth) {
      case 'January': {
        this.monthNumber = 1;
        break;
      }
      case 'February': {
        this.monthNumber = 2;
        break;
      }
      case 'March': {
        this.monthNumber = 3;
         break;
      }
      case 'April': {
        this.monthNumber = 4;
         break;
      }
      case 'May': {
        this.monthNumber = 5;
        break;
      }
      case 'June': {
        this.monthNumber = 6;
        break;
      }
      case 'July': {
        this.monthNumber = 7;
        break;
      }
      case 'August': {
        this.monthNumber = 8;
        break;
      }
      case 'September': {
        this.monthNumber = 9;
        break;
      }
      case 'October': {
        this.monthNumber = 10;
        break;
      }
      case 'November': {
        this.monthNumber = 11;
        break;
      }
      case 'December': {
        this.monthNumber = 12;
        break;
      }
        default: {
          this.monthNumber = 0;
          break;
        }
   }
  }

  onMonthChange() {
    this.convertMonth();
    if (this.monthNumber === 0) {
      this.alertify.error('Choose month');
      return;
    }

    this.carService.getCarStatisticsByMonth(this.monthNumber).subscribe((response: StatsByMonth[]) => {
      this.stats = response;
      this.stats.forEach(y => {
        this.days.push(y.day);
        this.carsInUse.push(y.noOfCarsInUse);
      });
    }, error => {
      this.alertify.error('Error while getting data :(');
      return;
    });
  }

  selectMonth() {
    this.showGraph();
    //TODO dinamicaly clear graph before rendering new one
  }

  showGraph() {
    const data = {
      labels: this.days,
      datasets: [{
        data: this.carsInUse,
        borderColor: '#3cba9f',
        fill: 'false'
      }]
    };

    const options = {
      legend: {display: false},
      scales: {xAxes: [{
                        display: true,
                        scaleLabel: {
                          display: true,
                          labelString: 'days of the month'
                        }
                      }],
               yAxes: [{
                        display: true,
                        scaleLabel: {
                          display: true,
                          labelString: 'cars in use'
                        },
                        ticks: {
                          beginAtZero: true,
                          steps: 1,
                          stepValue: 1,
                        }
                      }]
               }
    };

    this.ctx = document.getElementById('canvas');
    this.chart = new Chart(this.ctx, {
      type: 'line',
      data: data,
      options: options
    });
  }
}
