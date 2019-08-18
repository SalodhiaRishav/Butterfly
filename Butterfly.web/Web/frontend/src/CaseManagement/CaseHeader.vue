<template>
  <div>
    <b-row>
      <b-col>
        <div class="heading">Manage Case</div>
      </b-col>
      <b-col class="leftBorder">
        <div class="field">
          <div class="fieldName">Case ID</div>
          <div class="fieldAnswer">{{ caseIdentifier }}</div>
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
      caseIdentifier: "",
      dismissCountDown: 0,
      showDismissibleAlert: false,
      alertVariant: "",
      alertMessage: "",
      createdDate: ""
    };
  },
  methods: {
    convertDate(someDate) {
      return new Date(someDate.match(/\d+/)[0] * 1).toString().substring(0, 16);
    },
    countDownChanged(dismissCountDown) {
      this.dismissCountDown = dismissCountDown;
    },
    submitAll() {
      const caseDto = {
        client: this.$store.getters.clientDetails,
        caseStatus: this.$store.getters.statusForm,
        references: this.$store.getters.references,
        caseInformation: this.$store.getters.caseInformation,
        notes: this.$store.getters.notesForm
      };
      axios
        .post("https://localhost:44313/casemanagement", { caseDto: caseDto })
        .then(res => {
          if (res.data.success === true) {
            this.caseIdentifier = "KGH-19-" + res.data.data.caseId;
            this.createdDate = this.convertDate(res.data.data.createdOn);
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
    status: function() {
      return this.$store.getters.statusForm.status;
    },
    priority: function() {
      return this.$store.getters.caseInformation.priority;
    }
  }
};
</script>

<style scoped>
@import url(./styles/CaseHeaderStyle.css);
</style>
