import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import LoginPage from "./pages/LoginPage/LoginPage"
import CadastroPage from "./pages/CadastroPage/CadastroPage";
import UserContext from "./contexts/UserContext";
import HomePage from "./pages/HomePage/HomePage";
import HomeServicosPage from "./pages/HomeServicosPage/HomeServicosPage";
import AvaliarPage from "./pages/AvaliarPage/AvaliarPage"
import SelecionarDataPage from "./pages/SelecionarDataPage/SelecionarDataPage";

export default function App() {
  
  const [userInfo, setUserInfo] = React.useState({});

  return (
    <UserContext.Provider value={{userInfo}}>
      <BrowserRouter>
        <Routes>
          <Route path={`/login`} element={<LoginPage setUserInfo={setUserInfo}></LoginPage>}></Route>
          <Route path={`/cadastro`} element={<CadastroPage></CadastroPage>}></Route>
          <Route path={`/`} element={<HomePage></HomePage>}></Route>
          <Route path={`/avaliar`} element={<AvaliarPage></AvaliarPage>}></Route>
          <Route path={`/servicos`} element={<HomeServicosPage></HomeServicosPage>}></Route>
          <Route path={`/selecionar-data`} element={<SelecionarDataPage></SelecionarDataPage>}></Route>
        </Routes>
      </BrowserRouter>
    </UserContext.Provider>
  );
}

