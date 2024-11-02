import styled from "styled-components";
import { Link, useNavigate } from "react-router-dom";
import React from "react";
import { AvaliacaoEmpresa } from "./AvaliacaoEmpresa";

export default function HomeServicosPage(){
    const navigate = useNavigate();
    // substituir pelo array de servicos
    const quantidadeProvisoriaDeServicos = 5;
    return (
        <HomeServicoContainer>
            <NavContainer >
                <p>Serviços</p> 
            </NavContainer>
            <EmpresaContainer>
            <ServicoContainer>
                    <NomeAvaliacao>
                        <TextoEmpresa>
                            Empresa1
                        </TextoEmpresa>
                        <AvaliacaoEmpresa avaliacaoInicial={3}></AvaliacaoEmpresa>    
                    </NomeAvaliacao>
                    <ServicoAvaliar>
                    <TextoEmpresa>Serviço 1</TextoEmpresa>
                    <Link to="/avaliar"><Avaliar>Avaliar</Avaliar></Link>
                    </ServicoAvaliar>
                    <button>Reservar</button>
                </ServicoContainer>
            </EmpresaContainer>

        </HomeServicoContainer>
        
    )
}

const Avaliar = styled.p`
    color: #00274D;
    font-family: 'Roboto', sans-serif;
    font-size: 12px;
    text-decoration: none;
`

const NomeAvaliacao = styled.div`
    display: flex;
    flex-direction: column;
    justify-content: center;
`

const ServicoAvaliar = styled.div`
    display: flex;
    flex-direction: column;
    justify-content: center;
`

const TextoEmpresa = styled.div`
    width: 100px%;
    display: flex;
    align-items: center;
    justify-content: center;
    color: #00274D;
    font-family: 'Roboto', sans-serif;
    font-size: 18px;
`

const EmpresaContainer = styled.div`
    width: 200px;
    height: 80%;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    button{
        margin: 10px 0px;
        width: 100px;
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
    }
`

const ServicoContainer = styled.div`
    margin: 10px 0px;
    width: 500px;
    height: 100px;
    border: 2px solid #00274D;
    border-radius: 5px;
    color: white;
    font-family: 'Lexend Deca';
    font-style: normal;
    font-weight: 400;
    font-size: 20.976px;
    line-height: 26px;
    text-align: center;
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 5px 15px;
`

const Divider = styled.div`
    margin-top: 15px;
    height: .5px;
    background-color: #333;
    width: 40%;
`;

const HomeServicoContainer = styled.div`
    width: 100%;
    height: 100%;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    margin-top: 100px;
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

const Text = styled.div`
    width: 100%;
    height: 70px;
    display: flex;
    align-items: center;
    justify-content: center;
    color: #00274D;
    font-family: 'Roboto', sans-serif;
    font-size: 18px;
`
