import axios from 'axios';
import store from './../store/store'

export default function setTokenToRequest() {
    axios.interceptors.request.use(function(config) {
        const token = store.getters.accessToken;
        if(token) {
            config.headers.Authorization = token;
        }
        return config;
    }, function(err) {
        return Promise.reject(err);
    });
}