import axios from 'axios';
import store from './../store/store';

export default function exceptionResponse() {
axios.interceptors.response.use(function (response) {
       if (response.data === "token expired") {
            const refreshTokenSerial = store.getters.refreshTokenSerial;
               store
              .dispatch("getNewToken", refreshTokenSerial)
              .then(myresponse => {
                  if(myresponse)
                  {
                    store.dispatch("setAccessToken", "bearer " + myresponse);
                    return Promise.resolve({tokenRefreshed:true});
                  }
              })
              .catch(error => {
                return Promise.reject(error);
              });
          } 
          else
          {
            return response;
          }
}, function (error) {
    if (401 === error.response.status) {
       alert("Unauthorized access,Please login again.");
       window.location="/login";
    } else {
        return Promise.reject(error);
    }
})}