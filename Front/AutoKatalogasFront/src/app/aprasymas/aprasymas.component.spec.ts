import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AprasymasComponent } from './aprasymas.component';

describe('AprasymasComponent', () => {
  let component: AprasymasComponent;
  let fixture: ComponentFixture<AprasymasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AprasymasComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AprasymasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
