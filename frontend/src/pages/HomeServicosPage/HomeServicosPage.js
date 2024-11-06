import styled from "styled-components";
import { Link, useNavigate } from "react-router-dom";
import React from "react";
import { AvaliacaoEmpresa } from "./AvaliacaoEmpresa";
import Header from "../../Header/Header";
import { getAllServices } from "../../requests/serviceRequests";

export default function HomeServicosPage() {
  const navigate = useNavigate();
  const [servicesWithProviders, setServicesWithProviders] = React.useState([]);

  React.useEffect(() => {
    getAllServices()
      .then((servicesWithProviders) => {
        for (let i = 0; i < servicesWithProviders.length; i++) {
          console.log(servicesWithProviders[i]);
        }
        setServicesWithProviders(servicesWithProviders);
      })
      .catch((error) => {
        console.error("Error fetching services:", error);
      });
  }, []);

  const reservarClick = (nomeVar, id) => {
    localStorage.setItem(nomeVar, id);
  };

  // substituir pelo array de servicos

  return (
    <HomeServicoContainer>
      <Header></Header>
      <NavContainer>
        <p>Serviços</p>
      </NavContainer>
      <EmpresasContainer>
        {servicesWithProviders.map((serviceWithProvider) => (
          <ServicoContainer>
            <NomeAvaliacao>
              <TextoEmpresa>{serviceWithProvider.providerName}</TextoEmpresa>
              <AvaliacaoEmpresa
                avaliacaoInicial={serviceWithProvider.avaliacao}
              ></AvaliacaoEmpresa>
            </NomeAvaliacao>
            <ServicoInfo>
              <TextoEmpresa>{serviceWithProvider.serviceName}</TextoEmpresa>
              <TextoDescricao>
                {serviceWithProvider.serviceDescription}
              </TextoDescricao>
            </ServicoInfo>
            <ServicoPreco>
              <TextoEmpresa>R${serviceWithProvider.servicePrice}</TextoEmpresa>
            </ServicoPreco>
            <ServicoBotoes>
              <button onClick={() => {
                reservarClick("selectedServiceID" ,serviceWithProvider.serviceID);
                navigate("/selecionar-data");
              }}>
                Reservar
              </button>
              <ServicoAvaliar>
                <h1
                  onClick={() => {
                    reservarClick("providerID", serviceWithProvider.providerID);
                    navigate("/avaliar");
                  }}
                >
                  Avaliar
                </h1>
              </ServicoAvaliar>
            </ServicoBotoes>
          </ServicoContainer>
        ))}
      </EmpresasContainer>
    </HomeServicoContainer>
  );
}

const Avaliar = styled.p`
  color: #00274d;
  font-family: "Roboto", sans-serif;
  font-size: 12px;
  text-decoration: none;
`;

const NomeAvaliacao = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: center;
`;

const ServicoInfo = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: center;
`;

const ServicoPreco = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: center;
`;

const ServicoAvaliar = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: center;
`;

const ServicoBotoes = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
`;

const TextoEmpresa = styled.div`
  width: 100%;
  display: flex;
  align-items: center;
  justify-content: left;
  color: #00274d;
  font-family: "Roboto", sans-serif;
  font-size: 18px;
`;

const TextoDescricao = styled.div`
  width: 100%;
  display: flex;
  align-items: center;
  justify-content: center;
  color: #00274d;
  font-family: "Roboto", sans-serif;
  font-size: 12px;
`;

const EmpresasContainer = styled.div`
  width: 80%;
  height: 80%;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  button {
    margin: 10px 0px;
    width: 100px;
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

const ServicoContainer = styled.div`
  margin: 10px 0px;
  width: 1000px;
  height: 100px;
  border: 2px solid #00274d;
  border-radius: 5px;
  color: white;
  font-family: "Lexend Deca";
  font-style: normal;
  font-weight: 400;
  font-size: 20.976px;
  line-height: 26px;
  text-align: center;
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 5px 15px;
`;

const HomeServicoContainer = styled.div`
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  margin-top: 150px;
`;
const NavContainer = styled.div`
  width: 100%;
  height: 70px;
  display: flex;
  align-items: center;
  justify-content: center;
  font-family: "Roboto", sans-serif;
  font-size: 34px;
  p {
    text-decoration: none;
    color: #00274d;
  }
`;
