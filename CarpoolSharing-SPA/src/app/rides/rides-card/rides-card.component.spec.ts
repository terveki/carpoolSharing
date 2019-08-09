/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { RidesCardComponent } from './rides-card.component';

describe('RidesCardComponent', () => {
  let component: RidesCardComponent;
  let fixture: ComponentFixture<RidesCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RidesCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RidesCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
