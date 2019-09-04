<template>
  <div>
    <b-form class="pd-10 form-bg-color">
      <p class="block-heading">{{language.lang.consignor}}</p>
      <b-form-group>
        <label> {{language.lang.name}} </label>
        <b-form-input
          v-model="declaration.consignorName"
          required
        ></b-form-input>
      </b-form-group>
      <b-form-group>
        <label> {{language.lang.address1}}</label>
        <b-form-input
          v-model="declaration.consignorAddress1"
          required
        ></b-form-input>
      </b-form-group>
      <b-form-group >
        <label>{{language.lang.address2}}</label>
        <b-form-input
          v-model="declaration.consignorAddress2"
          required
        ></b-form-input>
      </b-form-group>
      <b-row>
        <b-col>
          {{language.lang.postalCode}}
          <b-form-input
            v-model="declaration.consignorPostalCode"
          ></b-form-input>
        </b-col>
        <b-col>
          {{language.lang.city}}
          <b-form-input v-model="declaration.consignorCity"></b-form-input>
        </b-col>
        <b-col>
          {{language.lang.country}}
          <b-form-select
            v-model="declaration.consignorCountry"
            :options="countryList"
            required
          ></b-form-select>
        </b-col>
      </b-row>
    </b-form>
  </div>
</template>

<script>
import httpClient from "./../utils/httpRequestWrapper";
import allLanguages from './../utils/languageSwitch';

export default {
  props: {
    declaration: Object,
    language: Object
  },
  data() {
    return{
      countryList: [],
    }
  },
  mounted() {
    this.getCountries();
  },
  methods: {
    getCountries() {
      const url = "/getdropdownitems/Countries";
      httpClient
        .get(url)
        .then(response => {
          if (response.data == "token refreshed") {
            this.getCountries();
            return;
          }
          if (response.data) {
            this.countryList = response.data.data.map(x => {
              return { value: x.key, text: x.value };
            });
          }
        })
        .catch(error => console.log(error));
    }
  }
};
</script>

<style>
@import url("./style/declarationStyle.css");
</style>
