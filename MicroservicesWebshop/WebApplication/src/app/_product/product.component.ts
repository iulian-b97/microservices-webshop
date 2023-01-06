import { Component, OnInit } from '@angular/core';
import { ProductService } from './product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  selectCategoryId: any
  selectCategoryName: any
  productsCategoryList: any

  constructor(public service: ProductService) { }

  ngOnInit(): void { 
      if(localStorage.getItem('selectCategoryId') == null || localStorage.getItem('selectCategoryId') == undefined)
      {
        this.service.getFirstCategoryId().subscribe(
          (res:any) => {
            this.selectCategoryId = Object.values(res)[0];
            localStorage.setItem('selectCategoryId', this.selectCategoryId)
            this.service.getCategory(localStorage.getItem('selectCategoryId')).subscribe(
              (res:any) => {
                this.selectCategoryName = Object.values(res)[1];
                console.log(this.selectCategoryName)
              }
            )
            window.location.reload()  
          }
        )    
      }
      else
      {
        this.service.getCategory(localStorage.getItem('selectCategoryId')).subscribe(
          (res:any) => {
            this.selectCategoryName = Object.values(res)[1];
            console.log(this.selectCategoryName)
          }
        )
      } 
      
      this.service.getProductsByCategory(localStorage.getItem('selectCategoryId')).subscribe(
        (res:any) => {
          this.productsCategoryList = res
          console.log(this.productsCategoryList)
        }
      )
  }

}
