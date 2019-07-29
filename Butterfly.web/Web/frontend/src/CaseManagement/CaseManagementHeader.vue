<template>
  <div>
    <b-card no-body>
      <div class="mainCaseHeader">
        <b-card-header
          header-tag="header"
          header-text-variant="white"
          class="p-1"
        >
          <appCaseHeader></appCaseHeader>
        </b-card-header>
      </div>
      <b-tabs card class="myMainBodyCard">
        <b-tab title="Header" active>
          <appCaseManagement></appCaseManagement>
        </b-tab>
      </b-tabs>
    </b-card>
  </div>
</template>

<script>
import CaseManagement from "./CaseManagement.vue";
import CaseHeader from "./CaseHeader.vue";

export default {
  components: {
    appCaseHeader: CaseHeader,
    appCaseManagement: CaseManagement
  }
};
</script>

<style scoped>
@import url(./styles/CaseManagementHeaderStyle.css);
</style>
