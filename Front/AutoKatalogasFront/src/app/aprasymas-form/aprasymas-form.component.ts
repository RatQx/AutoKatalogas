import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Aprasymas } from '../models/aprasymas';
import { Dalys } from '../models/dalys';
import { AprasymasService } from '../services/aprasymas.service';
import { DalysService } from '../services/dalys.service';

@Component({
  selector: 'app-aprasymas-form',
  templateUrl: './aprasymas-form.component.html',
  styleUrls: ['./aprasymas-form.component.scss']
})
export class AprasymasFormComponent implements OnInit {

  populateFormSubscription: Subscription;
  public addPartForm!: FormGroup;
  public aprasymai!: Aprasymas;
  public DROPDOWN_LIST: Dalys[] = [];
  public dalysId: number[] = [];
  submitButton = '';
  constructor(
    private router : Router,
    private activatedRoute: ActivatedRoute,
    private fb: FormBuilder,
    private aprasymaiService: AprasymasService,
    private dalysService: DalysService
  ) {
    this.populateFormSubscription = this.aprasymaiService
      .sendPopulateForm()
      .subscribe((data) => {
        this.populateForm(data);
      });
      this.dalysService.getAllDalys().subscribe({
        next: (parts) =>{
          this.DROPDOWN_LIST = parts;
          this.DROPDOWN_LIST.forEach(element => {
            this.dalysId.push(element.id);
          });
        }
      }
      );
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe({
      next:(param) => {
       const id = param['id']
       this.aprasymaiService.getAprasymas(id).subscribe({
        next:(desq)=> {
          this.aprasymai= desq;
          this.addPartForm.patchValue(desq);
          this.submitButton = 'Update Record';
        }
       })
      }
    })
    this.emptyForm();
  }

  emptyForm() {
    this.submitButton = 'Add Record';
    this.addPartForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      type: ['', [Validators.required]],
      description: ['', [Validators.required]],
      dalisId: ['', [Validators.required]],
    });
  }

  get registerFormControl(): { [key: string]: AbstractControl } {
    return this.addPartForm.controls;
  }

  onSubmit() {
    if (this.addPartForm.value.id > 0) {
      this.aprasymaiService
        .updateAprasymas(this.addPartForm.value)
        .subscribe((data) => {
          this.aprasymaiService.updateList();
          this.emptyForm();
          this.router.navigateByUrl('/aprasymas');
        });
    } else {
      console.log(this.addPartForm.value);
      this.aprasymaiService
        .addRecord(this.addPartForm.value)
        .subscribe((data) => {
          this.aprasymaiService.updateList();
          this.emptyForm();
          this.router.navigateByUrl('/aprasymas');
        });
    }
  }

  populateForm(id: number) {
    this.submitButton = 'Update Record';
    this.aprasymaiService.getAprasymas(id).subscribe((record) => {
      this.aprasymai = record as Aprasymas;
      this.addPartForm = this.fb.group({
        id: this.aprasymai.id,
        name: this.aprasymai.name,
        type: this.aprasymai.type,
        description: this.aprasymai.description,
        dalisId: this.aprasymai.dalisId
      });
    });
  }

}
