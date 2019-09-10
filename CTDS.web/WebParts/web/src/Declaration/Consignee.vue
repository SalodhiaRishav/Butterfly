<template>
  <b-form class="pd-10 form-bg-color">
    <p class="block-heading">{{ language.lang.consignee }}</p>

    <b-form-group>
      <label>{{ language.lang.orgNumber }} </label>
      <b-form-input
        v-model="declaration.consigneeOrganisationNumber"
        required
      ></b-form-input>
    </b-form-group>

    <b-form-group>
      <label>{{ language.lang.name }} </label>
      <b-form-input v-model="declaration.consigneeName" required></b-form-input>
    </b-form-group>

    <b-form-group>
      <label>{{ language.lang.address1 }}</label>
      <b-form-input
        v-model="declaration.consigneeAddress1"
        required
      ></b-form-input>
    </b-form-group>

    <b-form-group>
      <label>{{ language.lang.address2 }}</label>
      <b-form-input
        v-model="declaration.consigneeAddress2"
        required
      ></b-form-input>
    </b-form-group>
    <b-row>
      <b-col>
        {{ language.lang.postalCode }}
        <b-form-input v-model="declaration.consigneePostalCode"></b-form-input>
      </b-col>
      <b-col>
        {{ language.lang.city }}
        <b-form-input v-model="declaration.consigneeCity"></b-form-input>
      </b-col>
      <b-col>
        {{ language.lang.country }}
        <b-form-select
          v-model="declaration.consigneeCountry"
          :options="countryList"
          required
        ></b-form-select>
      </b-col>
    </b-row>
    <b-form-group>
      <label>{{ language.lang.customCreditNumber }}(48)</label>
      <b-form-input
        v-model="declaration.customCreditNumber"
        required
      ></b-form-input>
    </b-form-group>

    <b-form-group>
      <label>{{ language.lang.defferredPayment }}(48)</label>
      <b-form-select
        v-model="declaration.defferedPayment"
        :options="defferedPayment"
        required
      ></b-form-select>
    </b-form-group>
  </b-form>
</template>

<script>
import httpClient from "./../utils/httpRequestWrapper";
import allLanguages from "./../utils/languageSwitch";

export default {
  props: {
    declaration: Object,
    language: Object
  },
  data() {
    return {
      defferedPayment: [],
      countryList: []
    };
  },
  mounted() {
    this.getDefferedPayment();
    this.getCountries();
  },
  methods: {
    getDefferedPayment() {
      const url = "/getdropdownitems/DefferedPayment";
      httpClient
        .get(url)
        .then(response => {
          console.log(response.data);
          console.log("testing");
          if (response.data == "token refreshed") {
            this.getDefferedPayment();
            return;
          }
          if (response.data) {
            this.defferedPayment = response.data.data.map(x => {
              return { text: x.value };
            });
          }
        })
        .catch(error => console.log(error));
    },
    getCountries() {
      const url = "/getdropdownitems/Countries";
      httpClient
        .get(url)
        .then(response => {
          if (response.data) {
            if (response.data == "token refreshed") {
              this.getCountries();
            }
            this.countryList = response.data.data.map(x => {
              return { value: x.key, text: x.value };
            });
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
