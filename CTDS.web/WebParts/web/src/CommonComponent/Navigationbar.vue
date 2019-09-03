<template>
  <div>
    <b-navbar class="nav-bg-color nav-overide" type="dark">
      <b-navbar-nav>
        <router-link to="/home" active-class="active" tag="b-nav-item"
          >Home</router-link
        >
        <b-nav-item-dropdown text="Case management" right>
          <router-link to="/case" active-class="active" tag="b-dropdown-item"
            >Create new case</router-link
          >
        </b-nav-item-dropdown>
        <b-nav-item-dropdown text="Declarations" right>
          <router-link
            to="/declarationform"
            active-class="active"
            tag="b-dropdown-item"
            >Create new declaration</router-link
          >
        </b-nav-item-dropdown>
      </b-navbar-nav>
      <button class="btn-style" style="float:right;" right v-on:click="logout">
        Logout
      </button>
    </b-navbar>
  </div>
</template>

<script>
import HttpClient from "./../utils/httpRequestWrapper";
import englishCaseManagementLabels from "./../caseManagement/utils/caseManagementLabel.en";
import swedishCaseManagementLabels from "./../caseManagement/utils/caseManagementLabel.sw"

export default {
  mounted(){
    this.language="swedish"
    if(this.language === "english")
    {
      this.$store.dispatch("setCaseManagementLabels",englishCaseManagementLabels);
    }
    else if(this.language === "swedish")
    {
      this.$store.dispatch("setCaseManagementLabels",swedishCaseManagementLabels);
    }
  },
   data() {
    return {
      language: "",
    };
  },
  methods: {
    logout() {
      var endpoint = "/logout";
      const token = sessionStorage.getItem("accessToken");
      HttpClient.get(endpoint)
        .then(response => {
          if (response) {
            sessionStorage.removeItem("accessToken");
            sessionStorage.removeItem("refreshTokenId");
            this.$router.push("/login");
            alert("logged out!");
          }
        })
        .catch(error => {
          console.log(error);
        });
    }
  }
};
</script>

<style>
@import url(./styles/NavbarStyle.css);
</style>
