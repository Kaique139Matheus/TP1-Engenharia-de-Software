import styled from "styled-components";
import React, { useState } from "react";
import { AvaliacaoEstrelas } from "./AvaliacaoEstrelas";
import { useNavigate } from "react-router-dom";

export default function AvaliarPage() {
    const navigate = useNavigate();
    const [descricaoText, setDescricao] = useState("")

    function onDescricaoChanged(event) {
        setDescricao(event.target.value);
    }

    return (
        <AvaliarPageContainer>
            <NavContainer>
                <p>Avalie a Empresa</p> 
            </NavContainer>
            <AvaliacaoEstrelas />
            <DescricaoContainer>
            {
                descricaoText == "" ? 
                    <Text onClick={() => setDescricao("...")}>Descrição</Text> : 
                    <DescricaoTextArea 
                        value={descricaoText}
                        onChange={onDescricaoChanged}
                        rows={10}>
                    </DescricaoTextArea>
            }
            </DescricaoContainer>
            <AvaliarBotao onClick={() => navigate("/servicos")}>Avaliar</AvaliarBotao>
        </AvaliarPageContainer>
    );
}

const Text = styled.div`
    width: 100px;
    height: 70px;
    display: flex;
    align-items: center;
    justify-content: center;
    color: #00274D;
    font-family: 'Roboto', sans-serif;
    font-size: 15px;
`

const AvaliarBotao = styled.button`
    margin: 10px 0px;
    width: 170px;
    height: 45px;
    border: 1px solid #D4D4D4;
    border-radius: 5px;
    background-color: #00274D;
    color: white;
    font-family: 'Lexend Deca';
    font-style: normal;
    font-weight: 400;
    font-size: 20.976px;
    line-height: 26px;
    text-align: center;
    display: flex;
    justify-content: center;
    align-items: center;
`

const NavContainer = styled.div`
    width: 100%;
    height: 70px;
    display: flex;
    align-items: center;
    justify-content: center;
    font-family: 'Roboto', sans-serif;
    font-size: 34px;
    p {
        text-decoration: none;
        color: #00274D;
    }
`

const AvaliarPageContainer = styled.div`
    width: 100%;
    height: 100%;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    margin-top: 100px;    
`;

 const DescricaoContainer = styled.div`
    width: 300px;
    height: 200px;
    border: 2px solid #00274D;
    margin-top: 20px;
    resize: none;
    font-family: 'Roboto', sans-serif;
    font-size: 16px;
    display: flex;
    align-items: center;
    justify-content: center;
    background-color: #E5E5E5;
 `

 const DescricaoTextArea = styled.textarea`
    width: 300px;
    height: 198px;
    resize: none;
    background-color: #E5E5E5;
    border: none;
 `
