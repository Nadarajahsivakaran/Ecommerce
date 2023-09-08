import { configureStore } from "@reduxjs/toolkit";
import categoryReducer from "./Slices/categorySlice";
import productReducer from "./Slices/productSlice";

export const store = configureStore({
  reducer: {
    category: categoryReducer,
    product: productReducer,
  },
});
