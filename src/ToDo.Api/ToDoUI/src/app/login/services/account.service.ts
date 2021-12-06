import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient, private router: Router) { }

  logout(){
    localStorage.removeItem('token');
  }

  login(user: User){
    const authData = {
      email: user.email,
      password: user.password
    }

    return this.http.post(environment.apiUrl + '/accounts/authenticate', authData);
  }

  register(user: User){
    const authData = {
      email: user.email,
      userName: user.userName,
      password: user.password,
      confirmPassword: user.confirmPassword
    }

    return this.http.post(environment.apiUrl + '/accounts/register', authData);
  }
}
