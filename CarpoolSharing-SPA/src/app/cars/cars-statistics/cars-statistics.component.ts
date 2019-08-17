import { Component, OnInit } from '@angular/core';
import { Stats } from 'src/app/_models/stats';
import { ActivatedRoute } from '@angular/router';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-cars-statistics',
  templateUrl: './cars-statistics.component.html',
  styleUrls: ['./cars-statistics.component.css']
})
export class CarsStatisticsComponent implements OnInit {
  stats: Stats[];
  month = [];
  daysInUse = [];
  chart = [];

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.stats = data['stats'];
    });

    this.stats.forEach(y => {
      this.month.push(y.month);
      this.daysInUse.push(y.noOfDaysInUse);
    });
    this.doChart();
  }

  doChart() {
    const data = {
      labels: this.month,
      datasets: [{
        data: this.daysInUse,
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
                          labelString: 'months'
                        }
                      }],
               yAxes: [{
                        display: true,
                        scaleLabel: {
                          display: true,
                          labelString: 'days in use'
                        },
                        ticks: {
                          beginAtZero: true,
                          steps: 1,
                          stepValue: 1,
                        }
                      }]
               }
    };

    const ctx = document.getElementById('canvas');
    console.log('ctx je ' + ctx);
    this.chart = new Chart(ctx, {
      type: 'line',
      data: data,
      options: options
    });
  }
}
