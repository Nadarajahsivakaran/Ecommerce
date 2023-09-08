import { createSelector, createFeatureSelector } from '@ngrx/store';
import { CategoryState } from './category.reducer';

const getItemState = createFeatureSelector<CategoryState>('category');

export const selectCategories = createSelector(getItemState, (state) => state.list);
