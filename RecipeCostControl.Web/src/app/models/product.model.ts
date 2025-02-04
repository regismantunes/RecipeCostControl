export interface Product {
  id?: number,
  name: string,
  recipeId: number,
  packagingId: number,
  measurementUnitId: string,
  cost: number,
  sellingPrice: number
}
