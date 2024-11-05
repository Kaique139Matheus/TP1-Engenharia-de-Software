import styled from "styled-components";
import Logo from "../../assets/image-removebg-preview.png"
import React from "react";
import { BASE_URL } from "../url/BaseUrl";
import Header from "../../Header/Header";
import { useNavigate } from "react-router-dom";

import foto_empresa from "./foto_empresa.jpg"
import Servico from "./Servico";

import './EmpresaHomePage.css'
import { getLoggedProvider } from "../../requests/authRequests";
import { getServicesFromProvider } from "../../requests/serviceRequests";

export default function EmpresaHomePage (){
    const navigate = useNavigate();
    const [provider, setProvider] = React.useState({});
    const [services, setServices] = React.useState([]);


    React.useEffect(() => {
        async function fetchProvider() {
            try {
                const response = await getLoggedProvider();
                console.log(response);
                setProvider(response);
            } catch (error) {
                console.error("Error fetching provider data:", error);
            }
        }

        fetchProvider();
    }, []);

    React.useEffect(() => {
        async function fetchServices() {
            if (provider.id) {
                try {
                    const response = await getServicesFromProvider(provider.id);
                    console.log(response);
                    setServices(response);
                } catch (error) {
                    console.error("Error fetching services data:", error);
                }
            }
        }

        fetchServices();
    }, [provider.id]);

    return (
        <>
            <Header></Header>
            <div id="page-frame">
                <img id="foto-empresa" src={foto_empresa} width='220px' height='220px'></img>
                <h1 id="nome-empresa">{provider.name}</h1>
            </div>

            <div id="services-frame">
                {
                    services.map((elemento) => {
                        return ( <Servico nome={elemento.name} descricao={elemento.description} preco={elemento.price} /> );
                    })
                    // services.map((elemento) => {
                    //     return ( <Servico nome={elemento} />);
                    // })
                }

                <button id="BotaoAdicionarServico" onClick={() => navigate("/adicionar-servico")}> Adicionar Serviço </button>
            </div>

        </>
    );
}
