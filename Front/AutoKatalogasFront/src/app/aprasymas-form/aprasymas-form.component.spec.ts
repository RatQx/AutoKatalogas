import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AprasymasFormComponent } from './aprasymas-form.component';

describe('AprasymasFormComponent', () => {
  let component: AprasymasFormComponent;
  let fixture: ComponentFixture<AprasymasFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AprasymasFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AprasymasFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
