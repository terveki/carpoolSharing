import { Component, OnInit, Input } from '@angular/core';
import { Ride } from 'src/app/_models/ride';

@Component({
  selector: 'app-rides-card',
  templateUrl: './rides-card.component.html',
  styleUrls: ['./rides-card.component.css']
})
export class RidesCardComponent implements OnInit {
  @Input() ride: Ride;

  constructor() { }

  ngOnInit() {
  }

}
