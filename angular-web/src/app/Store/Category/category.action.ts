import { createAction, props } from '@ngrx/store';
import { Category } from 'src/app/Models/category.model';

export const loadCategory = createAction('[Category] Load Category');
export const loadCategorySuccess = createAction(
  '[Category] Load Category Success',
  props<{ list: Category[] }>()
);
export const loadCategoryFailure = createAction(
  '[Category] Load Category Failure',
  props<{ error: any }>()
);
