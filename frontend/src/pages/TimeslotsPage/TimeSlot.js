import React from "react";
import './TimeSlot.css'

export default function TimeSlot({timeSlot}, duration){
    const horaInicioNumber = Math.floor(parseInt(timeSlot.time)/100);
    const minutoInicioNumber = parseInt(timeSlot.time)- horaInicioNumber*100;

    
    let horaInicioStr = (horaInicioNumber.toString());
    if(horaInicioNumber < 10){horaInicioStr = "0".concat(horaInicioStr)};
    let minutoInicioStr = (minutoInicioNumber.toString());
    if(minutoInicioNumber < 10){minutoInicioStr = "0".concat(minutoInicioStr)};




    return (
        <div className="TimeSlot">
            <p className="TextoTimeSlot">{horaInicioStr}:{minutoInicioStr}</p>
               
            <button className="BotaoApagarTimeSlot" onClick={alert(duration)}></button>
        </div>
    );
}



