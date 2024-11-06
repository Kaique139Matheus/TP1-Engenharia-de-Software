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
                    {  

                            timeslots.map((elemento) => {
                                return(
                                    <div>
                                        {elemento.time}
                                    </div>
                                );
                            })
                        } 

                    <button onClick={() => createTSFunction(id)}>
                        Adicione TimeSlot
                    </button>
                </div>
            
                <button className="BotaoApagarServico" onClick={() => deleteFunction(id)}>-</button>
            </div>
        </div>
    );
}
