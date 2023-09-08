import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import {
  catchError,
  switchMap,
} from 'rxjs/operators';
import { of, exhaustMap, Subject } from 'rxjs';
import './category.action';
import { CategoryService } from 'src/app/Services/category.service';
import { ApiResponse } from 'src/app/Models/api-response.model';
import {
  loadCategory,
  loadCategoryFailure,
  loadCategorySuccess,
} from './category.action';

@Injectable()
export class CategoryEffects {
  constructor(private actions$: Actions, private service: CategoryService) {}

  _loadCategory = createEffect(() =>
    this.actions$.pipe(
      ofType(loadCategory),
      exhaustMap(() => {
        return this.service.getAllCategories().pipe(
          switchMap((response: ApiResponse) => {
            if (response.isSuccess) {
              return of(loadCategorySuccess({ list: response.res }));
            } else {
              return of(loadCategoryFailure({ error: response.message }));
            }
          }),
          catchError((_error) =>
            of(loadCategoryFailure({ error: _error.message }))
          )
        );
      })
    )
  );
}
