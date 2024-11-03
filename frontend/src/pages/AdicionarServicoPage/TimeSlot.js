import React from "react";
import Day from "./Day";

import './TimeSlot.css'

export default function TimeSlot({timeSlot}){

    return (
        <div className="TimeSlot">
            <p className="TextoTimeSlot">{timeSlot.inicio} : {timeSlot.fim}</p>
                <flex className="DaysList">
                    {
                        timeSlot.dias.map((elemento) => {
                            return(<Day dia={elemento}/>)
                        })
                    }
                </flex>
            <button className="BotaoApagarTimeSlot">-</button>
        </div>
    );
}



