import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, switchMap } from 'rxjs/operators';
import { of, exhaustMap } from 'rxjs';

import { ApiResponse } from 'src/app/Models/api-response.model';
import { ProductService } from 'src/app/Services/product.service';
import {
  loadProduct,
  loadProductFailure,
  loadProductSuccess,
} from './product.action';

@Injectable()
export class ProductEffects {
  constructor(private actions$: Actions, private service: ProductService) {}

  _loadProduct = createEffect(() =>
    this.actions$.pipe(
      ofType(loadProduct),
      exhaustMap(() => {
        return this.service.getAllProducts().pipe(
          switchMap((response: ApiResponse) => {
            if (response.isSuccess) {
              return of(loadProductSuccess({ list: response.res }));
            } else {
              return of(loadProductFailure({ error: response.message }));
            }
          }),
          catchError((_error) =>
            of(loadProductFailure({ error: _error.message }))
          )
        );
      })
    )
  );
}
