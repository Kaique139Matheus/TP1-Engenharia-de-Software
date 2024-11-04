import styled from "styled-components";
import Logo from "../../assets/image-removebg-preview.png";
import { Link, useNavigate } from "react-router-dom";
import React from "react";

export default function HomePage() {
  const navigate = useNavigate();

  return (
    <HomeContainer>
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
    </HomeContainer>
  );
}

const Divider = styled.div`
  margin-top: 15px;
  height: 0.5px;
  background-color: #333;
  width: 40%;
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
  font-size: 20.976px;
  line-height: 26px;
  text-align: center;
  display: flex;
  justify-content: center;
  align-items: center;
  transition: background-color 0.3s;

  &:hover {
    background-color: white;
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
  font-size: 20.976px;
  line-height: 26px;
  text-align: center;
  display: flex;
  justify-content: center;
  align-items: center;
  transition: background-color 0.3s;

  &:hover {
    background-color: white;
    color: #00274d;
  }
`;

const HomeOptionsContainer = styled.div`
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  margin-top: 15px;
`;

const HomeContainer = styled.div`
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  margin-top: 100px;

  img {
    width: 180px;
    height: 200px;
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
  display: flex;
  align-items: center;
  justify-content: center;
  color: #00274d;
  font-family: "Roboto", sans-serif;
  font-size: 18px;
`;
