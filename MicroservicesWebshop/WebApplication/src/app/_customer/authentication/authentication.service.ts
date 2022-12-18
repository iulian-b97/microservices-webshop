import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { FormBuilder, FormGroup } from '@angular/forms';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  public isLoggedIn$: BehaviorSubject<boolean>

  constructor(protected http: HttpClient, protected fb: FormBuilder) { 
    const isLoggedIn = localStorage.getItem('token') != null
    this.isLoggedIn$ = new BehaviorSubject(isLoggedIn)
  }

  httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
  }

  //Setting BaseURI
  readonly BaseURI = 'http://localhost:13551/api';

  //Call register method
  register(registerForm: FormGroup) {
    var body = {
      Username: registerForm.value.Username,
      Email: registerForm.value.Email,
      Password: registerForm.value.Password,
      ConfirmPassword: registerForm.value.ConfirmPassword
    };
    return this.http.post(this.BaseURI + '/authentication/register', body);
  }

  //Call login method
  login(loginForm: FormGroup) {
    var body = {
      Email: loginForm.value.Email,
      Password: loginForm.value.Password
    };
    return this.http.post(this.BaseURI + '/authentication/login', body)
  }

  //Call logout method
  logout() {
    localStorage.removeItem('token')
  }

  //Check if user is logged
  isLogged(): boolean {
    return this.isLoggedIn$.value
  }
}
