import axios from "axios";

const API_URL = "http://localhost:5000"; // ASP.NET Core backend URL

export const getAllServices = async () => {
    try {
        const response = await axios.get(`${API_URL}/services/getAll`);
        return response.data;
    } catch (error) {
        throw error.response.data;
    }
}