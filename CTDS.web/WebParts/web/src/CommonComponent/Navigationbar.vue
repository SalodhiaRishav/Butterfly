<template>
  <div>
    <b-navbar class="nav-bg-color nav-overide" type="dark">
      <b-navbar-nav>
        <router-link to="/home" active-class="active" tag="b-nav-item"
          >{{language.lang.home}}</router-link
        >
        <b-nav-item-dropdown :text="language.lang.caseManagement" right>
          <router-link to="/case" active-class="active" tag="b-dropdown-item"
            >{{language.lang.createNewCase}}</router-link
          >
        </b-nav-item-dropdown>
        <b-nav-item-dropdown :text="language.lang.declaration" right>
          <router-link
            to="/declarationform"
            active-class="active"
            tag="b-dropdown-item"
            >{{language.lang.createNewDeclaration}}</router-link
          >
        </b-nav-item-dropdown>
      </b-navbar-nav>
     
      <div class="row">
      <div class="col-sm-7">
       <b-form-select @change="changeLanguage()" v-model="selected" :options="languages"></b-form-select>
      </div>
      <div class="col-sm-5">
      <button class="btn-style" style="padding-top:7px" v-on:click="logout">
        {{language.lang.logout}}
      </button>
      </div>
      </div>
    </b-navbar>
  </div>
</template>

<script>
import HttpClient from "./../utils/httpRequestWrapper";
import allLanguages from './../utils/languageSwitch';
import caseManagementLabels from "./../caseManagement/utils/caseManagementLabels";

export default {
  // props:{
  //   language: Object,
  // },
  data(){
    return {
      selected:'en',
      languages:[{value:'en',text:'english'},{value:'se',text:'swedish'}],
      language:{
        lang:allLanguages.lang.en.form
      },
    }
  },
  created(){
    this.$emit('updateLanguage',this.language);
      this.$store.dispatch("setCaseManagementLabels",caseManagementLabels.lang.en)
  },
  methods: {   
     changeLanguage(){
       var t = allLanguages.lang[this.selected];
       this.language.lang = t.form;
      this.$emit('updateLanguage',this.language)
      this.$store.dispatch("setCaseManagementLabels",caseManagementLabels.lang[this.selected])
    },
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
