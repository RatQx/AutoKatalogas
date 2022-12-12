import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';
import { LoginRequest } from '../types/autokatalogas.types';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {



  constructor(private userSerive: UserService, private router: Router) { }
  public form = new FormGroup({
    username: new FormControl('',[Validators.required]),
    password: new FormControl('',[Validators.required])
  });
  ngOnInit(): void {

  }

  onSubmit(){
    //console.log(this.form.value);
    try{
      this.userSerive.login(this.form.value as LoginRequest).subscribe({
        next: (data)=>{
          console.log(data)
          this.router.navigate(['/home']).then(() => {
            window.location.reload();
          });
        }
      });
    }
    catch{

    }
  }

}
