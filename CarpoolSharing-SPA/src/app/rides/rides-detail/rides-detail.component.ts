import { Component, OnInit } from '@angular/core';
import { RideService } from 'src/app/_services/ride.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { Ride } from 'src/app/_models/ride';

@Component({
  selector: 'app-rides-detail',
  templateUrl: './rides-detail.component.html',
  styleUrls: ['./rides-detail.component.css']
})
export class RidesDetailComponent implements OnInit {
  ride: Ride;

  constructor(private rideService: RideService, private alertify: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.ride = data['ride'];
    });
  }
}
