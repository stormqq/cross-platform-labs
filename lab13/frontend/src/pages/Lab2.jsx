import { Box, Typography } from "@mui/material";
import { useState } from "react";
import { lab2Request } from "../service/helpers";

const Lab1 = () => {
  const [K, setK] = useState();
  const [P, setP] = useState();
  const [result, setResult] = useState();

  const handleCalc = (SA, SB) => {
    lab2Request(SA, SB).then((res) => {
      setResult(res.data.result);
    });
  };

  return (
    <Box>
      <Typography variant="h4">Лабораторна робота №1</Typography>
      <Typography variant="h5">
      Програма виводить кількість ентів, які знають рівно K слів, за модулем P.
      </Typography>
        <p>Введіть K</p>
        <input type="text" onChange={(e) => setK(e.target.value)} />
        <p>Введіть P</p>
        <input type="text" onChange={(e) => setP(e.target.value)} />
        <p>Результат: {result}</p>
        <button onClick={() => handleCalc(K, P)}>Розрахувати</button>
    </Box>
  );
};
export default Lab1;
