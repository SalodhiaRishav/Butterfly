import axios from 'axios';

const baseUrl="https://localhost:44313/";
const myAxios=axios.create({baseUrl});

export default {
    myAxios:myAxios,
    get(resource){
        return myAxios.get(resource);
    },
    post(resource,payload){
         return myAxios.post(resource,payload);
    },
    put(resource,payload)
    {
        return myAxios.put(resource,payload);
    },
    delete(resource,payload)
    {
        return myAxios.delete(resource,payload);
    }

}