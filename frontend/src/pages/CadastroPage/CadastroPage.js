import styled from "styled-components";
import Logo from "../../assets/image-removebg-preview.png"
import { Link, useNavigate } from "react-router-dom";
import React from "react";
import { ThreeDots } from "react-loader-spinner";
import fotoCadastro from "./cadastro_foto.jpg"
import { registerClient } from "../../requests/authRequests";

export default function CadastroPage(){
    const [carregando, setCarregando] = React.useState(false);
    const [form, setForm] = React.useState({firstName: "", lastName: "", cpf: "", email: "", password: ""})
    const navigate = useNavigate();

    function atualizaForm(event){
        setForm({...form, [event.target.name]: event.target.value})
    }

    const enviarCliente = async (client) => {
        try {
            const response = await registerClient(client);
                console.log(response);
                //const response2 = await GetAllProviders();
                //console.log(response2);
                //setCarregando(false);
                alert("Cadastro Realizado com sucesso!!!");
                navigate("/cliente-home");
            }catch (error) {
                setCarregando(false);
                console.log(client);
                console.error("Error posting client", error);
                alert(error);
            }
    }



    function efetuarCadastro(event){
        event.preventDefault();
        setCarregando(true);

        const body = {
            firstName: form.firstName,
            lastName: form.lastName,
            cpf: form.cpf,
            email: form.email,
            password: form.password,
            reviews: [],
            bookings: []
        }
        
        enviarCliente(body);
        //navigate("/servicos");

        // faz a requisicao pro cadastro e navega para login em caso de sucesso
        // axios.post(`${BASE_URL}`, body)
        // .then((res) => navigate("/"))
        // .catch((err) => {
        //     alert(err.response.data.message);
        //     window.location.reload();
        // })

    }

    return (
        <Cadastro>
            <img src={Logo}
                alt="Logo"
            ></img>
           
            <FormContainer onSubmit={efetuarCadastro}>
                <input 
                    disabled={carregando}
                    placeholder="Nome"
                    type="text"
                    name="firstName"
                    value={form.firstName}
                    onChange={(event) => atualizaForm(event)}
                    required    
                ></input>
                <input 
                    disabled={carregando}
                    placeholder="Sobrenome"
                    type="text"
                    name="lastName"
                    value={form.lastName}
                    onChange={(event) => atualizaForm(event)}
                    required    
                ></input>
                <input
                    placeholder="CPF"
                    type="number"
                    name="cpf"
                    disabled={carregando}
                    value={form.cpf}
                    onChange={(event) => atualizaForm(event)}
                    required    
                ></input>
                <input
                    placeholder="Email"
                    type="email"
                    name="email"
                    value={form.email}
                    disabled={carregando}
                    onChange={(event) => atualizaForm(event)}
                    required    
                ></input>
                <input
                    placeholder="Senha"
                    type="password"
                    name="password"
                    disabled={carregando}
                    value={form.password}
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
            <Link to={`/login`}>
                <FraseLogin>Já tem uma conta? Faça login! </FraseLogin>
            </Link>
        </Cadastro>
    )
}

const Cadastro = styled.div`
    width: 100%;
    height: 100%;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    margin-top: 100px;

    img{
        width: 180px;
        height: 200px;
    }
`

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

const FraseLogin = styled.p`
    text-decoration: underline;
    color: #00274D;
`
