<template>
  <b-card class="header-bg-color border-radius" text-variant="white">
    <b-card-text>
      <b-row>
        <b-col class="border-rt">
          <p>NO Import</p>
          <b-modal id="error-modal">
            <li v-for="(error, index) in errorList" :key="index">
              {{ error }}
            </li>
          </b-modal>
         
        </b-col>
        <b-col class="border-rt">
          Declaration ID: <br />
          <p>CD - {{ declaration.declarationId.toString().substring(0, 5) }}</p>
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
          Declaration status <br />
          <p>--</p>
          Customs response <br />
          <p>--</p>
          Taxation data<br />
          <p>--</p>
        </b-col>
        <b-col>
          <div style="float : right; cursor:pointer;">
            <font-awesome-icon icon="save" @click="onSave" />
          </div>
          <br />
          <br />
          <div style="float : right; cursor:pointer;">
            <font-awesome-icon icon="bug" v-b-modal.error-modal v-show="isError" />
          </div>
          <br />
          <br />
          <b-alert :variant="alertVariant"
                   :show="dismissCountDown"
                   @dismissed="dismissCountDown = 0"
                   @dismiss-count-down="countDownChanged"
                   dismissible>
            {{ alertMessage }}
          </b-alert>
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
      postBody: null,
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
      const url = "/updatedeclaration";
      httpClient
        .post(url, {
          declaration: this.declaration,
          referenceData: this.referenceData.reference
        })
        .then(response => {
          if (response.data === "token refreshed") {
            this.onSave();
          }
          if (response.data.success == true) {
            this.isError = false;
            this.alertVariant = "success";
            this.alertMessage = "declaration saved!";
            this.dismissCountDown = 2;
          } else {
            console.log("error :", response.data.error);
            this.errorList = response.data.error;
            this.isError = true;
          }
          console.log(response.data.data);
        });
    }
  }
};
</script>

<style>
@import url("./style/declarationStyle.css");
</style>
