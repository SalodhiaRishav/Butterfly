import axios from "axios";

export default {
  http: axios,
  get(url, index, sortOrder) {
    if (arguments.length === 1) return axios.get(url);
    else {
      return axios.get(url, {
        params: {
          index: index,
          orderBy: sortOrder
        }
      });
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
