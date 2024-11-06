import styled from "styled-components";
import Logo from "../../assets/image-removebg-preview.png"
import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { BASE_URL } from "../url/BaseUrl";
import Header from "../../Header/Header";
import './TimeslotsPage.css'
import TimeSlot from "./TimeSlot";
import { ThreeDots } from "react-loader-spinner";
import { postService } from "../../requests/serviceRequests";
import { getLoggedProvider } from "../../requests/authRequests";
import { getTimeslotsFromService } from "../../requests/timeslotRequests";

//"./pages/TimeslotsPage/TimeslotsPage"

export default function TimeslotsPage (){
    const [carregado, setCarregado] = React.useState(false);
    const [form, setForm] = React.useState({name: "", description: "", price: "", senha: "", duration: ""})
    const [timeslots, setTimeslots] = React.useState({});
    let duration = 0;

    

    
    React.useEffect(() => {
        async function fetchTimeslots() {
            try {
                const selectedServiceID = localStorage.getItem('selectedServiceID');
                 duration = localStorage.getItem('duration');
                 console.log(`DURACAO ${duration}`)

                const response = await getTimeslotsFromService(selectedServiceID);
                console.log(response);
                setTimeslots(response);
                setCarregado(true);
            } catch (error) {
                console.error("Error fetching provider data:", error);
            }
        }
        console.log("FEEEETCH");
        fetchTimeslots();
    }, []);





    const navigate = useNavigate();

  


       


    return (
        <>
        <Header></Header>
        
        <p id="TextoAdicione"> TimeSlots de NOME </p>
        <div id="TimeSlotsFrame">
            {
                Object.keys(timeslots).length > 0 ? (
                    timeslots.map((elemento) => (
                        <TimeSlot timeSlot={elemento} duration={duration}/>
                    
                    ))
                )
                 : <p>Carregannndo</p>
            }
            <button id="BotaoAdicionarTimeSlot" onClick={() => navigate("/adicionar-timeslot")}> Adicione um Time Slot</button>
        </div>

        

        </>
    );
}


const FormContainer = styled.form`
display: flex;
margin-top: 20px;
flex-direction: column;
align-items: center;
input{
    margin: 10px 0px;
    display: flex;
    align-items: center;
    width: 303px;
    height: 45px;
    border: 1px solid #D4D4D4;
    border-radius: 5px;
    font-family: 'Lexend Deca';
    font-style: normal;
    font-weight: 400;
    font-size: 19.976px;
    line-height: 25px;
}
button{
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
}
`


