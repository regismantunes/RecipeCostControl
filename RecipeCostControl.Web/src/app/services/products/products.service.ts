import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Product } from '../../models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private url = environment.api;

  constructor(private httpClient: HttpClient) {
  }

  getAll() {
    return this.httpClient.get<Product[]>(this.url + '/products')
  }
}
