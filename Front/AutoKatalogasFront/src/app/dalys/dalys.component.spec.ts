import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DalysComponent } from './dalys.component';

describe('DalysComponent', () => {
  let component: DalysComponent;
  let fixture: ComponentFixture<DalysComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DalysComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DalysComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
