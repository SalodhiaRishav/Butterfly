<template>
  <div>
    <b-navbar class="nav-bg-color nav-overide" toggleable="lg" type="dark">
      <b-navbar-brand  href="#">CTDS</b-navbar-brand>
      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
      <b-collapse id="nav-collapse" is-nav>
      <b-navbar-nav>
        <router-link to="/home" active-class="active" tag="b-nav-item">{{
          language.lang.home
        }}</router-link>
        <b-nav-item-dropdown
          :text="language.lang.caseManagement"
        >
          <router-link to="/case" active-class="active" tag="b-dropdown-item">{{
            language.lang.createNewCase
          }}</router-link>
        </b-nav-item-dropdown>
        <b-nav-item-dropdown
          :text="language.lang.declaration"
        >
          <router-link
            to="/declarationform"
            active-class="active"
            tag="b-dropdown-item"
            >{{ language.lang.createNewDeclaration }}</router-link
          >
        </b-nav-item-dropdown>
      </b-navbar-nav>
     
       <b-navbar-nav class="ml-auto">
        <b-nav-form>
           <b-form-select
            style="background-color: #6a54a6; color: #a89bcb;"
            @change="changeLanguage()"
            v-model="selected"
            :options="languages"
          ></b-form-select>
        </b-nav-form>

          <b-nav-item @click="logout" right>
          {{ language.lang.logout }}
          </b-nav-item>
      </b-navbar-nav>
      </b-collapse>
    </b-navbar>
  </div>
</template>

<script>
import HttpClient from "./../utils/httpRequestWrapper";
import allLanguages from "./../utils/languageSwitch";
import caseManagementLabels from "./../caseManagement/utils/caseManagementLabels";

export default {
  computed: {
    language: function() {
      return { lang: allLanguages.lang[this.selected].form };
    }
  },
  mounted() {
    if (localStorage.getItem("selectedLanguage")) {
      this.selected = localStorage.getItem("selectedLanguage");
    } else {
      localStorage.setItem("selectedLanguage", this.selected);
    }
    this.$emit("updateLanguage", this.language);
    this.$store.dispatch(
      "setCaseManagementLabels",
      caseManagementLabels.lang[this.selected]
    );
  },
  data() {
    return {
      selected: "en",
      languages: [
        { value: "en", text: "english" },
        { value: "se", text: "swedish" }
      ]
    };
  },
  methods: {
    changeLanguage() {
      localStorage.setItem("selectedLanguage", this.selected);
      var t = allLanguages.lang[this.selected];
      this.language.lang = t.form;
      this.$emit("updateLanguage", this.language);
      this.$store.dispatch(
        "setCaseManagementLabels",
        caseManagementLabels.lang[this.selected]
      );
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
