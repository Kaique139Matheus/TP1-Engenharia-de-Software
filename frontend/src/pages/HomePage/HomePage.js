import styled from "styled-components";
import Logo from "../../assets/image-removebg-preview.png";
import { Link, useNavigate } from "react-router-dom";
import React from "react";
import "@fontsource/lexend-deca"; // Padrão para importar todas as variações da fonte

export default function HomePage() {
  const navigate = useNavigate();

  return (
    <HomeContainer>
      <WhiteBox>
        <NavContainer>
          <p>Bem vindo ao Easy Booking</p>
        </NavContainer>
        <HomeOptionsContainer>
          <Options>
            <OptionButton onClick={() => navigate("/login")}>
              Faça o Login
            </OptionButton>
            ou
            <OptionButton onClick={() => navigate("/cadastro")}>
              Cadastre Agora
            </OptionButton>
          </Options>
          <Divider></Divider>
          <Text>É uma empresa?</Text>
          <Options>
            <OptionButton onClick={() => navigate("/login-empresarial")}>
              Faça o Login
            </OptionButton>
            ou
            <LastButtonOption onClick={() => navigate("/cadastro-empresarial")}>
              Divulgue seus Serviços
            </LastButtonOption>
          </Options>
        </HomeOptionsContainer>
      </WhiteBox>
    </HomeContainer>
  );
}

const Divider = styled.div`
  margin-top: 25px; /* Espaço acima da divisória */
  margin-bottom: 20px; /* Maior separação abaixo da divisória */
  height: 10px; /* Aumenta a grossura da divisória */
  background-color: #00274d;
  width: 450px; /* Largura total dos botões */
`;

const Options = styled.div`
  display: flex;
  width: 100%;
  height: 100%;
  align-items: center;
  flex-direction: row;
  justify-content: center;
  gap: 15px;
`;

const OptionButton = styled.button`
  margin: 10px 0px;
  width: 200px;
  height: 45px;
  border: 1px solid #d4d4d4;
  border-radius: 5px;
  background-color: #00274d;
  color: white;
  font-family: "Lexend Deca", sans-serif;
  font-style: normal;
  font-weight: 400;
  font-size: 18px;
  line-height: 26px;
  text-align: center;
  display: flex;
  justify-content: center;
  align-items: center;
  transition: background-color 0.3s, border 0.3s;

  &:hover {
    background-color: #d4d4d4; /* Cor de hover cinza claro */
    border: 1px solid #00274d; /* Borda interna da mesma cor */
    color: #00274d;
  }
`;

const LastButtonOption = styled.button`
  margin: 10px 0px;
  width: 220px;
  height: 45px;
  border: 1px solid #d4d4d4;
  border-radius: 5px;
  background-color: #00274d;
  color: white;
  font-family: "Lexend Deca", sans-serif;
  font-style: normal;
  font-weight: 400;
  font-size: 18px;
  line-height: 26px;
  text-align: center;
  display: flex;
  justify-content: center;
  align-items: center;
  transition: background-color 0.3s, border 0.3s;

  &:hover {
    background-color: #d4d4d4; /* Cor de hover cinza claro */
    border: 1px solid #00274d; /* Borda interna da mesma cor */
    color: #00274d;
  }
`;

const HomeOptionsContainer = styled.div`
  width: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  margin-top: 15px;
`;

const HomeContainer = styled.div`
  width: 100%;
  height: 100vh;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  background-size: cover;
  background-position: center;
  color: rgb(0, 39, 77);
`;

const WhiteBox = styled.div`
  background-color: white;
  border-radius: 10px;
  padding: 20px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  width: 80%;
  max-width: 600px;
  margin: 20px;
  display: flex;
  flex-direction: column;
  align-items: center;

  @media (max-width: 600px) {
    width: 95%;
  }
`;

const NavContainer = styled.div`
  width: 100%;
  height: 70px;
  display: flex;
  align-items: center;
  justify-content: center;
  font-family: "Roboto", sans-serif;
  font-size: 34px;
  p {
    text-decoration: none;
    color: #00274d;
  }
`;

const Text = styled.div`
  width: 100%;
  height: 70px;
  margin-bottom: 10px; /* Menor separação da frase para os botões de baixo */
  display: flex;
  align-items: center;
  justify-content: center;
  font-family: "Lexend Deca", sans-serif;
  color: #00274d;
  font-family: "Roboto", sans-serif;
  font-size: 18px;
`;
