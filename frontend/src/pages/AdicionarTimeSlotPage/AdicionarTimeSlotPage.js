import styled from "styled-components";
import Logo from "../../assets/image-removebg-preview.png"
import React from "react";
import useState from "react";
import { Link, useNavigate } from "react-router-dom";
import { BASE_URL } from "../url/BaseUrl";
import Header from "../../Header/Header";
import './AdicionarTimeSlotPage.css'
import BotaoDia from "./BotaoDia";

export default function AdicionarServicoPage (){

    const daysNames = ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sab"]
    const [diasSelecionados, setDiasSelecionados] =
    React.useState([false, false, false, false, false, false, false]);

    const navigate = useNavigate();

    function setDiaSelecionadoViaIndex(index,novoValor){
        let temp = [... diasSelecionados]
        temp[index] = novoValor
        setDiasSelecionados(temp)
    };

    return (
        <>
        <Header></Header>


        <p id="TextoAdicione">Crie um TimeSlot</p>




        <div id="Frame">









            <div id="TimeFlex">
                <div className="ItemHoraLegenda">
                    <input
                        className="CampoHora"
                        id="CampoHoraInicio"
                        type="time"
                    ></input>
                    <p className="LegendaCampoHora" id="HoraInicio">Horário de Início</p>
                </div>
            </div>

            <button id="BotaoFinalizar" onClick={() => navigate("/empresa-home")}> Finalizar</button>
        </div>



        </>
    );
}


