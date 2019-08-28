import axios from "axios";

export default {
  http: axios,
  get(resource) {
    return axios.get(resource);
  },
  post(resource, payload) {
    return axios.post(resource, payload);
  },
  put(resource, payload) {
    return axios.put(resource, payload);
  },
  delete(resource, payload) {
    return axios.delete(resource, payload);
  }
};
