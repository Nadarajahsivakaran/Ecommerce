import { createSelector, createFeatureSelector } from '@ngrx/store';
import { ProductState } from './product.reducer';


const getItemState = createFeatureSelector<ProductState>('product');

export const selectProducts = createSelector(getItemState, (state) => state.list);
