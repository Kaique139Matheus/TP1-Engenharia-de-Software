import styled from "styled-components";
import React from "react";
import { useNavigate } from "react-router-dom";
import { getLoggedClient } from "../../requests/authRequests";
import Header from "../../Header/Header";
import { getClientBookings, updateBooking } from "../../requests/bookingRequests";
import HomeServicosPage from "../HomeServicosPage/HomeServicosPage";

export default function ClientHomePage() {
    const navigate = useNavigate();
    const [client, setLoggedClient] = React.useState({});
    const [bookings, setBookings] = React.useState([]);

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

    React.useEffect(() => {
        async function fetchClientBookings() {
            if (client.id) {
                try {
                    const response = await getClientBookings(client.id);
                    console.log(response);
                    setBookings(response);
                } catch (error) {
                    console.error("Error fetching client bookings data:", error);
                }
            }
        }

        fetchClientBookings();
    }, [client.id]);


    const getTime = (time) => {
        // time is an integer like 1200, get 12:00
        const timeString = time.toString();
        return timeString.substring(0, timeString.length - 2) + ":" + timeString.substring(timeString.length - 2);
    }

    const cancelarReserva = async (booking) => {
        const response = await updateBooking(booking.providerID, booking.serviceID, booking.timeslotID, booking.date, -1);
        console.log(response);
        if (!response) {
            return;
        }

        alert("Reserva cancelada com sucesso!");
        window.location.reload();
    }

    return(
        <ClientHomePageContainer>
            <Header></Header>
            <NavContainer>
                <p>Olá, {client.firstName} {client.lastName}!</p>
            </NavContainer>
            <BookingsContainer>
                {bookings.length === 0 ? (
                    <NoBookingsText>Você não tem nenhuma reserva.</NoBookingsText>
                ) : (
                    bookings.map((booking) => (
                        <BookingContainer key={booking.id}>
                            <BookingText>
                                <ServiceContainer>
                                    <ServiceName>{booking.serviceName}</ServiceName>
                                    <ProviderName>{booking.providerName}</ProviderName>
                                </ServiceContainer>
                                <DateTime>{getTime(booking.time)}</DateTime>
                                <DateTime>{booking.date}</DateTime>
                                <CancelarButton>
                                    <button onClick={() => cancelarReserva(booking)}>Cancelar</button>
                                </CancelarButton>
                            </BookingText>
                        </BookingContainer>
                    ))
                )}
            </BookingsContainer>
            <HomeServicosPageContainer>
                <button onClick={() => navigate("/servicos")}>Ver serviços</button>
            </HomeServicosPageContainer>
        </ClientHomePageContainer>
    );
}

const DateTime = styled.p`
    font-size: 24px;
`

const NoBookingsText = styled.p`
    font-size: 24px;
    font-weight: bold;
    color: #00274d;
    height: 200px;
    display: flex;
`

const HomeServicosPageContainer = styled.div`
    width: 100%;
    height: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
    button {
        margin: 10px 0px;
        width: 300px;
        height: 45px;
        border: 1px solid #d4d4d4;
        border-radius: 5px;
        background-color: #00274d;
        color: white;
        font-family: "Lexend Deca";
        font-style: normal;
        font-weight: 400;
        font-size: 18px;
        line-height: 26px;
        text-align: center;
        display: flex;
        justify-content: center;
        align-items: center;
    }
`;

const CancelarButton = styled.div`
    button {
        background-color: #aa0000;
        color: white;
        border: none;
        padding: 10px;
        border-radius: 5px;
        cursor: pointer;
    }
`

const ProviderName = styled.p`
    font-size: 16px;
`

const ServiceName = styled.p`
    font-size: 24px;
    font-weight: bold;
`

const ServiceContainer = styled.div`
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
`

const BookingText = styled.div`
    width: 100%;
    height: 100%;
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: space-between;
    p {
        margin: 5px;
    }
`

const BookingContainer = styled.div`
    width: 800px;
    height: 100px;
    display: flex;
    align-items: center;
    justify-content: center;
    border: 1px solid #00274d;
    margin: 10px 0px;
    padding: 10px;
    background-color: #e8e9ff;
`

const BookingsContainer = styled.div`
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    margin-top: 50px
`

const ClientHomePageContainer = styled.div`
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    margin-top: 50px;
`

const NavContainer = styled.div`
    width: 100%;
    height: 100px;
    display: flex;
    align-items: flex-end;
    justify-content: center;
    font-family: "Roboto", sans-serif;
    font-size: 34px;
    p {
        text-decoration: none;
        color: #00274d;
    }
`

