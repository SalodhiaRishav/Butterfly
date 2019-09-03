<template>
  <b-form class="pd-10 form-bg-color">
    <p class="block-heading">{{language.lang.declarant}}</p>

    <b-form-group>
      <label>{{language.lang.orgNumber}}</label>
      <b-form-input
        v-model="declaration.declarantOrganisationNumber"
        required
      ></b-form-input>
    </b-form-group>

    <b-form-group>
      <label>{{language.lang.name}}</label>
      <b-form-input v-model="declaration.declarantName" required></b-form-input>
    </b-form-group>

    <b-form-group>
      <label >{{language.lang.address1}}</label>
      <b-form-input
        v-model="declaration.declarantAddress1"
        required
      ></b-form-input>
    </b-form-group>
    <b-form-group>
      <label>{{language.lang.address2}}</label>
      <b-form-input
        v-model="declaration.declarantAddress2"
        required
      ></b-form-input>
    </b-form-group>
    <b-row>
      <b-col>
        {{language.lang.postalCode}}
        <b-form-input v-model="declaration.declarantPostalCode"></b-form-input>
      </b-col>
      <b-col>
        {{language.lang.city}}
        <b-form-input v-model="declaration.declarantCity"></b-form-input>
      </b-col>
      <b-col>
        {{language.lang.country}}
        <b-form-select
          v-model="declaration.declarantCountry"
          :options="Country"
          required
        ></b-form-select>
      </b-col>
    </b-row>
    <b-form-group>
      {{language.lang.contactPerson}}
      <b-form-input v-model="declaration.contactPerson" required></b-form-input>
    </b-form-group>
  </b-form>
</template>

<script>
import httpClient from "./../utils/httpRequestWrapper";
import allLanguages from './../utils/languageSwitch';

export default {
  props: {
    declaration: Object,
    language: Object
  },
  data(){
    return{
      Country:[],
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
          }
          if (response.data) {
            this.Country = response.data.data.map(x => {
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
