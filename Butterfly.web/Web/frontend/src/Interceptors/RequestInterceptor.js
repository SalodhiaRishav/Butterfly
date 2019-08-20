import HttpClient from "./../Utils/HttpRequestWrapper";
import store from "./../store/store";

export default function someFunction() {
  HttpClient.myAxios.interceptors.request.use(
    function(config) {
      let finalConfig = applyToken(config);
      return finalConfig;
    },
    function(error) {
      return Promise.reject(error);
    }
  );
}

const applyToken = config => {
  const token = store.getters.accessToken;
  if (token && checkValidEndpointForAddingHeader(config.url)) {
    config.headers.Authorization = token;
  }
  return config;
};

const checkValidEndpointForAddingHeader = url => {
  if (url === "checkuser") {
    return false;
  }
  return true;
};
