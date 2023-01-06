import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  constructor(public service: ProductService) { }

  allCategories : any;

  ngOnInit(): void {
    this.service.getCategories().subscribe(
      (res:any) => {
        this.allCategories = res;
        console.log(this.allCategories);
      }
    );
  }

  selectCategory(categoryId: any) {
    localStorage.setItem('selectCategoryId', categoryId)
    window.location.reload()  
  }
}
