import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import UserContext from "./contexts/UserContext";


import LoginPage from "./pages/LoginPage/LoginPage"
import CadastroPage from "./pages/CadastroPage/CadastroPage";
import EmpresaHomePage from "./pages/EmpresaHomePage/EmpresaHomePage";
import HomePage from "./pages/HomePage/HomePage";
import HomeServicosPage from "./pages/HomeServicosPage/HomeServicosPage";
import AvaliarPage from "./pages/AvaliarPage/AvaliarPage"
import SelecionarDataPage from "./pages/SelecionarDataPage/SelecionarDataPage";
import SelecionarHorarioPage from "./pages/SelecionarHorarioPage/SelecionarHorarioPage";
import AdicionarServicoPage from "./pages/AdicionarServicoPage/AdicionarServicoPage";
import AdicionarTimeSlotPage from "./pages/AdicionarTimeSlotPage/AdicionarTimeSlotPage";
import LoginEmpresarialPage from "./pages/LoginEmpresarialPage/LoginEmpresarialPage"
import CadastroEmpresarialPage from "./pages/CadastroEmpresarialPage/CadastroEmpresarialPage";
import SimularIntegracaoPage from "./pages/SimularIntegracao/SimularIntegracaoPage"

export default function App() {
  
  const [userInfo, setUserInfo] = React.useState({});

  return (
    <UserContext.Provider value={{userInfo}}>
      <BrowserRouter>
        <Routes>
          <Route path={`/login`} element={<LoginPage setUserInfo={setUserInfo}></LoginPage>}></Route>
          <Route path={`/cadastro`} element={<CadastroPage></CadastroPage>}></Route>
          <Route path={`/empresa-home`} element={<EmpresaHomePage></EmpresaHomePage>}></Route>
          <Route path={`/`} element={<HomePage></HomePage>}></Route>
          <Route path={`/avaliar`} element={<AvaliarPage></AvaliarPage>}></Route>
          <Route path={`/servicos`} element={<HomeServicosPage></HomeServicosPage>}></Route>
          <Route path={`/selecionar-data`} element={<SelecionarDataPage></SelecionarDataPage>}></Route>
          <Route path={`/selecionar-horario`} element={<SelecionarHorarioPage></SelecionarHorarioPage>}></Route>
          <Route path={`/adicionar-servico`} element={<AdicionarServicoPage></AdicionarServicoPage>}></Route>
          <Route path={`/adicionar-timeslot`} element={<AdicionarTimeSlotPage></AdicionarTimeSlotPage>}></Route>
          <Route path={`/login-empresarial`} element={<LoginEmpresarialPage setUserInfo={setUserInfo}></LoginEmpresarialPage>}></Route>
          <Route path={`/cadastro-empresarial`} element={<CadastroEmpresarialPage></CadastroEmpresarialPage>}></Route>
          <Route path={`/integracao`} element={<SimularIntegracaoPage></SimularIntegracaoPage>}></Route>


        </Routes>
      </BrowserRouter>
    </UserContext.Provider>
  );
}

