<template>
  <div class="wrapper">
     <div id="formContent">
    <h2 id="LoginHeading">Login</h2>
    <div>
      <img src="http://www.todaywalkins.com/Comp_images/NagarroSoftware.png" id="icon" alt="User Icon" />
    </div>
    <form @submit.prevent="loginUser">
      <div>
       <font-awesome-icon icon="envelope" />
        <input
          type="email"
          v-model="email"
          name="email"
          placeholder="Email"
          class="form-control"
        />
        </div>
        <div v-show="submitted && !email" class="invalid-feedback">
          email is required
        </div>
        <div>
         <font-awesome-icon icon="key" /> 
        <input
          type="password"
          v-model="password"
          name="password"
          placeholder="Password"
          class="form-control"
        />
        </div>
        <div v-show="submitted && !password" class="invalid-feedback">
          Password is required
        </div>
        <br>
        <button id="login">Login</button>
    </form>
  </div>
  </div>
</template>

<script>
import httpClient from "./../utils/httpRequestWrapper";
export default {
  data() {
    return {
      email: "",
      password: "",
      submitted: false,
      returnUrl: "",
      error: ""
    };
  },
  methods: {
    loginUser() {
      const resource = "/checkuser";
      const loginData = {
        email: this.email,
        password: this.password
      };
      httpClient
        .post(resource, loginData)
        .then(response => {
          if (response.data.success === true) {
            sessionStorage.setItem(
              "accessToken",
              response.data.data.accessToken
            );
            sessionStorage.setItem(
              "refreshTokenId",
              response.data.data.refreshTokenSerial
            );
            this.$router.push("/home");
          } else {
            alert(response.data.message);
          }
        })
        .catch(error => {
          alert(error);
        });
    }
  }
};
</script>

<style scoped>
@import url("./styles/loginStyle.css");
</style>
