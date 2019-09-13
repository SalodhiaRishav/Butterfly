<template>
  <div>
    <appNavbar @updateLanguage="lang => (language = lang)"></appNavbar>
    <b-card no-body>
      <div class="dashboardHeader">
        <b-card-header
          header-tag="header"
          header-text-variant="white"
          class="pd-rt"
        >
          <h1 class="dashboardHeading">{{ language.lang.dashboard }}</h1>
        </b-card-header>
      </div>
      <b-tabs card>
        <b-tab :title="language.lang.openCases" active>
          <appOpenCases></appOpenCases>
        </b-tab>
        <b-tab :title="language.lang.declaration" active>
          <appDeclarationDashBoard></appDeclarationDashBoard>
        </b-tab>
      </b-tabs>
    </b-card>
  </div>
</template>

<script>
import OpenCases from "./../caseManagement/OpenCases.vue";
import DeclarationDashBoard from "./../Declaration/DeclarationDashBoard.vue";
import Navbar from "./Navigationbar.vue";

export default {
  components: {
    appDeclarationDashBoard: DeclarationDashBoard,
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
@import url("./styles/dashboardStyle.css");
</style>
