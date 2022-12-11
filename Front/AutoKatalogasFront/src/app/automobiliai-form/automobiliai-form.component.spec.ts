import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AutomobiliaiFormComponent } from './automobiliai-form.component';

describe('AutomobiliaiFormComponent', () => {
  let component: AutomobiliaiFormComponent;
  let fixture: ComponentFixture<AutomobiliaiFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AutomobiliaiFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AutomobiliaiFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
