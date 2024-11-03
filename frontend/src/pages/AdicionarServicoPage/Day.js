import React from "react";
import './Day.css'
export default function Day({dia}){
    if(dia[1]){
        return(
            <div className="DayBlockSelecionado">
            <p className="DayText">{dia[0]}</p>
            </div>
        );
    }
    else{
        return(
            <div className="DayBlockNaoSelecionado">
            </div>
        );

    }

}




