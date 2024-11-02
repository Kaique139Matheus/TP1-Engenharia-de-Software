import React from "react";
import './Servico.css';

export default function Servico({nome}){
    return(
        <div className="Servico">
            <h1 className="NomeServico">{nome}</h1>
            <button className="BotaoApagarServico">-</button>
        </div>
    );
}
