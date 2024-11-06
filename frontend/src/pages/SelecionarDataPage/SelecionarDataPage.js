import styled from "styled-components";
import React from "react";
import ReactDatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import { useNavigate } from "react-router-dom";
import { getBookingsUntilMaxDate, verifyBookingAvailability } from "../../requests/bookingRequests";
import { isSameDay, max, parseISO } from "date-fns";

export default function SelecionarDataPage() {
    const [date, setDate] = React.useState();
    const navigate = useNavigate();
    const [bookings, setBookings] = React.useState([]);
    const serviceId = localStorage.getItem("selectedServiceID");
    const maxDaysInAdvance = 30;

    const handleDateChange = async (date) => {
        console.log(date);
        const response = await verifyBookingAvailability(serviceId, date.toJSON());
        if (!response) {
            alert("Data não disponível para agendamento");
            return;
        }
        console.log(response);
        setDate(date);
        localStorage.setItem("selectedDate", date.toJSON());
    };

    const handleProssigaClick = () => {
        if (!date) {
            alert("Selecione uma data para prosseguir");
            return;
        }
        navigate("/selecionar-horario");
    };

    const tomorrow = new Date();
    tomorrow.setDate(tomorrow.getDate() + 1);

    const maxDate = new Date();
    maxDate.setDate(tomorrow.getDate() + maxDaysInAdvance);

    return (
        <SelecionarDataContainer>
            <BodyInfos>
                <StyledDatePicker
                    placeholderText="Selecione uma data"
                    selected={date}
                    onChange={(date) => handleDateChange(date)}
                    inline
                    required
                    minDate={tomorrow}
                    maxDate={maxDate}
                />
                <ProssigaButton onClick={handleProssigaClick}>
                    Prossiga
                </ProssigaButton>
            </BodyInfos>
        </SelecionarDataContainer>
    );
}

const ProssigaButton = styled.button`
    margin: 10px 0px;
    width: 150px;
    height: 40px;
    border: 1px solid #D4D4D4;
    border-radius: 5px;
    background-color: #00274D;
    color: white;
    font-family: 'Lexend Deca';
    font-style: normal;
    font-weight: 400;
    font-size: 20px;
    line-height: 26px;
    text-align: center;
    display: flex;
    justify-content: center;
    align-items: center;
`;

const SelecionarDataContainer = styled.div`
    width: 100%;
    height: 100%;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    margin-top: 150px;
`;

const BodyInfos = styled.div`
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
`;

const StyledDatePicker = styled(ReactDatePicker)`
    .react-datepicker {
        width: 600px; /* Increase the width of the calendar */
        font-size: 1.2em; /* Increase the font size */
    }

    .react-datepicker__day {
        width: 50px; /* Increase the width of the day cells */
        height: 50px; /* Increase the height of the day cells */
        display: flex;
        align-items: center;
        justify-content: center;
    }

    .react-datepicker__day--booked {
        background-color: red;
        color: white;
    }

    .react-datepicker__day--available {
        background-color: blue;
        color: white;
    }
`;