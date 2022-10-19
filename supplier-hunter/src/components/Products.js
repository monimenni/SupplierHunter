import "./Products.css";
import React, { useState, useEffect } from "react";
import { getProducts } from "../utilities/productUtilities";

function Products({ onChangeProduct }) {
  const [products, setProducts] = useState();
  const [unmounted, setUnmounted] = useState(false);

  useEffect(() => {
    getProducts().then((res) => {
      if (!unmounted) {
        setProducts(res.data);
      }
    });
    return function cleanup() {
      setUnmounted(true);
    };
  }, [unmounted]);

  const handleChangeProduct = (p) => {
    onChangeProduct(p);
  };

  return (
    <div>
      <select onChange={(p) => handleChangeProduct(p)}>
        <option value="0"></option>
        {products &&
          products.length > 0 &&
          products.map((p) => (
            <option value={p.idProduct} key={p.idProduct}>
              {p.productCodeName}
            </option>
          ))}
      </select>
    </div>
  );
}

export default Products;
