import Supplier from "./Supplier";
import "./SuppliersList.css";

function SuppliersList({ suppliers }) {
  return (
    <div className="suppliers-list">
      {suppliers && suppliers.length !== 0 &&
        suppliers.map((s) => <Supplier key={s.idSupplier} supplier={s}/>)}
    </div>
  );
}

export default SuppliersList;
