import { Component } from '@angular/core';
import { IngredientsService } from '../services/ingredients/ingredients.service';
import { Ingredient } from '../models/ingredient.model';

@Component({
  selector: 'app-ingredient-add',
  standalone: false,
  
  templateUrl: './ingredient-add.component.html',
  styleUrl: './ingredient-add.component.css'
})
export class IngredientAddComponent {

  ingredient: Ingredient = {
    name: '',
    measurementUnitId: '',
    cost: 0
  };

  errorMessage: string = '';

  constructor(private ingredientsService: IngredientsService) {
  }

  onSubmit() {
    this.ingredientsService.addIngredient(this.ingredient)
      .subscribe(
        (ingredient) => {
          this.ingredient = { name: '', measurementUnitId: '', cost: 0 };
        },
        (error) => {
          console.error('Error adding ingredient: ' + error);
          this.errorMessage = error.message;
        }
    );
  }
}
