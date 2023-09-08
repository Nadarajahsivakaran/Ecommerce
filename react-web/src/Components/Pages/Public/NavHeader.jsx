import React from "react";

const NavHeader = () => {
  return (
    <header>
      <nav className="navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-dark border-bottom box-shadow mb-3">
        <div className="container-fluid">
          <a
            href="h"
            className="navbar-brand text-white "
            asp-area=""
            asp-controller="Home"
            asp-action="Index"
          >
            E_Commerce.Web
          </a>
          <button
            className="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target=".navbar-collapse"
            aria-controls="navbarSupportedContent"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="navbar-collapse collapse d-sm-inline-flex justify-content-between">
            <ul className="navbar-nav flex-grow-1">
              <li className="nav-item">
                <a
                  href="h"
                  className="nav-link text-white"
                  asp-area="admin"
                  asp-controller="Category"
                  asp-action="Index"
                >
                  Category
                </a>
              </li>
              <li className="nav-item">
                <a
                  href="h"
                  className="nav-link text-white"
                  asp-area="admin"
                  asp-controller="Product"
                  asp-action="Index"
                >
                  Product
                </a>
              </li>
            </ul>
          </div>
        </div>
      </nav>
    </header>
  );
};

export default NavHeader;
