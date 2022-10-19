import axios from "axios";

export const getSuppliers = (idProduct, quantity, limitDate) => {
  return axios
    .get(`https://localhost:44306/api/product/${idProduct}/suppliers`, {
      params: {
        quantity,
        limitDate
      },
    })
    .then((res) => {
      return res;
    });
};
