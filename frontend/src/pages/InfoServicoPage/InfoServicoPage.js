import styled from "styled-components";
import Logo from "../../assets/image-removebg-preview.png"
import React from "react";
import { BASE_URL } from "../url/BaseUrl";
import Header from "../../Header/Header";
import { useNavigate } from "react-router-dom";

import foto_empresa from "./foto_empresa.jpg"

import './InfoServicoPage.css'
import { getLoggedProvider } from "../../requests/authRequests";
import { getServicesFromProvider } from "../../requests/serviceRequests";
import { deleteService } from "../../requests/serviceRequests";

export default function EmpresaHomePage (){
    const navigate = useNavigate();
    const [provider, setProvider] = React.useState({});
    const [services, setServices] = React.useState([]);
    const [service, setService] = React.useState([]);

    


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

    React.useEffect(() => {
        setService(services[0]);
    }, [sevices]);


    return (
        <>
            <Header></Header>
            <div id="page-frame">
                <h1 id="nome-servico">{servico.name}</h1>
            </div>


            <div id="services-frame">
                {
                    services.map((elemento) => {
                        return ( <Servico nome={elemento.name} descricao={elemento.description} preco={elemento.price}
                        id = {elemento.id} deleteFunction={deleteMeService}/> );
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
