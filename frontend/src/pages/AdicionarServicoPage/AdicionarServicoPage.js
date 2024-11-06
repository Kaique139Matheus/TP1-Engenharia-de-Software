import styled from "styled-components";
import Logo from "../../assets/image-removebg-preview.png"
import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { BASE_URL } from "../url/BaseUrl";
import Header from "../../Header/Header";
import './AdicionarServicoPage.css'
import TimeSlot from "./TimeSlot";
import { ThreeDots } from "react-loader-spinner";
import { postService } from "../../requests/serviceRequests";
import { getLoggedProvider } from "../../requests/authRequests";


export default function AdicionarServicoPage (){
    const [carregando, setCarregando] = React.useState(false);
    const [form, setForm] = React.useState({name: "", description: "", price: "", senha: "", duration: ""})
    const [provider, setProvider] = React.useState({});


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





    function atualizaForm(event){
        setForm({...form, [event.target.name]: event.target.value})
    }



    const navigate = useNavigate();

    const timeSlot1 = {
        inicio:"10:30" ,
        fim : "11:30",
        diasSelecionados: [true, true, true, true, true, true, true]
    }
    const timeSlot2 = {
        inicio:"11:45" ,
        fim : "21:30",
        diasSelecionados: [true, false, true, false, true, false, true]
    }
    const timeSlot3 = {
        inicio:"22:30" ,
        fim : "23:59",
        diasSelecionados: [true, false, false, false, false, false, true]
    }
    const timeSlots = [timeSlot1, timeSlot2, timeSlot3]



    const enviarServico = async (servico) => {
        try {
            const response = await postService(servico.name , servico.description, servico.duration, servico.price, provider.id);
            console.log(response); 
            alert("Serviço cadastrado com sucesso!!!");
            // localStorage.setItem('selectedServiceID', response.id);
            // console.log(`Salvar ${response.data.id}`)
            navigate('/empresa-home');
        } catch (error) {
            setCarregando(false);
            console.error("Error posting provider", error);
            alert(error);
        }
    }

    function efetuarCadastro(event){
        event.preventDefault();
        setCarregando(true);

        const body = {
            name: form.name,
            description: form.description,
            price: form.price,
            duration: form.duration
        }

        enviarServico(body);
        setCarregando(false)
    }



    return (
        <>
        <Header></Header>

        <p id="TextoAdicione">Dados do Serviço</p>


        <FormContainer onSubmit={efetuarCadastro}>

        <input
            disabled={carregando}
            placeholder="Nome do Serviço"
            type="text"
            name="name"
            value={form.name}
            onChange={(event) => atualizaForm(event)}
            required
        ></input>

        <input
            disabled={carregando}
            placeholder="Descrição do Serviço"
            type="text"
            name="description"
            value={form.description}
            onChange={(event) => atualizaForm(event)}
            required
        ></input>

        <input
            disabled={carregando}
            placeholder="Preço do Serviço"
            type="number"
            name="price"
            step = "1"
            min = "0"
            value={form.price}
            onChange={(event) => atualizaForm(event)}
            required
        ></input>

        <input
            disabled={carregando}
            placeholder="Duração em minutos do serviço"
            type="number"
            name="duration"
            step = "1"
            min = "0"
            value={form.duration}
            onChange={(event) => atualizaForm(event)}
            required
        ></input>


        <button disabled={carregando} type="submit">{carregando ?
            <ThreeDots
            height="40"
            width="40"
            radius="9"
            color="white"
            ariaLabel="three-dots-loading"
            wrapperStyle={{}}
            wrapperClassName=""
            visible={true}
            /> :
            "Cadastrar"}
        </button>
        </FormContainer>
        

        </>
    );
}


const FormContainer = styled.form`
display: flex;
margin-top: 20px;
flex-direction: column;
align-items: center;
input{
    margin: 10px 0px;
    display: flex;
    align-items: center;
    width: 303px;
    height: 45px;
    border: 1px solid #D4D4D4;
    border-radius: 5px;
    font-family: 'Lexend Deca';
    font-style: normal;
    font-weight: 400;
    font-size: 19.976px;
    line-height: 25px;
}
button{
    margin: 10px 0px;
    width: 170px;
    height: 45px;
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
}
`

