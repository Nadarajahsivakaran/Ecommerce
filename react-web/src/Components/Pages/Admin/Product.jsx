import React, { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { getProducts } from "../../../Features/Slices/productSlice";


const Product = () => {
  const dispatch = useDispatch();
  useEffect(() => {
    dispatch(getProducts());
  }, [dispatch]);

  const products = useSelector((state) => state.product.products);

  return (
    <div className="container">
      <h2>Product Details</h2>
      <table className="table table-hover">
        <thead>
          <tr className="table-secondary">
            <th scope="col">Product</th>
            <th scope="col">Category</th>
            <th scope="col">Price</th>
            <th scope="col">Action</th>
          </tr>
        </thead>
        <tbody>
          {products.length > 0 ? (
            <>
              {products.map((item, index) => (
                <tr className="table-secondary">
                  <td>{item.productName}</td>
                  <td>{item.category.categoryName}</td>
                  <td>{item.price}</td>

                  <td>
                    <a href="d" className="btn btn-primary">
                      <i className="bi bi-pencil-square"></i>
                    </a>{" "}
                    &nbsp;
                    <a href="f" className="btn btn-danger">
                      <i className="bi bi-trash-fill"></i>
                    </a>
                  </td>
                </tr>
              ))}
            </>
          ) : (
            <>
              <tr className="table-secondary">
                <td colspan="4">There are no records</td>
              </tr>
            </>
          )}
        </tbody>
      </table>
    </div>
  );
};

export default Product;
