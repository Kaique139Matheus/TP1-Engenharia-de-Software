import React from "react";
import './TimeSlot.css'

export default function TimeSlot({timeSlot}){

    return (
        <div className="TimeSlot">
            <p className="TextoTimeSlot">{timeSlot.inicio} : {timeSlot.fim}</p>
               
            <button className="BotaoApagarTimeSlot">-</button>
        </div>
    );
}



