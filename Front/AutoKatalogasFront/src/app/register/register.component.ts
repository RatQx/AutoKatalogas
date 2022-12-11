import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { empty } from 'rxjs';
import { User } from '../models/user';
import { AlertService } from '../services/alert.service';
import { UserService } from '../services/user.service';
import { RegisterRequest } from '../types/autokatalogas.types';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  isSuccessful = false;
  isSignUpFailed = false;
  errorMessage = '';

  constructor(private userSerive: UserService, private router: Router) { }

  public form = new FormGroup({
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required]),
  });
  ngOnInit(): void {
  }

  onSubmit(){
    //console.log(this.form.value);
    this.userSerive.register(this.form.value as RegisterRequest).subscribe({
      next: () => {
        this.router.navigate(['/login']);
      },
    });
  }
}
