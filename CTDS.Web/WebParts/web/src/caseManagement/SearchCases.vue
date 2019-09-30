<template>
  <div>
    <appNavbar @updateLanguage="lang => (language = lang)"></appNavbar>
    <b-card no-body>
      <div class="searchCasesHeader">
        <b-card-header
          header-tag="header"
          header-text-variant="white"
          class="pd-rt"
        >
          <h1 class="searchCasesHeading">Search Cases</h1>
        </b-card-header>
      </div>
        <b-card-body class="componentCard">
             <appOpenCases></appOpenCases>
        </b-card-body>
    </b-card>
  </div>
</template>

<script>
import OpenCases from "./OpenCases.vue";
import Navbar from "./../commonComponent/Navigationbar";

export default {
  components: {
    appOpenCases: OpenCases,
    appNavbar: Navbar
  },
  data() {
    return {
      language: {
        lang: {}
      }
    };
  }
};
</script>

<style>
@import url("./styles/searchCasesStyle.css");
</style>
