import "./App.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Category from "./Components/Pages/Admin/Category";
import NavHeader from "./Components/Pages/Public/NavHeader";
import Product from "./Components/Pages/Admin/Product";

function App() {
  return (
    <BrowserRouter>
      <NavHeader />
      <Routes>
        <Route path="category" element={<Category />} />
        <Route path="product" element={<Product />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
