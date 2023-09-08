import { createAction, props } from '@ngrx/store';
import { Product } from 'src/app/Models/product.model';


export const loadProduct = createAction('[Product] Load Product');
export const loadProductSuccess = createAction(
  '[Product] Load Product Success',
  props<{ list: Product[] }>()
);
export const loadProductFailure = createAction(
  '[Product] Load Product Failure',
  props<{ error: any }>()
);
