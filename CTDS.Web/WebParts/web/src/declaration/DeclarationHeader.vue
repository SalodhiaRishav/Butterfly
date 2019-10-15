<template>
  <b-card class="header-bg-color border-radius-0" text-variant="white">
    <b-card-text>
      <b-row>
        <b-col class="border-rt">
          <p>NO {{ language.lang.import }}</p>
          <b-modal id="error-modal">
            <li v-for="(error, index) in errorList" :key="index">
              {{ error }}
            </li>
          </b-modal>
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
        <b-col class="border-rt">
          {{ language.lang.declaration }} ID: <br />
          <p>--</p>
          LRN <br />
          <p>--</p>
          MRN<br />
          <p>--</p>
        </b-col>
        <b-col class="border-rt">
          {{ language.lang.totalNumberOfPackages }}<br />
          <p>--</p>
          {{ language.lang.totalNumberOfItems }} <br />
          <p>--</p>
          {{ language.lang.totalGrossMass }}<br />
          <p>--</p>
        </b-col>
        <b-col>
          {{ language.lang.declarationStatus }} <br />
          <p>--</p>
          {{ language.lang.customResponse }} <br />
          <p>--</p>
          {{ language.lang.taxationDate }}<br />
          <p>--</p>
        </b-col>
        <b-col>
          <div class="iconButton floatRight" v-hotkey="keymap">
            <font-awesome-icon icon="save" @click="onSave" />
          </div>
          <br />
          <div class="iconButton floatRight">
            <font-awesome-icon
              icon="window-close"
              @click="cancelAddDeclaration"
            />
          </div>
          <br />
          <br />
          <div class="iconButton floatRight">
            <font-awesome-icon
              icon="bug"
              v-b-modal.error-modal
              v-show="isError"
            />
          </div>
          <br />
        </b-col>
      </b-row>
    </b-card-text>
  </b-card>
</template>

<script>
import httpClient from "./../utils/httpRequestWrapper";
import allLanguages from "./../utils/languageSwitch";

export default {
  props: {
    declaration: Object,
    referenceData: Object,
    language: Object
  },
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
  computed: {
    keymap: function() {
      return {
        "ctrl+V": this.onSave
      };
    }
  },
  methods: {
    cancelAddDeclaration() {
      this.$router.push("/searchdeclarations");
    },
    onSave() {
      const url = "/newdeclaration";
      httpClient
        .post(url, {
          declaration: this.declaration,
          referenceData: this.referenceData.reference
        })
        .then(response => {
          if (response === "token refreshed") {
            this.onSave();
          }
          console.log(response.data);
          if (response.data.success === true) {
            this.isError = false;
            console.log("Success");
            this.alertVariant = "success";
            this.alertMessage = "declaration saved!";
            this.dismissCountDown = 2;
          } else {
            console.log("error :", response.data.error);
            this.errorList = response.data.error;
            this.isError = true;
          }
        })
        .catch(error => {
          console.log(error);
        });
    }
  }
};
</script>

<style>
@import url("./style/declarationStyle.css");
</style>
