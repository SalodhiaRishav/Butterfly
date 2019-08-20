import axios from "axios";

const state = {
  refreshTokenSerial: null,
  accessToken: null
};

const getters = {
  refreshTokenSerial: state => {
    return state.refreshTokenSerial;
  },
  accessToken: state => {
    return state.accessToken;
  }
};

const mutations = {
  setRefreshTokenSerial: (state, refreshTokenSerial) => {
    state.refreshTokenSerial = refreshTokenSerial;
  },
  setAccessToken: (state, accessToken) => {
    state.accessToken = accessToken;
  }
};

const actions = {
  setRefreshTokenSerial: (context, refreshTokenSerial) => {
    context.commit("setRefreshTokenSerial", refreshTokenSerial);
  },
  setAccessToken: (context, accessToken) => {
    context.commit("setAccessToken", accessToken);
  },
  getNewToken: (context, refreshTokenSerial) => {
    return new Promise((resolve, reject) => {
      const refreshTokenUrl = "https://localhost:44313/refreshtoken";
      let postData = {
        refreshTokenSerialId: refreshTokenSerial
      };
      axios
        .post(refreshTokenUrl, postData)
        .then(myresponse => {
          if (myresponse.data.success === true) {
            resolve(myresponse.data.data.accessToken);
          } else {
            reject(myresponse.data.message);
          }
        })
        .catch(error => {
          reject(error);
        });
    });
  }
};

export default {
  state,
  mutations,
  getters,
  actions
};
