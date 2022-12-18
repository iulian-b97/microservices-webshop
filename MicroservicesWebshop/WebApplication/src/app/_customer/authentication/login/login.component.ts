import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private authService: AuthenticationService, 
              private fb: FormBuilder,
              private router: Router) { }

  ngOnInit(): void {
    if(localStorage.getItem('token') != null )
    {
      this.router.navigateByUrl('/home')
    }
  }

  loginForm = this.fb.group({
    Email :['', Validators.email],
    Password :['', Validators.required],
  });

  login() {
      this.authService.login(this.loginForm).subscribe((res:any) => {
      localStorage.setItem('token', res.token)
      this.router.navigateByUrl('/home')
    })
  }
}
