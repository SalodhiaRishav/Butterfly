<template>
    <div>
    <b-card no-body>
          <div class="dashboardHeader">
        <b-card-header
          header-tag="header"
          header-text-variant="white"
          class="p-1"
        >
          <h1 class="dashboardHeading">Dashboard</h1>
        </b-card-header>
          </div>
      <b-tabs card>
        <b-tab title="OpenCases" active>
          <appOpenCases></appOpenCases>
        </b-tab>
        <b-tab title="Declarations" active>
          <appDeclarationDashBoard></appDeclarationDashBoard>
        </b-tab>
      </b-tabs>
    </b-card>
  </div>
</template>

<script>
import OpenCases from './../CaseManagement/OpenCases.vue';
import DeclarationDashBoard from './../Declaration/DeclarationDashBoard.vue'
import Navbar from './Navbar.vue';

export default {
components:{
    appDeclarationDashBoard:DeclarationDashBoard,
    appOpenCases:OpenCases,
    appNavbar:Navbar
}
}
</script>

<style>
@import url('./styles/DashboardStyle.css');
</style>
