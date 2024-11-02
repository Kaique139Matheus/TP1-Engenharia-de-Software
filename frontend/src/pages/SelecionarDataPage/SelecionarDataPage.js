import styled from "styled-components";
import React, { useState } from "react";
import ReactDatePicker from "react-datepicker"
import "react-datepicker/dist/react-datepicker.css";
import { useNavigate } from "react-router-dom";

export default function SelecionarDataPage() {
    const [date, setDate] = React.useState();
    const navigate = useNavigate();

    function handleSubmit(e){
        e.preventDefault()

    }
    
    return (
        <SelecionarDataContainer>
            <BodyInfos onSubmit={handleSubmit}>
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
`

const SelecionarDataContainer = styled.div`
    width: 100%;
    height: 100%;
    display: flex;
    align-items: center;
    justify-content: space-between;
    color: ##00274D;
    font-family: 'Roboto', sans-serif;
    font-size: 10px;
    position: fixed;
    top: 0;
    padding: 5px 25px;
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

    @media (max-width: 768px) {
        width: 250px;
      }
`

const BodyInfos = styled.form`
    width: 100%;
    height: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    @media (max-width: 768px) {
        width: 250px;
      }
`
