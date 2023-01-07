import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class InventoryService {

  constructor(protected http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
  }

  //Setting BaseURI
  readonly BaseURI = 'http://localhost:56801/api';

  
  //Call get basketshop by user id
  getCategory(userId: any) : any {
    const params = new HttpParams()
      .set('userId', userId)

    return this.http.get(this.BaseURI + '/inventory/getBasketShop', {params})
  }
}
