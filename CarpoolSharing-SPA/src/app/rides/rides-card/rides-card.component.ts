import { Component, OnInit, Input } from '@angular/core';
import { Ride } from 'src/app/_models/ride';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { RideService } from 'src/app/_services/ride.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-rides-card',
  templateUrl: './rides-card.component.html',
  styleUrls: ['./rides-card.component.css']
})
export class RidesCardComponent implements OnInit {
  @Input() ride: Ride;

  constructor( private alertify: AlertifyService, private rideService: RideService,
              private router: Router) { }

  ngOnInit() {
  }

  deleteRide(rideId: number) {
    this.alertify.confirm('Are you sure you want to delete this ride?', () => {
      this.rideService.deleteRide(rideId).subscribe(() => {
        this.alertify.success('Ride has been deleted');
        this.router.navigate(['/rides']).then(() => {
          window.location.reload();
        });
      }, error => {
        this.alertify.error('Failed to delete the ride');
      });
    });
  }

}
