<template>
  <div id="app">
    <appNavbar></appNavbar>
    <main>
      <router-view></router-view>
    </main>
  </div>
</template>

<script>
import Navbar from "./CommonComponent/Navbar.vue";
import Dashboard from "./CommonComponent/Dashboard.vue";

export default {
  name: "app",
  components: {
    appNavbar: Navbar,
    appDashboard: Dashboard
  }
};
</script>

<style>
@import url(./GlobalStyle.css);
</style>
