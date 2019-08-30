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
        <div style="float : right; cursor: pointer;">
          <font-awesome-icon icon="save" @click="addNewCase()" />
        </div>
        <br />
        <br />
        <b-modal id="error-modal">
          <li v-for="(error, index) in errorList" :key="index">
            {{ error }}
          </li>
        </b-modal>
        <div style="float : right; cursor:pointer;">
          <font-awesome-icon icon="bug" v-b-modal.error-modal v-show="isError" />
        </div>
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
import httpClient from "./../utils/httpRequestWrapper";
import Navbar from "./../commonComponent/Navigationbar";

export default {
    components: {
      appNavbar: Navbar
  },
  data() {
    return {
      caseIdentifier: "",
      dismissCountDown: 0,
      showDismissibleAlert: false,
      alertVariant: "",
      alertMessage: "",
      createdDate: "",
      isError:false, 
      errorList: [],   
      };
  },
  created() {
    this.resetCaseData();
  },
  methods: {
    resetCaseData() {
      let caseInformation = {
        id: "",
        caseId: "",
        description: "",
        messageFromClient: "",
        priority: null,
        createdOn: "",
        modifiedOn: ""
      };
      let caseStatus = {
        status: null
      };
      let references = [];
      let notes = {
        notesByCpa: ""
      };
      let clientDetails = {
        clientIdentifier: "",
        identifierType: null,
        name: "",
        address: "",
        postalCode: "",
        city: "",
        country: null,
        email: ""
      };
      this.$store.dispatch("setClientDetails", clientDetails);
      this.$store.dispatch("setCaseInformation", caseInformation);
      this.$store.dispatch("setCaseStatus", caseStatus);
      this.$store.dispatch("set", notes);
      this.$store.dispatch("setReferences", references);
    },
    convertDate(someDate) {
      return new Date(someDate.match(/\d+/)[0] * 1).toString().substring(0, 16);
    },
    countDownChanged(dismissCountDown) {
      this.dismissCountDown = dismissCountDown;
    },
    addNewCase() {
      const caseDto = {
        client: this.$store.getters.clientDetails,
        caseStatus: this.$store.getters.caseStatus,
        references: this.$store.getters.references,
        caseInformation: this.$store.getters.caseInformation,
        notes: this.$store.getters.notes
      };
      const resource = "/casemanagement";
      httpClient
        .post(resource, { caseDto: caseDto })
        .then(res => {
          if (res.data === "token refreshed") {
            this.addNewCase();
            return;
          }
          if (res.data.success === true) {
            this.caseIdentifier = "KGH-19-" + res.data.data.caseId;
            this.createdDate = this.convertDate(res.data.data.createdOn);
            this.dismissCountDown = 5;
            this.alertMessage = "Case Saved!";
            this.alertVariant = "success";
            this.showDismissibleAlert = true;
            this.isError = false;
          } else {
            this.isError = true;
            this.errorList = res.data.error;
          }
        })
        .catch(error => {         
            console.log(error);
        });
    }
  },
  computed: {
    status: function() {
      return this.$store.getters.caseStatus.status;
    },
    priority: function() {
      return this.$store.getters.caseInformation.priority;
    }
  }
};
</script>

<style scoped>
@import url(./styles/caseHeaderStyle.css);
</style>
