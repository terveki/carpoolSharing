import { Component, OnInit } from '@angular/core';
import { Ride } from 'src/app/_models/ride';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-rides-list',
  templateUrl: './rides-list.component.html',
  styleUrls: ['./rides-list.component.css']
})
export class RidesListComponent implements OnInit {
  rides: Ride[];

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.rides = data['rides'];
    });
  }
}
