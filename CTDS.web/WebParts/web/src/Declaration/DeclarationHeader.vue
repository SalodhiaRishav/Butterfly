<template>
  <b-card class="header-bg-color border-radius-0" text-variant="white">
    <b-card-text>
      <b-row>
        <b-col class="border-rt">
          <p>NO Import</p>
          <b-button v-b-modal.error-modal v-show="isError">Issues</b-button>
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
          Declaration ID: <br />
          <p>--</p>
          LRN <br />
          <p>--</p>
          MRN<br />
          <p>--</p>
        </b-col>
        <b-col class="border-rt">
          Total # of packages<br />
          <p>--</p>
          Total # of items <br />
          <p>--</p>
          Total Gross Mass<br />
          <p>--</p>
        </b-col>
        <b-col>
          <b-button
            style="float:right; margin-right:17px"
            pill
            @click="onSave()"
            >Save</b-button
          >
          Declaration status <br />
          <p>--</p>
          Customs response <br />
          <p>--</p>
          Taxation data<br />
          <p>--</p>
        </b-col>
      </b-row>
    </b-card-text>
  </b-card>
</template>

<script>
import httpClient from "./../utils/httpRequestWrapper";

export default {
  props: {
    declaration: Object,
    referenceData: Object
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
  methods: {
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
          console.log(response.data)
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
        .catch((error)=>{
          console.log(error);
        });
    }
  }
};
</script>

<style>
@import url("./style/declarationStyle.css");
</style>
