import axios from "axios";

const lab1Request = async (SA, SB) => {
  const response = await axios.post("http://localhost:3001/labs/lab1", { SA, SB });
  return response.data;
};

const lab2Request = async (K, P) => {
  const response = await axios.post("/lab2", { K, P });
  return response.data;
};

const lab3Request = async (rectangles, n) => {
  const response = await axios.post("/lab3", { rectangles, n });
  return response.data;
};

export { lab1Request, lab2Request, lab3Request };
