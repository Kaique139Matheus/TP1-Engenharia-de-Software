import axios from 'axios';

const API_BASE_URL = 'http://localhost:5000'

const providerService = {
    getProviders: async () => {
        try{
            const response = await axios.get(`${API_BASE_URL}/Providers`);
            return(response.data);
        }catch(e){
            throw(e);
        }
    }
}

export default providerService;
