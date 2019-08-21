import axios from 'axios';

const baseUrl="https://localhost:44313/";
const http=axios.create({baseUrl});

export default {
    http:http,
    get(resource){
        return http.get(resource);
    },
    post(resource,payload){
         return http.post(resource,payload);
    },
    put(resource,payload)
    {
        return http.put(resource,payload);
    },
    delete(resource,payload)
    {
        return http.delete(resource,payload);
    }

}