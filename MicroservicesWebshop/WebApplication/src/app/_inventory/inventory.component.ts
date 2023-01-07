import { Component, OnInit } from '@angular/core';
import { InventoryService } from './inventory.service';

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.css']
})
export class InventoryComponent implements OnInit {
  basketShop : any;

  constructor(public service: InventoryService) { }

  ngOnInit(): void {
    // I used this id just for test
    this.service.getCategory('86dd82bf-4519-40a8-9804-e6b9b1cdc3f3').subscribe(
      (res:any) => {
        this.basketShop = res
        console.log(this.basketShop)
      }
    )
  }

}
