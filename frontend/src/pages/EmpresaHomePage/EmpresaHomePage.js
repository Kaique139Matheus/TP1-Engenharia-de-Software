import styled from "styled-components";
import Logo from "../../assets/image-removebg-preview.png"
import React from "react";
import { BASE_URL } from "../url/BaseUrl";
import Header from "../../Header/Header";
import { useNavigate } from "react-router-dom";
import { Rating } from "react-simple-star-rating"

import foto_empresa from "./foto_empresa.jpg"
import Servico from "./Servico";

import './EmpresaHomePage.css'
import { getLoggedProvider } from "../../requests/authRequests";
import { getServicesFromProvider } from "../../requests/serviceRequests";
import { deleteService } from "../../requests/serviceRequests";
import { getReviewsFromProvider } from "../../requests/reviewRequests";

export default function EmpresaHomePage (){
    const navigate = useNavigate();
    const [provider, setProvider] = React.useState({});
    const [services, setServices] = React.useState([]);
    const [reviews, setReviews] = React.useState([]);


    React.useEffect(() => {
        async function fetchProvider() {
            try {
                const response = await getLoggedProvider();
                console.log(response);
                setProvider(response);
            } catch (error) {
                console.error("Error fetching provider data:", error);
            }
        }

        fetchProvider();
    }, []);

    React.useEffect(() => {
        async function fetchServices() {
            if (provider.id) {
                try {
                    const response = await getServicesFromProvider(provider.id);
                    console.log(response);
                    setServices(response);
                } catch (error) {
                    console.error("Error fetching services data:", error);
                }
            }
        }

        fetchServices();
    }, [provider.id]);

    React.useEffect(() => {
        async function fetchReviews() {
            if (provider.id) {
                try {
                    const response = await getReviewsFromProvider(provider.id);
                    console.log(response);
                    setReviews(response);
                } catch (error) {
                    console.error("Error fetching reviews data:", error);
                }
            }
        }

        fetchReviews();
    }, [provider.id]);


    async function deleteMeService(id){
        try{            
            console.log(`Deletar serviço ${id}`)
            const response = await deleteService(id);
            console.log(response);
            console.log(`Deletar serviço ${id}`)
            setServices(services.filter( (item) => item.id != id));
        }catch{
            console.error("Error deleting services data:");

        }
    }

    function handleCreateTimeslot(id){
        localStorage.setItem('selectedServiceID', id);
        navigate("/adicionar-timeslot");
    }

    return (
        <>
            <Header></Header>
            <div id="page-frame">
                <img id="foto-empresa" src={foto_empresa} width='220px' height='220px'></img>
                <h1 id="nome-empresa">{provider.name}</h1>
            </div>


            <div id="services-frame">
                {
                    services.map((elemento) => {
                        return ( <Servico nome={elemento.name} descricao={elemento.description} preco={elemento.price}
                        id = {elemento.id} deleteFunction={deleteMeService} timeslots={elemento.timeslots} createTSFunction={handleCreateTimeslot} /> );
                    })
                    // services.map((elemento) => {
                    //     return ( <Servico nome={elemento} />);
                    // })
                }

                <button id="BotaoAdicionarServico" onClick={() => navigate("/adicionar-servico")}> Adicionar Serviço </button>
            </div>

            <ReviewsContainer>
                {reviews.map((review) => (
                    <Review>
                        <TopPart>
                            <ReviewUser>
                                <p>{review.clientFirstName} {review.clientLastName}</p>
                            </ReviewUser>
                            <ReviewRating>
                                <Rating 
                                    readonly
                                    size={24}
                                    initialValue={review.score / 20}
                                    fillColor='gold'
                                    emptyColor='gray'
                                />
                            </ReviewRating>
                        </TopPart>
                        <Div></Div>
                        <ReviewComment>
                            <p>{review.comment}</p>
                        </ReviewComment>
                    </Review>
                ))}
            </ReviewsContainer>

        </>
    );
}



const Div = styled.div`
    width: 98%;
    height: 3px;
    background-color: black;
`;

const ReviewRating = styled.div`
    display: flex;
    justify-content: flex-end;
`;

const ReviewComment = styled.div`
    height: 50px;
    width: 90%;
    display: flex;
    justify-content: flex-start;
    align-items: flex-start;
    text-align: left;
`;

const ReviewUser = styled.div`
    font-size: 24px;
    font-weight: bold;
    display: flex;
    justify-content: center;
`;

const TopPart = styled.div`
    display: flex;
    justify-content: flex-start;
    width: 100%;
    height: 20%;
    padding: 0 10px;
    gap: 30px;
`;

const Review = styled.div`
    height: 100px;
    width: 60%;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    gap: 5px;
    background-color: #e8e9ff;
    border-radius: 10px;
`;

const ReviewsContainer = styled.div`
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    gap: 10px;
    margin-top: 50px;
`;