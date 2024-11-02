import styled from "styled-components";
import Logo from "../../assets/image-removebg-preview.png"
import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { BASE_URL } from "../url/BaseUrl";

import foto_empresa from "./foto_empresa.jpg"
import Servico from "./Servico";

import './EmpresaHomePage.css'

export default function EmpresaHomePage (){


    const servicesArray = ['Serviço 1', 'Serviço 2', 'Serviço 3'];


    return (
        <>

            <div id="page-frame">
                <img id="foto-empresa" src={foto_empresa} width='220px' height='220px'></img>
                <h1 id="nome-empresa">Nome da Empresa</h1>
            </div>

            <div id="services-frame">
                {
                    servicesArray.map((elemento) => {
                        return ( <Servico nome={elemento} />);
                    })
                }

                <button id="BotaoAdicionarServico"> Adicionar Serviço </button>
            </div>

        </>
    );
}
