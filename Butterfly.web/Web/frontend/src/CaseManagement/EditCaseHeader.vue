<template>
  <div>
    <b-row>
      <b-col>
        <div class="heading">Manage Case</div>
      </b-col>
      <b-col class="leftBorder">
        <div class="field">
          <div class="fieldName">Case ID</div>
          <div class="fieldAnswer">{{ caseId }}</div>
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
        <button @click="EditCase">Edit</button>
      </b-col>
    </b-row>
    <b-row>
      <b-col> </b-col>
      <b-col> </b-col>
      <b-col>
        <b-alert
          :variant="alertVariant"
          :show="dismissCountDown"
          @dismissed="dismissCountDown = 0"
          @dismiss-count-down="countDownChanged"
          dismissible
        >
          {{ alertMessage }}
        </b-alert>
      </b-col>
    </b-row>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      dismissCountDown: 0,
      showDismissibleAlert: false,
      alertVariant: "",
      alertMessage: ""
    };
  },
  methods: {
    convertDate(someDate) {
      return new Date(someDate.match(/\d+/)[0] * 1).toString().substring(0, 16);
    },
    EditCase() {
      const caseDto = {
        id: this.$store.getters.caseToEdit.id,
        client: this.$store.getters.clientDetails,
        caseStatus: this.$store.getters.statusForm,
        references: this.$store.getters.references,
        caseInformation: this.$store.getters.caseInformation,
        notes: this.$store.getters.notesForm,
        createdOn: this.$store.getters.caseToEdit.createdOn,
        modifiedOn: this.$store.getters.caseToEdit.modifiedOn
      };
      const url = "https://localhost:44313/casemanagement";
      axios
        .put(url, { caseDto: caseDto })
        .then(res => {
          if (res.data.success === true) {
            this.dismissCountDown = 5;
            this.alertMessage = res.data.message;
            this.alertVariant = "success";
            this.showDismissibleAlert = true;
          } else {
            this.dismissCountDown = 5;
            this.alertMessage = res.data.message;
            this.alertVariant = "danger";
            this.showDismissibleAlert = true;
          }
        })
        .catch(error => {
          this.dismissCountDown = 5;
          this.alertMessage = error;
          this.alertVariant = "danger";
          this.showDismissibleAlert = true;
        });
    }
  },
  computed: {
    caseId: function() {
      return this.$store.getters.caseInformation.caseId;
    },
    status: function() {
      return this.$store.getters.statusForm.status;
    },
    priority: function() {
      return this.$store.getters.caseInformation.priority;
    },
    createdDate: function() {
      return this.convertDate(this.$store.getters.caseToEdit.createdOn);
    }
  }
};
</script>

<style scoped>
@import url(./styles/CaseHeaderStyle.css);
</style>
