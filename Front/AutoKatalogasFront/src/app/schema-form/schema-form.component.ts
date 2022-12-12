import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Aprasymas } from '../models/aprasymas';
import { Schema } from '../models/schema';
import { AprasymasService } from '../services/aprasymas.service';
import { SchemaService } from '../services/schema.service';

@Component({
  selector: 'app-schema-form',
  templateUrl: './schema-form.component.html',
  styleUrls: ['./schema-form.component.scss']
})
export class SchemaFormComponent implements OnInit {

  populateFormSubscription: Subscription;
  public addPartForm!: FormGroup;
  public schema!: Schema;
  public DROPDOWN_LIST: Aprasymas[] = [];
  public descId: number[] = [];
  submitButton = '';
  constructor(
    private router : Router,
    private activatedRoute: ActivatedRoute,
    private fb: FormBuilder,
    private schemaService: SchemaService,
    private aprasymasService: AprasymasService
  ) {
    this.populateFormSubscription = this.schemaService
      .sendPopulateForm()
      .subscribe((data) => {
        this.populateForm(data);
      });
      this.aprasymasService.getAllAprasymai().subscribe({
        next: (desc) =>{
          this.DROPDOWN_LIST = desc;
          this.DROPDOWN_LIST.forEach(element => {
            this.descId.push(element.id);
          });
        }
      }
      );
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe({
      next:(param) => {
       const id = param['id']
       this.schemaService.getSchema(id).subscribe({
        next:(desq)=> {
          this.schema= desq;
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
      img: ['', [Validators.required]],
      AprasymasId: ['', [Validators.required]],
    });
  }

  get registerFormControl(): { [key: string]: AbstractControl } {
    return this.addPartForm.controls;
  }

  onSubmit() {
    if (this.addPartForm.value.id > 0) {
      this.schemaService
        .updateSchema(this.addPartForm.value)
        .subscribe((data) => {
          this.router.navigateByUrl('/schema');
          // this.schemaService.updateList();
          // this.emptyForm();
        });
    } else {
      console.log(this.addPartForm.value);
      this.schemaService
        .addRecord(this.addPartForm.value)
        .subscribe((data) => {
          this.router.navigateByUrl('/schema');
          // this.schemaService.updateList();
          // this.emptyForm();
        });
    }
  }

  populateForm(id: number) {
    this.submitButton = 'Update Record';
    this.schemaService.getSchema(id).subscribe((record) => {
      this.schema = record as Schema;
      this.addPartForm = this.fb.group({
        id: this.schema.id,
        img: this.schema.img,
        AprasymasId: this.schema.AprasymasId
      });
    });
  }

}
