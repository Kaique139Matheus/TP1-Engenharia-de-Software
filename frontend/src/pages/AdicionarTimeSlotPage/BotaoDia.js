import React from "react";
import useState from "react";

import './BotaoDia.css'

export default function BotaoDia({nome, index, selecionado, setSelecionado}){

    return(
        <button className={selecionado ? "BotaoDiaSelecionado":"BotaoDiaNaoSelecionado"} onClick={() => setSelecionado(index, !selecionado)}>
            <p className="NomeDia" style={{color: "rgba(0,39,77,1)"}}>{nome}</p>
        </button>

    );
}
