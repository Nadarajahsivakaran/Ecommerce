import axios from "axios";

export const getAllCategory = async () => {
  const response = await axios.get("https://localhost:7001/api/Category");
  return await response.data.res;
};
