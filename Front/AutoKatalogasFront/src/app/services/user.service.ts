import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import {
  LoginRequest,
  LoginResponse,
  RegisterRequest,
} from '../types/autokatalogas.types';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};

@Injectable({
  providedIn: 'root',
})
export class UserService {
  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http: HttpClient, private router: Router) {}
  public isAuthenticated: boolean = false;
  public isAdmin: boolean = false;
  public isUser: boolean = false;
  public roles!: string;
  public ss: string = "";
  public user: string [] = [];
  private readonly TokenValidInMinutes: number = 60;
  readonly storage = 'autokatalogas';

  register(req: RegisterRequest) {
    return this.http.post(this.baseApiUrl + 'api/register', req);
  }

  delete(id: number) {
    return this.http.delete('users/${id}');
  }

  login(req: LoginRequest) {
    return this.http
      .post<LoginResponse>(this.baseApiUrl + 'api/login', req)
      .pipe(
        tap({
          next: (response: { accessToken: string }) => {
            localStorage.setItem(this.storage, response.accessToken);
            console.log(localStorage.getItem(this.storage));
            this.isAuthenticated = true;
          },
        })
      );
  }

  logout() {
    localStorage.removeItem(this.storage);
    this.isAuthenticated = false;
  }

  public isUserAdmin(): boolean{
    return this.isAdmin;
  }

  public isUserValid(): boolean{
    return this.isUser;
  }

  public getToken(): string | null {
    return localStorage.getItem(this.storage);
  }

  public validateSession(): void {
    const token = this.getToken();
    if (!token) {
      this.isAuthenticated = false;
    } else this.isAuthenticated = true;
    if (token != null) {
      let jwtData = token.split('.')[1];
      let decodedJwtJsonData = window.atob(jwtData);
      let decodedJwtData = JSON.parse(decodedJwtJsonData);

      const roles = decodedJwtData["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];

      // console.log('jwtData: ' + jwtData);
      // console.log('decodedJwtJsonData: ' + decodedJwtJsonData);
      // console.log('decodedJwtData: ' + decodedJwtData);
      //console.log('Is admin: ' + roles);
      if(roles.includes('Admin')){
        this.isAdmin=true;
      }
      if(roles.includes('ForumUser')){
        this.isUser=true;
      }
      console.log('Is admin: ' + this.isAdmin);
      console.log('Is user: ' + this.isUser);
    }

  }
}
