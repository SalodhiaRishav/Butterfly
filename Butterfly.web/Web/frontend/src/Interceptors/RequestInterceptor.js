import HttpClient from "./../Utils/HttpRequestWrapper";

export default function someFunction() {
  HttpClient.http.interceptors.request.use(
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
  const token = localStorage.getItem("accessToken");
  if (token && checkValidEndpointForAddingHeader(config.url)) {
    config.headers.Authorization = token;
  }
  return config;
};

const checkValidEndpointForAddingHeader = url => {
  if (url === "loginRequest") {
    return false;
  }
  return true;
};
