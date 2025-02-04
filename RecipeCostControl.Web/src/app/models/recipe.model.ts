import { RecipeItem } from "./recipeItem.model";

export interface Recipe {
  id?: number,
  name: string,
  items: RecipeItem[],
  measurementUnitId: string,
  yealdQuantity: number,
  cost: number
}
