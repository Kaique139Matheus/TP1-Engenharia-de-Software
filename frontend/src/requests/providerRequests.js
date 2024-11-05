import axios from 'axios';

const API_URL = 'http://localhost:5000'

export const GetAllProviders = async () => {
    try {
        const response = await axios.get(`${API_URL}/Providers`);
        return response.data;
    } catch (error) {
        throw error.response.data;
    }
}


// const providerService = {
//     getProviders: async () => {
//         try{
//             const response = await axios.get(`${API_BASE_URL}/Providers`);
//             return(response.data);
//         }catch(e){
//             throw(e);
//         }
//     }
// }

// export default providerService;
