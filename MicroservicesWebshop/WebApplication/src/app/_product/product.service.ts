import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(protected http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
  }

  //Setting BaseURI
  readonly BaseURI = 'http://localhost:60875/api';

  //Call get categories method
  getCategories() : any {
    return this.http.get(this.BaseURI + '/category/getCategories')
  }

  //Call get first categoryId method
  getFirstCategoryId() : any {
    return this.http.get(this.BaseURI + '/category/getFirstCategoryId')
  }

  //Call get category by id
  getCategory(categoryId: any) : any {
    const params = new HttpParams()
      .set('id', categoryId)

    return this.http.get(this.BaseURI + '/category/getCategory', {params})
  }

  //Call get products by category
  getProductsByCategory(categoryId: any) : any {
    const params = new HttpParams()
      .set('categoryId', categoryId)

    return this.http.get(this.BaseURI + '/product/getProductsPerCategory', {params})
  }
}
