import { Component } from '@angular/core';
import { ProductsService } from '../services/products/products.service';
import { Product } from '../models/product.model';
import { Observable } from 'rxjs/internal/Observable';

@Component({
  selector: 'app-products',
  standalone: false,
  
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent {

  products$ = new Observable<Product[]>();

  constructor(private productsService: ProductsService) {
    this.getAllProducts();
  }

  getAllProducts() {
    this.products$ = this.productsService.getAll();
  }

}
