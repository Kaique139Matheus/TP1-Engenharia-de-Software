import styled from "styled-components";
import React from "react";
import ReactDatePicker from "react-datepicker"
import "react-datepicker/dist/react-datepicker.css";
import { useNavigate } from "react-router-dom";

export default function SelecionarDataPage() {
    const [date, setDate] = React.useState();
    const navigate = useNavigate();
    
    return (
        <SelecionarDataContainer>
            <BodyInfos>
                    <DatePicker 
                        placeholderText="Selecione uma data"
                        selected={date}
                        onChange={(date) => setDate(date)}
                        required
                    />                    
                    <ProssigaButton onClick={() => navigate("/selecionar-horario")}>Prossiga</ProssigaButton>
                </BodyInfos>
        </SelecionarDataContainer>
    );
}

const ProssigaButton = styled.button`
    margin: 10px 0px;
    width: 150px;
    height: 40px;
    border: 1px solid #D4D4D4;
    border-radius: 5px;
    background-color: #00274D;
    color: white;
    font-family: 'Lexend Deca';
    font-style: normal;
    font-weight: 400;
    font-size: 20px;
    line-height: 26px;
    text-align: center;
    display: flex;
    justify-content: center;
    align-items: center;
`

const SelecionarDataContainer = styled.div`
    width: 100%;
    height: 100%;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    margin-top: 250px;
`

const DatePicker = styled(ReactDatePicker)`
    margin-bottom: 15px;
    border-radius: 10px;
    border: 1px solid grey;
    width: 400px;
    height: 40px;
    padding: 10px;
    font-weight: 400;
    font-size: large;
    text-align: center;
`

const BodyInfos = styled.form`
    width: 100%;
    height: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
`
