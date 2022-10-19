import "./Supplier.css";

function Supplier({ supplier }) {
  function currencyFormat(num) {
    return '€ ' + num.toFixed(2).replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,')
 }
  return (
    <div className="supplier">
      <div className="businessName">{supplier.businessName}</div>
      <div className="total">{supplier && supplier.total > 0 && currencyFormat(supplier.total)}</div>
      <div className="address">{supplier.address}</div>
      <div className="deliveryDay">{supplier.deliveryDay}</div>
    </div>
  );
}

export default Supplier;
