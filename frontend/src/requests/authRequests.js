import axios from 'axios';

const API_URL = 'http://localhost:5000'; // ASP.NET Core backend URL

export const login = async (email, password) => {
    try {
        const response = await axios.post(`${API_URL}/auth/login`, { email, password });
        return response.data;
    } catch (error) {
        throw error.response.data;
    }
};

export const registerClient = async (clientData) => {
    try {
        const response = await axios.post(`${API_URL}/auth/register/client`, clientData);
        return response.data;
    } catch (error) {
        throw error.response.data;
    }
};
