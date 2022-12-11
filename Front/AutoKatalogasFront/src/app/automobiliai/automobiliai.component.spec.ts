import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AutomobiliaiComponent } from './automobiliai.component';

describe('AutomobiliaiComponent', () => {
  let component: AutomobiliaiComponent;
  let fixture: ComponentFixture<AutomobiliaiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AutomobiliaiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AutomobiliaiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
