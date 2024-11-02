import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import LoginPage from "./pages/LoginPage/LoginPage"
import CadastroPage from "./pages/CadastroPage/CadastroPage";
import UserContext from "./contexts/UserContext";

export default function App() {
  
  const [userInfo, setUserInfo] = React.useState({});

  return (
    <UserContext.Provider value={{userInfo}}>
      <BrowserRouter>
        <Routes>
          <Route path={`/`} element={<LoginPage setUserInfo={setUserInfo}></LoginPage>}></Route>
          <Route path={`/cadastro`} element={<CadastroPage></CadastroPage>}></Route>
        </Routes>
      </BrowserRouter>
    </UserContext.Provider>
  );
}

