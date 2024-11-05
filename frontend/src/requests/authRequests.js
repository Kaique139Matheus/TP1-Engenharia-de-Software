import axios from 'axios';

const API_URL = 'http://localhost:5000'; // ASP.NET Core backend URL

export const login = async (email, password) => {
    try {
        const isProvider = await axios.post(`${API_URL}/auth/login`, { email, password });
        return isProvider.data;
    } catch (error) {
        throw error.response.data;
    }
};

export const logout = async () => {
    try {
        const response = await axios.post(`${API_URL}/auth/logout`);
        return response.data;
    } catch (error) {
        throw error.response.data;
    }
};

export const getLoggedProvider = async () => {
    try {
        const response = await axios.get(`${API_URL}/auth/loggedProvider`);
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

export const registerProvider = async (providerData) => {
    try {
        const response = await axios.post(`${API_URL}/auth/register/provider`, providerData);
        return response.data;
    } catch (error) {
        throw error.response.data;
    }
};
