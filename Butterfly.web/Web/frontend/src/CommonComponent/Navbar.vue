<template>
  <div>
    <b-navbar class="mynavbar" type="dark">
      <b-navbar-nav>
        <router-link to="/home" active-class="active" tag="b-nav-item"
          >Home</router-link
        >
        <b-nav-item-dropdown text="Case management" right>
          <router-link to="/newcase" active-class="active" tag="b-dropdown-item"
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
         <button v-on:click="logout">Logout</button>
      </b-navbar-nav>
      
    </b-navbar>
  </div>
</template>

<script>
import HttpClient from "./../Utils/HttpRequestWrapper";

export default {
  methods: {
    logout(){
      var endpoint = "logout" 
        const token = localStorage.getItem("accessToken");
        HttpClient.get(endpoint)
          .then((response)=>{
          if(response){
            localStorage.removeItem("accessToken");
            localStorage.removeItem("refreshTokenId");
            this.$router.push("/login");
            alert("logged out!");
          }
        })
        .catch((error)=>{
          console.log(error);
        });       
      },
  },
};
</script>

<style>
@import url(./styles/NavbarStyle.css);
</style>
