import { NgModule, isDevMode } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.module';
import { StoreModule } from '@ngrx/store';
import { CategoryComponent } from './Components/Admin/category/category.component';
import { ProductComponent } from './Components/Admin/product/product.component';
import { categoryReducer } from './Store/Category/category.reducer';
import { EffectsModule } from '@ngrx/effects';
import { CategoryEffects } from './Store/Category/category.effects';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { NavHeaderComponent } from './Components/Public/nav-header/nav-header.component';
import { productReducer } from './Store/Product/product.reducer';
import { ProductEffects } from './Store/Product/product.effect';

@NgModule({
  declarations: [
    AppComponent,
    CategoryComponent,
    ProductComponent,
    NavHeaderComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    StoreModule.forRoot(
      { category: categoryReducer, product: productReducer },
      {}
    ),
    EffectsModule.forRoot([CategoryEffects, ProductEffects]),
    StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: isDevMode() }),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
