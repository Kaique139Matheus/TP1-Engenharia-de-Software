import styled from "styled-components";
import React from "react";
import "react-datepicker/dist/react-datepicker.css";
import { useNavigate } from "react-router-dom";
import { getBookingsWithTimeFromServiceAndDate, setBooking } from "../../requests/bookingRequests";
import { getLoggedClient } from "../../requests/authRequests";
import { updateBooking } from "../../requests/bookingRequests";


export default function SelecionarHorarioPage() {
    const navigate = useNavigate();
    const [bookingsWithTime, setBookingsWithTime] = React.useState([]);
    const [selectedBookingWithTime, setSelectedBookingsWithTime] = React.useState(null);
    const serviceId = localStorage.getItem("selectedServiceID");
    const selectedDate = localStorage.getItem("selectedDate");
    const [loggedClient, setLoggedClient] = React.useState({});

    React.useEffect(() => {
        async function fetchBookingsWithTime() {
            try {
                const response = await getBookingsWithTimeFromServiceAndDate(serviceId, selectedDate);
                console.log(response);
                setBookingsWithTime(response);
            } catch (error) {
                console.error("Error fetching bookings with time data:", error);
            }
        }

        fetchBookingsWithTime();
    }, [serviceId]);

    React.useEffect(() => {
        async function fetchLoggedClient() {
            try {
                const response = await getLoggedClient();
                console.log(response);
                setLoggedClient(response);
            } catch (error) {
                console.error("Error fetching logged client data:", error);
            }
        }

        fetchLoggedClient();
    }, []);

    const handleCheckboxChange = (bookingWithTime) => {
        if (bookingWithTime.clientID) {
            alert("Horário já reservado");
            return;
        }
        setSelectedBookingsWithTime(bookingWithTime);
    };

    const handleReservarClick = async () => {
        if (!selectedBookingWithTime) {
            alert("Selecione um horário para prosseguir");
            return;
        }
        console.log(selectedBookingWithTime.providerID, selectedBookingWithTime.serviceID, selectedBookingWithTime.timeslotID, selectedDate, loggedClient.id);
        const response = await updateBooking(selectedBookingWithTime.providerID, selectedBookingWithTime.serviceID, selectedBookingWithTime.timeslotID, selectedDate, loggedClient.id);
        alert("Reserva realizada com sucesso!");
        navigate("/cliente-home");
    };

    const getTime = (time) => {
        // time is an integer like 1200, get 12:00
        const timeString = time.toString();
        return timeString.substring(0, timeString.length - 2) + ":" + timeString.substring(timeString.length - 2);
    }

    return (
        <SelecionarHorarioContainer>
            <NavContainer>
                <p>Selecionar Horario</p>
            </NavContainer>
            <OptionsContainer>
                {bookingsWithTime.map(bookingWithTime => (
                    <BookingWithTimeContainer key={bookingWithTime.id}>
                        <TimeText>
                            {getTime(bookingWithTime.time)}
                        </TimeText>
                        <CheckBox>
                            <input
                                type="checkbox"
                                checked={selectedBookingWithTime === bookingWithTime}
                                onChange={() => handleCheckboxChange(bookingWithTime)}
                            />
                        </CheckBox>
                    </BookingWithTimeContainer>
                ))}
            </OptionsContainer>
            <ReservarButton onClick={handleReservarClick}>Reservar</ReservarButton>
        </SelecionarHorarioContainer>
    );
}

const CheckBox = styled.div`
    input {
        width: 20px;
        height: 20px;
    }
`

const TimeText = styled.p`
    font-family: 'Roboto', sans-serif;
    font-size: 28px;
    font-weight: 700;
    color: #00274D;
`

const OptionsContainer = styled.div`
    width: 80%;
    height: 80%;
    display: flex;
    flex-direction: column;
    align-items: center;
    padding: 20px;
    gap: 20px;
`

const BookingWithTimeContainer = styled.div`
    width: 30%;
    height: 60px;
    border: 2px solid #00274D;
    border-radius: 5px;
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 0 10px;
    background-color: #e8e9ff;
`;

const NavContainer = styled.div`
    width: 100%;
    height: 140px;
    display: flex;
    align-items: center;
    justify-content: center;
    font-family: 'Roboto', sans-serif;
    font-size: 34px;
    p {
        text-decoration: none;
        color: #00274D;
    }
`

const ReservarButton = styled.button`
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
    font-size: 20.976px;
    line-height: 26px;
    text-align: center;
    display: flex;
    justify-content: center;
    align-items: center;
`

const SelecionarHorarioContainer = styled.div`
    width: 100%;
    height: 100%;
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: column;
    color: ##00274D;
    font-family: 'Roboto', sans-serif;
    font-size: 10px;
    position: fixed;
    top: 0;
    padding: 5px 25px;
`
