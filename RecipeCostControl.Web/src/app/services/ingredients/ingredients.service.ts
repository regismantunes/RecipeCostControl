import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Ingredient } from '../../models/ingredient.model';

@Injectable({
  providedIn: 'root'
})
export class IngredientsService {

  private url = environment.api;

  constructor(private httpClient: HttpClient) { }

  getAll() {
    return this.httpClient.get<Ingredient[]>(this.url + '/ingredient')
  }

  addIngredient(ingredient: Ingredient) {
    return this.httpClient.post<Ingredient>(this.url + '/ingredient', ingredient);
  }
}
