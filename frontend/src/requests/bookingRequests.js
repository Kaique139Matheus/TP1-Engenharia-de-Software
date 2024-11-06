import axios from "axios";

const API_URL = "http://localhost:5000"; // ASP.NET Core backend URL

export const getBookingsUntilMaxDate = async (serviceId) => {
    try {
        const response = await axios.get(`${API_URL}/bookings/service/${serviceId}/bookingsUntilMaxDate`);
        return response.data;
    } catch (error) {
        throw error.response.data;
    }
}

export const verifyBookingAvailability = async (serviceId, date) => {
    try {
        const response = await axios.get(`${API_URL}/bookings/availability/${serviceId}/${date}`);
        return response.data;
    } catch (error) {
        throw error.response.data;
    }
}

export const getBookingsWithTimeFromServiceAndDate = async (serviceId, date) => {
    try {
        const response = await axios.get(`${API_URL}/bookings/service/${serviceId}/${date}`);
        return response.data;
    } catch (error) {
        throw error.response.data;
    }
}

export const setBooking = async (providerId, serviceId, timeslotId, date, clientId) => {
    try {
        console.log("Sending booking request with data:", {
            providerId,
            serviceId,
            timeslotId,
            date,
            clientId
        });
        const response = await axios.post(`${API_URL}/bookings`, {
            providerId,
            serviceId,
            timeslotId,
            date,
            clientId
        });
        console.log("Booking response:", response.data);
        return response.data;
    } catch (error) {
        console.error("Error setting booking:", error);
        throw error.response.data;
    }
}

export const updateBooking = async (providerId, serviceId, timeslotId, date, clientId) => {
    try {
        const response = await axios.put(`${API_URL}/bookings/update/${providerId}/${serviceId}/${timeslotId}/${date}/${clientId}`);
        console.log("Booking response:", response.data);
        return response.data;
    } catch (error) {
        console.error("Error setting booking:", error);
        throw error.response.data;
    }
}