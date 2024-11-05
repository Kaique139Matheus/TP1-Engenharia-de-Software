import styled from "styled-components";
import Logo from "../../assets/image-removebg-preview.png"
import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { ThreeDots } from "react-loader-spinner";
import { login } from "../../requests/authRequests";


export default function LoginPage ({setUserInfo}){
    const [form, setForm] = React.useState({ email: "", senha: "" })
    const [carregando, setCarregando] = React.useState(false);
    const navigate = useNavigate();
    
    function atualizaForm (event){
        setForm({ ...form, [event.target.name]: event.target.value})
    }

    const efetuarLogin = async (event) => {
        event.preventDefault();
        try {
            setCarregando(true);
            const isProvider = await login(form.email, form.senha);
            if (isProvider) {
                navigate("/empresa-home");
            }
            else {
                navigate("/servicos");
            }
        }
        catch (error) {
            console.error(error);
            alert(error.message);
            window.location.reload();
        }
    }

    // function efetuarLogin(event){
    //     event.preventDefault();
    //     setCarregando(true);
        
    //     const body = {email: form.email, password: form.senha }
    //     navigate("/servicos");

    //     // faz requisicao pra api e navega pra home em caso de sucesso
    //     // axios.post(`${BASE_URL}`, body)
    //     // .then((res) => {
    //     //     setUserInfo(res.data);
    //     //     localStorage.setItem("TOKEN", res.data.token);
    //     //     navigate("/home");
    //     // })
    //     // .catch((err) => {
    //     //     console.log(err);
    //     //     alert(err.response.data.message);
    //     //     window.location.reload();
    //     // })
    // }
    
    return (
        <Login>
            <img src={Logo}
                alt="Logo"
            ></img>
            <FormContainer onSubmit={efetuarLogin}>
                <input 
                    placeholder="Email"
                    type="text"
                    name="email"
                    value={form.email}
                    disabled={carregando}
                    onChange={event => atualizaForm(event)}
                    required    
                ></input>
                <input 
                    placeholder="Senha"
                    type="password"
                    name="senha"
                    disabled={carregando}
                    value={form.senha}
                    onChange={(e) => atualizaForm(e)}
                    required    
                ></input>              
                <button disabled={carregando} type="submit">{carregando ? <ThreeDots 
                        height="40" 
                        width="40" 
                        radius="9"
                        color="white" 
                        ariaLabel="three-dots-loading"
                        wrapperStyle={{}}
                        wrapperClassName=""
                        visible={true}
                    /> : "Entrar"}</button>
               
            </FormContainer>
            <Link to={`/cadastro`}>
                <FraseCadastro>Não tem uma conta? Cadastre-se</FraseCadastro>
            </Link>
        </Login>
    )
}   

const Login = styled.div`z
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

const FraseCadastro = styled.p`
    text-decoration: underline;
    color: #00274D;
`
