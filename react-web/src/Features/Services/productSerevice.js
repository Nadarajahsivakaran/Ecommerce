import axios from "axios";

export const getAllProduct = async () => {
  const response = await axios.get("https://localhost:7001/api/Product");
  return await response.data.res;
};
