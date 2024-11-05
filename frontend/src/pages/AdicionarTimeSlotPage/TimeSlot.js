import React from "react";
import Day from "./Day";

import './TimeSlot.css'

export default function TimeSlot({timeSlot}){
    const daysNames = ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sab"]

    return (
        <div className="TimeSlot">
            <p className="TextoTimeSlot">{timeSlot.inicio} : {timeSlot.fim}</p>
                <flex className="DaysList">
                    {
                        timeSlot.diasSelecionados.map((elemento, index) => {
                            var dia = [daysNames[index], elemento]
                            return(<Day dia={dia}/>)
                        })
                    }
                </flex>
            <button className="BotaoApagarTimeSlot">-</button>
        </div>
    );
}



