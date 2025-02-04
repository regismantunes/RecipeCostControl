import { Component } from '@angular/core';
import { IngredientsService } from '../services/ingredients/ingredients.service';
import { Observable } from 'rxjs/internal/Observable';
import { Ingredient } from '../models/ingredient.model';

@Component({
  selector: 'app-ingredients',
  standalone: false,
  
  templateUrl: './ingredients.component.html',
  styleUrl: './ingredients.component.css'
})
export class IngredientsComponent {

  ingredients$ = new Observable<Ingredient[]>();

  constructor(private ingredientsService: IngredientsService) {
    this.getAllIngredients();
  }

  getAllIngredients() {
    this.ingredients$ = this.ingredientsService.getAll();
  }

}
