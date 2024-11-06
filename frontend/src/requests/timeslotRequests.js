import axios from "axios";

const API_URL = "http://localhost:5000"; // ASP.NET Core backend URL

export const getTimeslotsFromService = async (serviceId) => {
    try {
        const response = await axios.get(`${API_URL}/api/Timeslots/service/${serviceId}`);
        return response.data;
    } catch (error) {
        throw error.response.data;
    }
}

export const postTimeslot = async (timeslot) => {
    try {
        const response = await axios.post(`${API_URL}/api/Timeslots/`, timeslot);
        return response.data;
    } catch (error) {
        throw error.response.data;
    }
}






