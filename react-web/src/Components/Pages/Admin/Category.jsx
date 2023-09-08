import React, { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { getCategories } from "../../../Features/Slices/categorySlice";

const Category = () => {
  const dispatch = useDispatch();
  useEffect(() => {
    dispatch(getCategories());
  }, [dispatch]);

  const categories = useSelector((state) => state.category.categories);

  return (
    <div className="container">
      <h2>Category Details</h2>
      <table className="table table-hover">
        <thead>
          <tr className="table-secondary">
            <th scope="col">Category</th>
            <th scope="col">Action</th>
          </tr>
        </thead>
        <tbody>
          {categories.length > 0 ? (
            <>
              {categories.map((item, index) => (
                <tr className="table-secondary">
                  <td>{item.categoryName}</td>
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
                <td colspan="2">There are no records</td>
              </tr>
            </>
          )}
        </tbody>
      </table>
    </div>
  );
};

export default Category;
