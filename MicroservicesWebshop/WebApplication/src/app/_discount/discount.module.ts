import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DiscountRoutingModule } from './discount-routing.module';
import { DiscountComponent } from './discount.component';


@NgModule({
  declarations: [
    DiscountComponent
  ],
  imports: [
    CommonModule,
    DiscountRoutingModule
  ]
})
export class DiscountModule { }
