import "./Search.css";
import SuppliersList from "./components/SuppliersList";
import DatePicker from "react-date-picker";
import NumericInput from "react-numeric-input";
import Products from "../src/components/Products";
import { getSuppliers } from "./utilities/supplierUtilities";
import React, { useState } from "react";

function Search() {
  const [suppliers, setSuppliers] = useState();
  const [quantity, setQuantity] = useState();
  const [date, setDate] = useState();
  const [showUpDownButtons, setShowUpDownButtons] = useState(false);
  const [idProduct, setIdProduct] = useState(null);

  //TODO: potrei cambiare prodotto dopo aver già settato la quantità
  //mettere logica unica su pulsante??
  const onChangeProduct = (p) => {
    setIdProduct(p.target.value);
    getSuppliers(p.target.value, quantity, date).then((res) =>
      setSuppliers(res.data)
    );
  };

  const onChangeQuantity = (q) => {
    setQuantity(q);
    if (idProduct) {
      getSuppliers(idProduct, q, date).then((res) => {
        setSuppliers(res.data);
      });
    }
  };

  const OnChangeDate = (d) => {
    setDate(d);
    if (idProduct) {
      getSuppliers(idProduct, quantity, d).then((res) =>
        setSuppliers(res.data)
      );
    }
  };

  return (
    <div className="main">
      <div className="filters">
        <div>
          <span className="label">Product</span>
          <Products onChangeProduct={onChangeProduct} />
        </div>
        <div>
          <div className="label">Quantity</div>
          <NumericInput
            style={showUpDownButtons}
            onChange={(q) => onChangeQuantity(q)}
          />
        </div>
        <div>
          <div className="label">Limit Date</div>
          <DatePicker onChange={(d) => OnChangeDate(d)} value={date} />
        </div>
      </div>
      <div className="suppliers-list">
        <SuppliersList suppliers={suppliers} />
      </div>
    </div>
  );
}

export default Search;
