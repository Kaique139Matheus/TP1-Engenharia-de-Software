import React from "react";
import './Servico.css';
import SmallTimeSlot from "./SmallTimeSlot";


export default function Servico({nome, id, descricao, preco, deleteFunction}){
    return(
        <div className="Servico">
            <div id="info">
            <h1 className="NomeServico">{nome}</h1>
            <h2 className="Descricao">{descricao}</h2>
            <h2 className="Preco">R$ {preco},00</h2>
            <button className="BotaoApagarServico" onClick={() => deleteFunction(id)}>-</button>
            </div>

            <div className="TimeslotsList">
                <SmallTimeSlot/>
            </div>
        </div>
    );
}
