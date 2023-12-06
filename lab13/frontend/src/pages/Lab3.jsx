import { Box, Typography } from "@mui/material";
import { useState } from "react";
import { lab3Request } from "../service/helpers";

const Lab1 = () => {
  const [rectangles, setRectangles] = useState();
  const [n, setN] = useState();
  const [result, setResult] = useState();

  const handleCalc = (SA, SB) => {
    lab3Request(SA, SB).then((res) => {
      setResult(res.data.result);
    });
  };

  return (
    <Box>
      <Typography variant="h4">Лабораторна робота №1</Typography>
      <Typography variant="h5">
        В першому рядку задається кількість прямокутників (n), а в наступних n
        рядках вводяться координати прямокутників. Програма знаходить
        максимальну площу перетину двох прямокутників і виводить результат.
      </Typography>
      <p>Введіть n</p>
      <input type="text" onChange={(e) => setN(e.target.value)} />
      <p>Введіть прямокутники (через пробіл)</p>
      <input type="text" onChange={(e) => setRectangles(e.target.value)} />
      <p>Результат: {result}</p>
      <button onClick={() => handleCalc(rectangles, n)}>Розрахувати</button>
    </Box>
  );
};
export default Lab1;
