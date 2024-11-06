import axios from "axios";

const API_URL = "http://localhost:5000"; // ASP.NET Core backend URL

export const getReviewsFromProvider = async (providerId) => {
  try {
    const response = await axios.get(
      `${API_URL}/reviews/provider/${providerId}`
    );
    return response.data;
  } catch (error) {
    throw error.response.data;
  }
};

export const postService = async (clientID, providerID, score, comment) => {
  try {
    const response = await axios.post(`${API_URL}/Services`, {
      clientID: clientID,
      providerID: providerID,
      score: score,
      comment: comment,
    });
    return response.data;
  } catch (error) {
    throw error.response.data;
  }
};
