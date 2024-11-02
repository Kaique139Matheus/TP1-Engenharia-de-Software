import styled from "styled-components";
import React, { useState } from "react";
import Logo from "../assets/image-removebg-preview.png"
import fotoCadastro from "../pages/CadastroPage/cadastro_foto.jpg"

export default function Header() {
    // mudar condicao booleana para aparecer logout
    const [usuarioLogado, setUsuarioLogado] = useState(true)
    
    return (
        <NavContainer>
            <LogoImg src={Logo}
                alt="Logo"
            ></LogoImg>
            <Text>Nunca foi tão fácil reservar!</Text>
            {usuarioLogado ? 
            <PerfilImg src={fotoCadastro}></PerfilImg> : 
            <LogoutContainer>Logout</LogoutContainer>
            }
        </NavContainer>
    );
}

const PerfilImg = styled.img`
    width: 50px;
    height: 50px;
    border-radius: 5px;
`
const LogoImg = styled.img`
    width: 65px;
    height: 65px;
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
    color: ##00274D;
    font-family: 'Roboto', sans-serif;
    font-size: 10px;
    position: fixed;
    top: 0;
    padding: 5px 25px;
`

const LogoutContainer = styled.div`
    width: 50px;
    height: 50px;
    display: flex;
    align-items: center;
    justify-content: space-between;
    border: 1px solid #00274D;
    border-radius: 5px;
    padding: 10px;
`