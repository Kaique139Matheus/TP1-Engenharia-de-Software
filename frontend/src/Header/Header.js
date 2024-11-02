import styled from "styled-components";
import React, { useState } from "react";
import Logo from "../assets/image-removebg-preview.png"
import fotoCadastro from "../pages/CadastroPage/cadastro_foto.jpg"

export default function Header() {
    const [descricaoText, setDescricao] = useState("")

    return (
        <NavContainer>
            <LogoImg src={Logo}
                alt="Logo"
            ></LogoImg>
            <Text>Nunca foi tão fácil reservar!</Text>
            <PerfilImg src={fotoCadastro}></PerfilImg>
        </NavContainer>
    );
}

const PerfilImg = styled.img`
    width: 50px;
    height: 50px;
`
const LogoImg = styled.img`
    width: 50px;
    height: 50px;
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

const NavContainer = styled.div`
    width: 100%;
    height: 70px;
    display: flex;
    align-items: center;
    justify-content: space-between;
    background-color: #ADD8E6;
    color: #ccc;
    font-family: 'Roboto', sans-serif;
    font-size: 34px;
    position: fixed;
    top: 0;
    padding: 5px 25px;
`