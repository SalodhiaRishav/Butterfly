<template>
<div>
  
  <b-card-group columns>
    <appClient></appClient>
    <appCaseInformation></appCaseInformation>
    <appReferences></appReferences>
    <appNotes></appNotes>
    <appCaseStatus></appCaseStatus>
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
   
  components: {
    appClient: Client,
    appCaseInformation: CaseInformation,
    appNotes: Notes,
    appCaseStatus: CaseStatus,
    appReferences: References
  }
};
</script>
