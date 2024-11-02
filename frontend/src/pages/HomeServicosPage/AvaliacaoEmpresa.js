import React, { useState } from 'react'
import styled from "styled-components";
import estrela from "../../assets/estrela.png"

export function AvaliacaoEmpresa({avaliacaoInicial}) {
  const [rating, _] = useState(avaliacaoInicial)
  const estrelas = new Array()
  for(let i = 0; i < rating; i++) {
    estrelas.push (
        <img src={estrela}
        alt="estrela"
    ></img>
    )
}
  return (
    <AvaliacaoEmpresaContainer>
        {
            estrelas
        }
    </AvaliacaoEmpresaContainer>
    
  )
}

const AvaliacaoEmpresaContainer = styled.div`
    width: 100px;
    height: 80%;
    img {
        width: 18px;
        height: 18px;   
    }
`;
