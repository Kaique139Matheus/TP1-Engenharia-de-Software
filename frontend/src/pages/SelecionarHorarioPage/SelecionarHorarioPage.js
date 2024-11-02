import styled from "styled-components";
import { React } from "react";
import "react-datepicker/dist/react-datepicker.css";
import { useNavigate } from "react-router-dom";

export default function SelecionarHorarioPage() {
    const navigate = useNavigate();
    
    return (
        <SelecionarHorarioContainer>
            <NavContainer >
                    <p>Selecionar Horario</p> 
                </NavContainer>
                <OptionsContainer>
                    <OptionButton>
                        Horario 1
                    </OptionButton>

                    <OptionButton>
                        Horario 2
                    </OptionButton>

                    <OptionButton>
                        Horario 3
                    </OptionButton>
                </OptionsContainer>
                <ReservarButton onClick={() => navigate("/servicos")}>Reservar</ReservarButton>
        </SelecionarHorarioContainer>
    );
}

const OptionsContainer = styled.div`
    width: 80%;
    height: 80%;
    display: flex;
    flex-direction: column;
    align-items: center;
    padding: 20px;
    gap: 20px;
`

const OptionButton = styled.button`
    width: 30%;
    height: 60px;
    border: 2px solid #00274D;
    border-radius: 5px;
`

const NavContainer = styled.div`
    width: 100%;
    height: 70px;
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
