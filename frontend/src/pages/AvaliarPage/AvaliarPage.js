import styled from "styled-components";
import React, { useState } from "react";
import { AvaliacaoEstrelas } from "./AvaliacaoEstrelas";
import { useNavigate } from "react-router-dom";
import { postReview } from "../../requests/reviewRequests"; // Importando o método de envio
import { getLoggedClient } from "../../requests/authRequests";

export default function AvaliarPage() {
  const navigate = useNavigate();
  const [descricaoText, setDescricao] = useState("");
  const [providerID, setProviderID] = useState(1); // Exemplo de ID do provedor
  const [client, setClient] = useState(1); // Exemplo de ID do cliente
  const [score, setScore] = useState(0); // Pontuação da avaliação

  React.useEffect(() => {
    async function fetchProvider() {
      try {
        const response = await getLoggedClient();
        console.log(response);
        setClient(response);
      } catch (error) {
        console.error("Error fetching provider data:", error);
      }
    }

    fetchProvider();
  }, []);

  React.useEffect(() => {
    // Recupera o item do localStorage
    const providerarmazenado = localStorage.getItem("providerID");

    // Verifica se o item existe
    if (providerarmazenado) {
      // Converte para JSON, pega o valor e transforma em int
      const parsedprovider = JSON.parse(providerarmazenado);
      const providerid = parseInt(parsedprovider, 10);
      setProviderID(providerid);
    }
  }, []);

  function onDescricaoChanged(event) {
    setDescricao(event.target.value);
  }

  async function handleAvaliar() {
    try {
      // Envia os dados para a API
      await postReview(client.id, providerID, score, descricaoText);
      // Redireciona para a página de serviços após a avaliação
      navigate("/servicos");
    } catch (error) {
      console.error("Erro ao enviar avaliação:", error);
    }
  }

  return (
    <AvaliarPageContainer>
      <NavContainer>
        <p>Avalie a Empresa</p>
      </NavContainer>
      <AvaliacaoEstrelas setScore={setScore} />
      <DescricaoContainer>
        {descricaoText === "" ? (
          <Text onClick={() => setDescricao("...")}>Descrição</Text>
        ) : (
          <DescricaoTextArea
            value={descricaoText}
            onChange={onDescricaoChanged}
            rows={10}
          />
        )}
      </DescricaoContainer>
      <AvaliarBotao onClick={handleAvaliar}>Avaliar</AvaliarBotao>
    </AvaliarPageContainer>
  );
}

// Estilos com styled-components
const Text = styled.div`
  width: 100px;
  height: 70px;
  display: flex;
  align-items: center;
  justify-content: center;
  color: #00274d;
  font-family: "Roboto", sans-serif;
  font-size: 15px;
`;

const AvaliarBotao = styled.button`
  margin: 10px 0px;
  width: 170px;
  height: 45px;
  border: 1px solid #d4d4d4;
  border-radius: 5px;
  background-color: #00274d;
  color: white;
  font-family: "Lexend Deca";
  font-style: normal;
  font-weight: 400;
  font-size: 20.976px;
  line-height: 26px;
  text-align: center;
  display: flex;
  justify-content: center;
  align-items: center;
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

const AvaliarPageContainer = styled.div`
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  margin-top: 100px;
`;

const DescricaoContainer = styled.div`
  width: 300px;
  height: 200px;
  border: 2px solid #00274d;
  margin-top: 20px;
  resize: none;
  font-family: "Roboto", sans-serif;
  font-size: 16px;
  display: flex;
  align-items: center;
  justify-content: center;
  background-color: #e5e5e5;
`;

const DescricaoTextArea = styled.textarea`
  width: 300px;
  height: 198px;
  resize: none;
  background-color: #e5e5e5;
  border: none;
`;
