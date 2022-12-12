import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Automobiliai } from '../models/automobiliai';
import { AutomobiliaiService } from '../services/automobiliai.service';

@Component({
  selector: 'app-automobiliai-form',
  templateUrl: './automobiliai-form.component.html',
  styleUrls: ['./automobiliai-form.component.scss'],
})
export class AutomobiliaiFormComponent implements OnInit {
  populateFormSubscription: Subscription;
  public addAutoForm!: FormGroup;
  public autos!: Automobiliai;
  submitButton = '';
  constructor(
    private router : Router,
    private activatedRoute: ActivatedRoute,
    private fb: FormBuilder,
    private autoService: AutomobiliaiService
  ) {
    this.populateFormSubscription = this.autoService
      .sendPopulateForm()
      .subscribe((data) => {
        this.populateForm(data);
      });
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe({
      next:(param) => {
       const id = param['id']
       //console.log(id);
       this.autoService.getAuto(id).subscribe({
        next:(auto)=> {
          this.autos= auto;
          this.addAutoForm.patchValue(auto);
          this.submitButton = 'Update Record';
        }
       })
      }
    })
    this.emptyForm();
  }

  emptyForm() {
    this.submitButton = 'Add Record';
    this.addAutoForm = this.fb.group({
      id: [0],
      vin: ['', [Validators.required]],
      marke: ['', [Validators.required]],
      model: ['', [Validators.required]],
      production_date: ['', [Validators.required]],
    });
  }

  get registerFormControl(): { [key: string]: AbstractControl } {
    return this.addAutoForm.controls;
  }

  onSubmit() {
    if (this.addAutoForm.value.id > 0) {
      this.autoService
        .updateAuto(this.addAutoForm.value)
        .subscribe((data) => {
          this.autoService.updateList();
          this.emptyForm();
          this.router.navigateByUrl('/automobiliai');
        });
    } else {
      this.autoService
        .addRecord(this.addAutoForm.value)
        .subscribe((data) => {
          this.autoService.updateList();
          this.emptyForm();
          this.router.navigateByUrl('/automobiliai');
        });
    }
  }

  populateForm(id: number) {
    this.submitButton = 'Update Record';
    this.autoService.getAuto(id).subscribe((record) => {
      this.autos = record as Automobiliai;
      this.addAutoForm = this.fb.group({
        id: this.autos.id,
        vin: this.autos.vin,
        marke: this.autos.marke,
        model: this.autos.model,
        production_date: this.autos.production_date,
        userid: this.autos.userid,
      });
    });
  }
}
