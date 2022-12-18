import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { HttpClientModule, HttpClient } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HomeComponent } from './common/home/home.component';
import { NavComponent } from './common/nav/nav.component';

import { AppRoutingModule } from './app-routing.module';
import { AuthenticationModule } from './_customer/authentication/authentication.module';
import { DiscountModule } from './_discount/discount.module';
import { InventoryModule } from './_inventory/inventory.module';
import { OrderModule } from './_order/order.module';
import { ProductModule } from './_product/product.module';

import { AuthenticationService } from './_customer/authentication/authentication.service';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule, 
    ReactiveFormsModule,
    AppRoutingModule,
    AuthenticationModule,
    DiscountModule,
    InventoryModule,
    OrderModule,
    ProductModule,
    FontAwesomeModule
  ],
  providers: [AuthenticationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
