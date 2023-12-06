import { Box, Typography } from "@mui/material";
import { useState } from "react";
import { lab1Request } from "../service/helpers";

const Lab1 = () => {
  const [SA, setSA] = useState();
  const [SB, setSB] = useState();
  const [result, setResult] = useState();

  const handleCalc = (SA, SB) => {
    lab1Request(SA, SB).then((res) => {
      setResult(res.data.result);
    });
  };

  return (
    <Box>
      <Typography variant="h4">Лабораторна робота №1</Typography>
      <Typography variant="h5">
        Програма визначає відстань між рівними по довжині рядками SA та SB
        (позначимо d(SA, SB)) як суму для всіх 1 ≤ i ≤ |SA| найкоротших
        відстаней між літерами SA(i) та SB(i) у циклічно замкнутому англійському
        алфавіті (тобто після букви «a» йде буква «b», ..., після букви «z» йде
        «a»). Наприклад, d(aba, aca) = 1, а d(aba, zbz) = 2. Будь ласка, введіть
        два рядки SA та SB, щоб програма визначила d(SA, SB).
      </Typography>
      <p>Введіть SA</p>
      <input type="text" onChange={(e) => setSA(e.target.value)} />
      <p>Введіть SB</p>
      <input type="text" onChange={(e) => setSB(e.target.value)} />
      <p>Результат: {result}</p>
      <button onClick={() => handleCalc(SA, SB)}>Розрахувати</button>
    </Box>
  );
};
export default Lab1;
