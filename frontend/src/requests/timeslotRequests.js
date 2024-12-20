import axios from "axios";

const API_URL = "http://localhost:5000"; // ASP.NET Core backend URL

export const getTimeslotsFromService = async (serviceId) => {
    try {
        const response = await axios.get(`${API_URL}/timeslots/service/${serviceId}`);
        return response.data;
    } catch (error) {
        throw error.response.data;
    }
}

export const getTimeslotsFromServiceAndDate = async (serviceId, date) => {
    try {
        const response = await axios.get(`${API_URL}/timeslots/service/${serviceId}/${date}`);
        return response.data;
    } catch (error) {
        throw error.response.data;
    }
}

export const postTimeslot = async (timeslot) => {
    try {
        const response = await axios.post(`${API_URL}/Timeslots/`, timeslot);
        return response.data;
    } catch (error) {
        throw error.response.data;
    }
}

// export const postTimeslot = async (timeslot) => {
//     try {
//         const response = await axios.post(${API_URL}/Timeslots/, timeslot);
//         return response.data;
//     } catch (error) {
//         throw error.response.data;
//     }
// }