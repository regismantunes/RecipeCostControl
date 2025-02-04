import { Component } from '@angular/core';
import { RecipesService } from '../services/recipes/recipes.service';
import { Recipe } from '../models/recipe.model';
import { Observable } from 'rxjs/internal/Observable';

@Component({
  selector: 'app-recipes',
  standalone: false,
  
  templateUrl: './recipes.component.html',
  styleUrl: './recipes.component.css'
})
export class RecipesComponent {

  recipes$ = new Observable<Recipe[]>();

  constructor(private recipesService: RecipesService) {
    this.getAllRecipes();
  }

  getAllRecipes() {
    this.recipes$ = this.recipesService.getAll();
  }

}
