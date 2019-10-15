<template>
  <div>
    <appNavbar @updateLanguage="lang => (language = lang)"></appNavbar>
    <b-card no-body>
      <div class="searchDeclarationsHeader">
        <b-card-header
          header-tag="header"
          header-text-variant="white"
          class="pd-rt"
        >
          <h1 class="searchDeclarationsHeading">Search Declarations</h1>
        </b-card-header>
      </div>
      <b-card-body class="componentCard">
        <appDeclarationDashBoard></appDeclarationDashBoard>
      </b-card-body>
    </b-card>
  </div>
</template>

<script>
import DeclarationDashBoard from "./DeclarationDashBoard.vue";
import Navbar from "./../commonComponent/Navigationbar";

export default {
  components: {
    appDeclarationDashBoard: DeclarationDashBoard,
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
@import url("./Style/searchDeclarationsStyle.css");
</style>
