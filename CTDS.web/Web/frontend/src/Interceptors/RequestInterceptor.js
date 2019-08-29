import HttpClient from "./../Utils/HttpRequestWrapper";

export default function updateHeader() {
  HttpClient.http.interceptors.request.use(
    (oldConfig) => {
      let newConfig = applyToken(oldConfig);
      return newConfig;
    },
    (error) => {
      return Promise.reject(error);
    }
  );
}

const applyToken = config => {
  const token = sessionStorage.getItem("accessToken");
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
