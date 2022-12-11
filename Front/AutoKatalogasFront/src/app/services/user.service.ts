import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { LoginRequest, LoginResponse, RegisterRequest } from '../types/autokatalogas.types';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};

@Injectable({
  providedIn: 'root',
})
export class UserService {
  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http: HttpClient,private router: Router) {}
  public isAuthenticated: boolean = false;
  private readonly TokenValidInMinutes: number = 60;
  readonly storage = 'autokatalogas';

  register(req: RegisterRequest) {
    return this.http.post(this.baseApiUrl + 'api/register', req);
  }

  delete(id: number) {
    return this.http.delete('users/${id}');
  }

  login(req: LoginRequest) {
    return this.http.post<LoginResponse>(this.baseApiUrl + 'api/login', req).pipe(
      tap({
        next: (response: { accessToken: string; }) => {
          localStorage.setItem(this.storage, response.accessToken);
          console.log(localStorage.getItem(this.storage))
          this.isAuthenticated = true;
        },
      })
    );
  }

  logout() {
    localStorage.removeItem(this.storage);
    this.isAuthenticated = false;
  }

  public getToken(): string | null {
    return localStorage.getItem(this.storage);
  }

  public validateSession(): void {
    const token = this.getToken();
    if (!token) {
      this.isAuthenticated = false;
    } else this.isAuthenticated = true;
  }

}
