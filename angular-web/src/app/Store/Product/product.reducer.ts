import { createReducer, on } from '@ngrx/store';
import { loadProductFailure, loadProductSuccess } from './product.action';
import { Product } from 'src/app/Models/product.model';

export interface ProductState {
  list: Product[];
  error: any;
}

export const initialState: ProductState = {
  list: [],
  error: null,
};

export const productReducer = createReducer(
  initialState,
  on(loadProductSuccess, (state, { list }) => ({ ...state, list })),
  on(loadProductFailure, (state, { error }) => ({ ...state, error }))
);
