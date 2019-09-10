<template>
  <div>
    <b-card-group columns>
      <appClient :labels="labels"></appClient>
      <appCaseInformation :labels="labels"></appCaseInformation>
      <appReferences :labels="labels"></appReferences>
      <appNotes :labels="labels"></appNotes>
      <appCaseStatus :labels="labels"></appCaseStatus>
    </b-card-group>
  </div>
</template>

<script>
import Client from "./Client.vue";
import References from "./References.vue";
import CaseStatus from "./CaseStatus.vue";
import CaseInformation from "./CaseInformation.vue";
import Notes from "./Notes.vue";
export default {
  computed: {
    labels: function() {
      return this.$store.getters.caseManagementLabels;
    }
  },
  components: {
    appClient: Client,
    appCaseInformation: CaseInformation,
    appNotes: Notes,
    appCaseStatus: CaseStatus,
    appReferences: References
  }
};
</script>
