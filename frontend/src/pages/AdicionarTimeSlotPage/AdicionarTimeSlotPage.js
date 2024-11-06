import styled from "styled-components";
import Logo from "../../assets/image-removebg-preview.png"
import React from "react";
import useState from "react";
import { Link, useNavigate } from "react-router-dom";
import { BASE_URL } from "../url/BaseUrl";
import Header from "../../Header/Header";
import './AdicionarTimeSlotPage.css'
import BotaoDia from "./BotaoDia";
import { postTimeslot } from "../../requests/timeslotRequests";

export default function AdicionarServicoPage (){

    const daysNames = ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sab"]
    const [diasSelecionados, setDiasSelecionados] =
    React.useState([false, false, false, false, false, false, false]);

    const serviceID = localStorage.getItem('selectedServiceID');
    if(!serviceID){
        serviceID = 1;
    }

      const sendTimeSlot = (event) => { 
        event.preventDefault();
        const horaInicio = document.getElementById('CampoHoraInicio').value; 
        console.log(typeof(horaInicio));
        const time = parseInt(horaInicio.slice(0,2),10)*100 + parseInt(horaInicio.slice(-2),10); 
        console.log(time);

    
        enviarTimeSlot({time:time, serviceID:serviceID, bookings:[]});
    }

       const enviarTimeSlot = async (provider) => {
                try {
                    const response = await postTimeslot(provider);
                    console.log(response);
                    alert("Cadastro Realizado com sucesso!!!");
                    navigate('/empresa-home')
                } catch (error) {
                    console.error("Error posting provider", error);
                    alert(error);
                }
            }
 


    
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

            <button id="BotaoFinalizar" onClick={sendTimeSlot}> Finalizar</button>
        </div>



        </>
    );
}


