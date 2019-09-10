<template>
  <div>
    <b-row>
      <b-col>
        <div class="heading">Manage Case</div>
      </b-col>
      <b-col class="leftBorder">
        <div class="field">
          <div class="fieldName">{{ labels.caseId }}</div>
          <div class="fieldAnswer">KGH-19-{{ caseId }}</div>
        </div>
      </b-col>
      <b-col class="leftBorder">
        <div class="field">
          <div class="fieldName">{{ labels.createdDate }}</div>
          <div>{{ createdDate }}</div>
        </div>
      </b-col>
      <b-col class="leftBorder">
        <div class="field">
          <div class="fieldName">{{ labels.priority }}</div>
          <div>{{ priority }}</div>
        </div>
        <div class="field">
          <div class="fieldName">{{ labels.status }}</div>
          <div>{{ status }}</div>
        </div>
      </b-col>
      <b-col>
        <div style="float : right; cursor:pointer;">
          <font-awesome-icon icon="save" @click="editCase" />
        </div>
        <br />
        <br />
        <b-modal id="error-modal">
          <li v-for="(error, index) in errorList" :key="index">
            {{ error }}
          </li>
        </b-modal>
        <div style="float : right; cursor:pointer;">
          <font-awesome-icon
            icon="bug"
            v-b-modal.error-modal
            v-show="isError"
          />
        </div>
        <br />
        <br />
        <br />
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
import httpClient from "./../utils/httpRequestWrapper";

export default {
  data() {
    return {
      dismissCountDown: 0,
      showDismissibleAlert: false,
      alertVariant: "",
      alertMessage: "",
      isError: false,
      errorList: []
    };
  },
  methods: {
    countDownChanged(dismissCountDown) {
      this.dismissCountDown = dismissCountDown;
    },
    convertDate(someDate) {
      return new Date(someDate.match(/\d+/)[0] * 1).toString().substring(0, 16);
    },
    editCase() {
      const caseDto = {
        id: this.$store.getters.case.id,
        client: this.$store.getters.clientDetails,
        caseStatus: this.$store.getters.caseStatus,
        references: this.$store.getters.references,
        caseInformation: this.$store.getters.caseInformation,
        notes: this.$store.getters.notes,
        createdOn: this.$store.getters.case.createdOn,
        modifiedOn: this.$store.getters.case.modifiedOn
      };
      const resource = "/casemanagement";
      httpClient
        .put(resource, { caseDto: caseDto })
        .then(res => {
          if (res.data === "token refreshed") {
            this.editCase();
            return;
          }
          if (res.data.success === true) {
            this.dismissCountDown = 5;
            this.alertMessage = res.data.message;
            this.alertVariant = "success";
            this.showDismissibleAlert = true;
            this.isError = false;
          } else {
            this.isError = true;
            this.errorList = res.data.error;
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
      return this.$store.getters.case.caseId;
    },
    status: function() {
      return this.$store.getters.caseStatus.status;
    },
    priority: function() {
      return this.$store.getters.caseInformation.priority;
    },
    createdDate: function() {
      return this.convertDate(this.$store.getters.case.createdOn);
    },
    labels: function() {
      return this.$store.getters.caseManagementLabels;
    }
  }
};
</script>

<style scoped>
@import url(./styles/caseHeaderStyle.css);
</style>
