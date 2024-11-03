import styled from "styled-components";
import Logo from "../../assets/image-removebg-preview.png"
import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { BASE_URL } from "../url/BaseUrl";
import Header from "../../Header/Header";
import './AdicionarServicoPage.css'
import TimeSlot from "./TimeSlot";

export default function AdicionarServicoPage (){
    const navigate = useNavigate;

    const timeSlot1 = {
        inicio:"10:30" ,
        fim : "11:30",
        diasSelecionados: [true, true, true, true, true, true, true]
    }
    const timeSlot2 = {
        inicio:"11:45" ,
        fim : "21:30",
        diasSelecionados: [true, false, true, false, true, false, true]
    }
    const timeSlot3 = {
        inicio:"22:30" ,
        fim : "23:59",
        diasSelecionados: [true, false, false, false, false, false, true]
    }
    const timeSlots = [timeSlot1, timeSlot2, timeSlot3]


    return (
        <>
        <Header></Header>

        <p id="TextoAdicione">Adicione o Serviço</p>

        <input
            id="CampoNome"
            placeholder=" Nome do Serviço"
            type="text"
        ></input>

        <div id="TimeSlotsFrame">
            {
                timeSlots.map((elemento) => {
                    return ( <TimeSlot timeSlot={elemento}/> );
                })

            }

            <button id="BotaoAdicionarTimeSlot" onClick={() => navigate("/adicionar-servico")}> Adicione um Time Slot</button>
        </div>



        </>
    );
}


