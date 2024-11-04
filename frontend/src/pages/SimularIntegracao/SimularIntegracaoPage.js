import styled from "styled-components";
import Logo from "../../assets/image-removebg-preview.png"
import { Link, useNavigate } from "react-router-dom";
import React from "react";
import { useState } from "react";
import axios from "axios";


export default function SimularIntegracaoPage(){
    const [data, setData] = useState(null);

    function getRequest(){
        axios.get('http://localhost:1080/api/data')
        .then(response => {
            console.log(response.data);
            setData(response.data);
        })
        .catch(error => {
            console.error('Error:', error);
        });
    }


    const navigate = useNavigate();

    return (
      <button onClick={ ()=> getRequest()}>
        Help
        {data && (
            <div>
            <h3>{data.message}</h3>
            </div>
            )
        }
      </button>

    )
}

