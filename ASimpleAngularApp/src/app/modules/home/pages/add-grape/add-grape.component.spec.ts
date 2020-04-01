import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddGrapeComponent } from './add-grape.component';

describe('AddGrapeComponent', () => {
  let component: AddGrapeComponent;
  let fixture: ComponentFixture<AddGrapeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddGrapeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddGrapeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
