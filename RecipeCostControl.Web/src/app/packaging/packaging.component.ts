import { Component } from '@angular/core';
import { PackagingService } from '../services/packaging/packaging.service';
import { Observable } from 'rxjs/internal/Observable';
import { Ingredient } from '../models/ingredient.model';

@Component({
  selector: 'app-packaging',
  standalone: false,
  
  templateUrl: './packaging.component.html',
  styleUrl: './packaging.component.css'
})
export class PackagingComponent {

  packaging$ = new Observable<Ingredient[]>();

  constructor(private packagingService: PackagingService) {
    this.getAllPackaging();
  }

  getAllPackaging() {
    this.packaging$ = this.packagingService.getAll();
  }

}
