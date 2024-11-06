import styled from "styled-components";
import React from "react";
import { Link, useNavigate } from "react-router-dom";

import './Servico.css';

export default function Servico({nome, id, descricao, preco, deleteFunction, timeslots, createTSFunction}){

    if(!timeslots){
        timeslots = [];
    }

    return(
        <div className="Servico">
            <div id="info">
                <h1 className="NomeServico">{nome}</h1>
                <h2 className="Descricao">{descricao}</h2>
                <h2 className="Preco">R$ {preco},00</h2>
            </div>
            <div>
                <div>
                    {timeslots.map((elemento) => {
                        return(
                            <div>
                                {elemento.time}
                            </div>
                        );
                    })}
                </div>
            
                <div className="AdicionarTimeslot">
                    <button onClick={() => createTSFunction(id)}>Adicione TimeSlot</button>
                </div>
                <button className="BotaoApagarServico" onClick={() => deleteFunction(id)}>-</button>
            </div>
        </div>
    );
}

const AddTimeslotButton = styled.div`
    width: 100%;
    height: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
    button {
        margin: 10px 0px;
        width: 200px;
        height: 45px;
        border: 1px solid #d4d4d4;
        border-radius: 5px;
        background-color: #00274d;
        color: white;
        font-family: "Lexend Deca";
        font-style: normal;
        font-weight: 400;
        font-size: 18px;
        line-height: 26px;
        text-align: center;
        display: flex;
        justify-content: center;
        align-items: center;
    }
`;
