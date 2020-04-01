import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GrapesComponent } from './grapes.component';

describe('GrapesComponent', () => {
  let component: GrapesComponent;
  let fixture: ComponentFixture<GrapesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GrapesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GrapesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
