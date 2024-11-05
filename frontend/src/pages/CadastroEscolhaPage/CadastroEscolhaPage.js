import styled from "styled-components";
import Logo from "../../assets/image-removebg-preview.png";
import React from "react";
import { useNavigate } from "react-router-dom";

export default function CadastroEscolhaPage() {
    const navigate = useNavigate();

    return (
        <CadastroEscolhaContainer>
            <WhiteBox>
                <Texto>Gostaria de contratar ou providenciar serviços?</Texto>
                <ButtonContainer>
                    <Button onClick={() => navigate("/cadastro")}>É um cliente? Cadastre-se</Button>
                    <Texto>ou</Texto>
                    <Button onClick={() => navigate("/cadastro-empresarial")}>É uma empresa? Cadastre-se</Button>
                </ButtonContainer>
            </WhiteBox>
        </CadastroEscolhaContainer>
    );
}

const Texto = styled.p`
    font-family: 'Lexend Deca';
    font-style: normal;
    font-weight: normal;
    font-size: 24px;
    line-height: 26px;
    text-align: center;
    color: #00274D;
`;

const ButtonContainer = styled.div`
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    gap: 10px;
`;

const CadastroEscolhaContainer = styled.div`
    width: 100%;
    height: 100%;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    margin-top: 150px;
    background-size: cover;
    background-position: center;
    color: rgb(0, 39, 77);
`;

const Button = styled.button`
    margin: 10px 0px;
    width: 300px;
    height: 45px;
    border: 1px solid #D4D4D4;
    border-radius: 5px;
    background-color: #00274D;
    color: white;
    font-family: 'Lexend Deca';
    font-style: normal;
    font-weight: 400;
    font-size: 18px;
    line-height: 26px;
    text-align: center;
    display: flex;
    justify-content: center;
    align-items: center;
`;

const WhiteBox = styled.div`
    background-color: white;
    border-radius: 10px;
    padding: 20px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    width: 80%;
    height: 400px;
    max-width: 600px;
    margin: 20px;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-around;

    @media (max-width: 600px) {
        width: 95%;
    }
`;