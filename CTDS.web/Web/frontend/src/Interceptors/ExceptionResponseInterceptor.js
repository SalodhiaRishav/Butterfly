import httpClient from "./../Utils/HttpRequestWrapper";
import router from "./../router/index";

export default function exceptionResponse() {
  httpClient.http.interceptors.response.use(
    (response) => {
      if (isTokenExpired(response)) {
        return new Promise((resolve, reject) => {
          refreshToken()
            .then(response => {
              if (response.isTokenRefreshed) {
                resolve({ data: "token refreshed" });
              }
            })
            .catch(err => {
              reject(err);
            });
        });
      } else {
        return response;
      }
    },
    (error) => {
      errorHandler(error);
    }
  );
}

const errorHandler = error => {
  if (401 === error.response.status) {
    alert("Unauthorized access,redirecting to login");
    router.push("/login");
    return;
  } else if (500 === error.response.status) {
    alert("internal server error,redirecting to login");
    router.push("/login");
    return;
  }
};

const refreshToken = () => {
  return new Promise((resolve, reject) => {
    const refreshTokenSerial = sessionStorage.getItem("refreshTokenId");
        const resource="/refreshtoken";
        let postData = {
          refreshTokenSerialId: refreshTokenSerial
        };
        httpClient
          .post(resource, postData)
          .then(response => {
            if (response.data.success === true) {
              sessionStorage.setItem("accessToken",response.data.data.accessToken)
              resolve({isTokenRefreshed: true});
            } else {
              reject(response.data.message);
            }
          })
          .catch(error => {
            reject(error);
          });
      });
    }

const isTokenExpired = response => {
  if (response.data === "token expired") {
    return true;
  }
  return false;
};
