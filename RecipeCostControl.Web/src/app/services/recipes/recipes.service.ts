import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Recipe } from '../../models/recipe.model';

@Injectable({
  providedIn: 'root'
})
export class RecipesService {

  private url = environment.api;

  constructor(private httpClient: HttpClient) {
  }

  getAll() {
    return this.httpClient.get<Recipe[]>(this.url + '/recipes')
  }
}
