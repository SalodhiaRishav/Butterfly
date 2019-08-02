<template>
  <b-row>
    <b-col>
      <div class="heading">Manage Case</div>
    </b-col>
    <b-col class="leftBorder">
      <div class="field">
        <div class="fieldName">Case ID</div>
        <div class="fieldAnswer">{{ clientIdentifier }}</div>
      </div>
    </b-col>
    <b-col class="leftBorder">
      <div class="field">
        <div class="fieldName">Created Date</div>
        <div>{{ createdDate }}</div>
      </div>
    </b-col>
    <b-col class="leftBorder">
      <div class="field">
        <div class="fieldName">Priority</div>
        <div>{{ priority }}</div>
      </div>
      <div class="field">
        <div class="fieldName">Status</div>
        <div>{{ status }}</div>
      </div>
    </b-col>
    <b-col>
      <button @click="submitAll">Submit</button>
    </b-col>
  </b-row>
</template>

<script>
import axios from 'axios'
export default {
  methods: {
    submitAll() {
     
       
  const caseDto={
       client:this.$store.getters.clientDetails,
           caseStatus:this.$store.getters.statusForm,
           references: this.$store.getters.references,
            caseInformation:this.$store.getters.caseInformation,
            notes: this.$store.getters.notesForm
  }
       
         axios.post('https://localhost:44313/casemanagement',{caseDto:caseDto})
         .then((res)=>{
            console.log(res);
         })
         .catch((error)=>{
           console.log('in error'+error);
         })
    }
  },
  computed: {
    clientIdentifier: function() {
      return this.$store.getters.clientDetails.clientIdentifier;
    },
    status: function() {
      return this.$store.getters.statusForm.status;
    },
    priority: function() {
      return this.$store.getters.caseInformation.priority;
    },
    createdDate: function() {
      return "29/07/2019";
    }
  }
};
</script>

<style scoped>
@import url(./styles/CaseHeaderStyle.css);
</style>
