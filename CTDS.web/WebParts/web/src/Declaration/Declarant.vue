<template>
  <b-form class="pd-10 form-bg-color">
    <p class="block-heading">Declarant</p>

    <b-form-group label="*Org. number">
      <b-form-input
        v-model="declaration.declarantOrganisationNumber"
        required
      ></b-form-input>
    </b-form-group>

    <b-form-group label="Name">
      <b-form-input v-model="declaration.declarantName" required></b-form-input>
    </b-form-group>

    <b-form-group label="Address 1:">
      <b-form-input
        v-model="declaration.declarantAddress1"
        required
      ></b-form-input>
    </b-form-group>
    <b-form-group label="Address 2:">
      <b-form-input
        v-model="declaration.declarantAddress2"
        required
      ></b-form-input>
    </b-form-group>
    <b-row>
      <b-col>
        *postal code
        <b-form-input v-model="declaration.declarantPostalCode"></b-form-input>
      </b-col>
      <b-col>
        *City
        <b-form-input v-model="declaration.declarantCity"></b-form-input>
      </b-col>
      <b-col>
        Country
        <b-form-select
          v-model="declaration.declarantCountry"
          :options="Country"
          required
        ></b-form-select>
      </b-col>
    </b-row>
    <b-form-group label="*Contact person:">
      <b-form-input v-model="declaration.contactPerson" required></b-form-input>
    </b-form-group>
  </b-form>
</template>

<script>
import httpClient from "./../utils/httpRequestWrapper";

export default {
  props: {
    declaration: Object
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
