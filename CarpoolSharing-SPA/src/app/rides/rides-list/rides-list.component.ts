import { Component, OnInit } from '@angular/core';
import { Ride } from 'src/app/_models/ride';
import { RideService } from 'src/app/_services/ride.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-rides-list',
  templateUrl: './rides-list.component.html',
  styleUrls: ['./rides-list.component.css']
})
export class RidesListComponent implements OnInit {
  rides: Ride[];

  constructor(private rideService: RideService, private alertify: AlertifyService,
     private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.rides = data['rides'];
    });
  }
}
