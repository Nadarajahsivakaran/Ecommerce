import { createReducer, on } from '@ngrx/store';

import { Category } from 'src/app/Models/category.model';
import { loadCategoryFailure, loadCategorySuccess } from './category.action';

export interface CategoryState {
  list: Category[];
  error: any;
}

export const initialState: CategoryState = {
  list: [],
  error: null,
};

export const categoryReducer = createReducer(
  initialState,
  on(loadCategorySuccess, (state, { list }) => ({ ...state, list })),
  on(loadCategoryFailure, (state, { error }) => ({ ...state, error }))
);
