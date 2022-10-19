import axios from "axios";

export const getProducts = () => {
  return axios
    .get(`https://localhost:44306/api/product`)
    .then((res) => {
      return res;
    });
};