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
import { Dalys } from '../models/dalys';
import { AutomobiliaiService } from '../services/automobiliai.service';
import { DalysService } from '../services/dalys.service';

@Component({
  selector: 'app-dalys-form',
  templateUrl: './dalys-form.component.html',
  styleUrls: ['./dalys-form.component.scss'],
})
export class DalysFormComponent implements OnInit {
  populateFormSubscription: Subscription;
  public addPartForm!: FormGroup;
  public dalys!: Dalys;
  public DROPDOWN_LIST: Automobiliai[] = [];
  public autosId: number[] = [];
  submitButton = '';
  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private fb: FormBuilder,
    private dalysService: DalysService,
    private autoService: AutomobiliaiService
  ) {
    this.populateFormSubscription = this.dalysService
      .sendPopulateForm()
      .subscribe((data) => {
        this.populateForm(data);
      });
    this.autoService.getAllAutos().subscribe({
      next: (auto) =>{
        this.DROPDOWN_LIST = auto;
        this.DROPDOWN_LIST.forEach(element => {
          this.autosId.push(element.id);
        });
      }
    }
    );
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe({
      next: (param) => {
        const id = param['id'];
        this.dalysService.getDalis(id).subscribe({
          next: (auto) => {
            this.dalys = auto;
            this.addPartForm.patchValue(auto);
            this.submitButton = 'Update Record';
          },
        });
      },
    });
    this.emptyForm();
  }

  emptyForm() {
    this.submitButton = 'Add Record';
    this.addPartForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      material: ['', [Validators.required]],
      placement: ['', [Validators.required]],
      automobilioId: ['', [Validators.required]],
    });
  }

  get registerFormControl(): { [key: string]: AbstractControl } {
    return this.addPartForm.controls;
  }

  onSubmit() {
    if (this.addPartForm.value.id > 0) {
      this.dalysService
        .updateDalis(this.addPartForm.value)
        .subscribe((data) => {
          this.dalysService.updateList();
          this.emptyForm();
          this.router.navigateByUrl('/dalys');
        });
    } else {
      console.log(this.addPartForm.value);
      this.dalysService.addRecord(this.addPartForm.value).subscribe((data) => {
        this.dalysService.updateList();
        this.emptyForm();
        this.router.navigateByUrl('/dalys');
      });
    }
  }

  populateForm(id: number) {
    this.submitButton = 'Update Record';
    this.dalysService.getDalis(id).subscribe((record) => {
      this.dalys = record as Dalys;
      this.addPartForm = this.fb.group({
        id: this.dalys.id,
        name: this.dalys.name,
        material: this.dalys.material,
        placement: this.dalys.placement,
        automobilioId: this.dalys.automobilioId,
      });
    });
  }
}
