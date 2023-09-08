import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { getAllProduct } from "../Services/productSerevice";


const initialState = {
  products: [],
  isLodaing: false,
  isSuccess: false,
  isError: false,
  message: "",
};

export const getProducts = createAsyncThunk(
  "product/getProducts",
  async (_, thunkAPI) => {
    try {
      return await getAllProduct();
    } catch (error) {
      const message = error.message;
      return thunkAPI.rejectWithValue(message);
    }
  }
);

export const productSlice = createSlice({
  name: "product",
  initialState,
  extraReducers: (builder) => {
    builder.addCase(getProducts.pending, (state) => {
      state.isLodaing = true;
      state.isError = false;
      state.message = "";
      state.isSuccess = false;
      state.products = [];
    });
    builder.addCase(getProducts.fulfilled, (state, action) => {
      state.isLodaing = false;
      state.isError = false;
      state.message = "";
      state.isSuccess = true;
      state.products = action.payload;
    });
    builder.addCase(getProducts.rejected, (state, action) => {
      state.isLodaing = false;
      state.isError = true;
      state.message = action.payload;
      state.isSuccess = false;
      state.products = [];
    });
  },
});

export default productSlice.reducer;
