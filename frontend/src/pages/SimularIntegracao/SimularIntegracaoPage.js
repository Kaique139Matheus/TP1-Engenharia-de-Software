import styled from "styled-components";
import Logo from "../../assets/image-removebg-preview.png"
import { Link, useNavigate } from "react-router-dom";
import React from "react";
import { useState } from "react";
import axios from "axios";


export default function SimularIntegracaoPage(){
    const [data, setData] = useState(null);
    const [provider, setProvider] = useState(null);


    function getRequest(){
        axios.get('http://localhost:5000/Providers')
        .then(response => {
            console.log(response.data);
            setData(response.data);
        })
        .catch(error => {
            console.error('Error:', error);
        });
    }

    function getProvider(id){
        axios.get(`http://localhost:5000/Providers/${id}`)
        .then(response => {
            console.log(response.data);
            setProvider(response.data);
        })
        .catch(error => {
            console.error('Error:', error);
        });
    }


    const navigate = useNavigate();

    return (
        <>
            <button onClick={ ()=> getRequest()}>
            Help
            {data && (
                <div>
                <h3>{data[1].name}</h3>
                </div>
            )
            }
            </button>

            <button onClick={ ()=> getProvider(2)}>
            Help
            {provider && (
                <div>
                <h3>{provider.name}</h3>
                </div>
            )
            }
            </button>
        </>



    )
}


