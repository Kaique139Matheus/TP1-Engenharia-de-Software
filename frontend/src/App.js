import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import LoginPage from "./pages/LoginPage/LoginPage"
import CadastroPage from "./pages/CadastroPage/CadastroPage";
import UserContext from "./contexts/UserContext";
import HomePage from "./pages/HomePage/HomePage";

export default function App() {
  
  const [userInfo, setUserInfo] = React.useState({});

  return (
    <UserContext.Provider value={{userInfo}}>
      <BrowserRouter>
        <Routes>
          <Route path={`/login`} element={<LoginPage setUserInfo={setUserInfo}></LoginPage>}></Route>
          <Route path={`/cadastro`} element={<CadastroPage></CadastroPage>}></Route>
          <Route path={`/`} element={<HomePage></HomePage>}></Route>
        </Routes>
      </BrowserRouter>
    </UserContext.Provider>
  );
}

