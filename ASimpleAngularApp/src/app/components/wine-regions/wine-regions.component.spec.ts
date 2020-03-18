import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WineRegionsComponent } from './wine-regions.component';

describe('WineRegionsComponent', () => {
  let component: WineRegionsComponent;
  let fixture: ComponentFixture<WineRegionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WineRegionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WineRegionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
