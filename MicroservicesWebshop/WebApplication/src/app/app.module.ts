import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { AuthenticationModule } from './_customer/authentication/authentication.module';
import { HomeComponent } from './common/home/home.component';
import { NavComponent } from './common/nav/nav.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { DiscountModule } from './_discount/discount.module';
import { InventoryModule } from './_inventory/inventory.module';
import { OrderModule } from './_order/order.module';
import { ProductModule } from './_product/product.module';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AuthenticationModule,
    DiscountModule,
    InventoryModule,
    OrderModule,
    ProductModule,
    FontAwesomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
