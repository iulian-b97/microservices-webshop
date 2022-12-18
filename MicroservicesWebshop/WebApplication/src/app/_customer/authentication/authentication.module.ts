import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthenticationRoutingModule } from './authentication-routing.module';
import { AuthenticationService } from './authentication.service';

import { AuthenticationComponent } from './authentication.component';
import { LoginComponent } from './login/login.component';

import { RegisterComponent } from './register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AuthenticationComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    CommonModule,
    AuthenticationRoutingModule,
    FormsModule, 
    ReactiveFormsModule
  ],
  providers: [
    
  ]
})
export class AuthenticationModule { }
