import React from "react";
import { Rating } from "react-simple-star-rating";

export function AvaliacaoEstrelas({ setScore }) {
  const handleRating = (rate) => {
    setScore(Math.round(rate / 20)); // Ajuste a divisão conforme a escala desejada
  };

  return (
    <div>
      <Rating onClick={handleRating} />
    </div>
  );
}
