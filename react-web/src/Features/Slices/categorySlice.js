import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { getAllCategory } from "../Services/categoryService";

const initialState = {
  categories: [],
  isLodaing: false,
  isSuccess: false,
  isError: false,
  message: "",
};

export const getCategories = createAsyncThunk(
  "category/getCategories",
  async (_, thunkAPI) => {
    try {
      return await getAllCategory();
    } catch (error) {
      const message = error.message;
      return thunkAPI.rejectWithValue(message);
    }
  }
);

export const categorySlice = createSlice({
  name: "category",
  initialState,
  extraReducers: (builder) => {
    builder.addCase(getCategories.pending, (state) => {
      state.isLodaing = true;
      state.isError = false;
      state.message = "";
      state.isSuccess = false;
      state.categories = [];
    });
    builder.addCase(getCategories.fulfilled, (state, action) => {
      state.isLodaing = false;
      state.isError = false;
      state.message = "";
      state.isSuccess = true;
      state.categories = action.payload;
    });
    builder.addCase(getCategories.rejected, (state, action) => {
      state.isLodaing = false;
      state.isError = true;
      state.message = action.payload;
      state.isSuccess = false;
      state.categories = [];
    });
  },
});

export default categorySlice.reducer;
