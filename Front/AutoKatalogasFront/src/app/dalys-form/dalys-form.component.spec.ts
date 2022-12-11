import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DalysFormComponent } from './dalys-form.component';

describe('DalysFormComponent', () => {
  let component: DalysFormComponent;
  let fixture: ComponentFixture<DalysFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DalysFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DalysFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
