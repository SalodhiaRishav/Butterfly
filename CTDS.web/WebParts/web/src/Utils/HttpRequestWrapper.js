import axios from "axios";

export default {
  http: axios,
  get(url,param) {
    if(arguments.length === 1)
      return axios.get(url);
    else{
        return axios.get(url, {
          params: {
            data : param
        }})
    }
  }, 
  post(url, payload) {
    return axios.post(url, payload);
  },
  put(url, payload) {
    return axios.put(url, payload);
  },
  delete(url, payload) {
    return axios.delete(url, payload);
  }
};
