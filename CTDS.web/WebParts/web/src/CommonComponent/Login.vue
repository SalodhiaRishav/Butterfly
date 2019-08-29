<template>
  <div>
    <h2>Login</h2>
    <form @submit.prevent="loginUser">
      <div class="form-group">
        <label for="email">Email</label>
        <input
          type="email"
          v-model="email"
          name="email"
          class="form-control"
        />
      </div>
      <div class="form-group">
        <label htmlFor="password">Password</label>
        <input
          type="password"
          v-model="password"
          name="password"
          class="form-control"
        />
      </div>
      <div class="form-group">
        <button class="btn btn-primary">Login</button>
      </div>
    </form>
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
