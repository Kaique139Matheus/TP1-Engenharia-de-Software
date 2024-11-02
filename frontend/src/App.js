import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import LoginPage from "./pages/LoginPage/LoginPage"
import CadastroPage from "./pages/CadastroPage/CadastroPage";
import HojePage from "./pages/HojePage/HojePage";
import HabitosPage from "./pages/HabitosPage/HabitosPage";
import UserContext from "./contexts/UserContext";
import HistoricoPage from "./pages/HistoricoPage/HistoricoPage";

export default function App() {
  
  const [userInfo, setUserInfo] = React.useState({});z

  return (
    <UserContext.Provider value={{userInfo, habitosAPI, porcentagem}}>
      <BrowserRouter>
        <Routes>
          <Route path={`/`} element={<LoginPage setUserInfo={setUserInfo}></LoginPage>}></Route>
          <Route path={`/cadastro`} element={<CadastroPage></CadastroPage>}></Route>
        </Routes>
      </BrowserRouter>
    </UserContext.Provider>
  );
}

