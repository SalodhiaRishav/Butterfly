<template>
  <div>
    <b-form class="pd-10 form-bg-color">
      <p class="block-heading">Consignor/exporter</p>
      <b-form-group label="*Name:">
        <b-form-input
          v-model="declaration.consignorName"
          required
        ></b-form-input>
      </b-form-group>
      <b-form-group label="*Address1:">
        <b-form-input
          v-model="declaration.consignorAddress1"
          required
        ></b-form-input>
      </b-form-group>
      <b-form-group label="*Address2:">
        <b-form-input
          v-model="declaration.consignorAddress2"
          required
        ></b-form-input>
      </b-form-group>
      <b-row>
        <b-col>
          *postal code
          <b-form-input
            v-model="declaration.consignorPostalCode"
          ></b-form-input>
        </b-col>
        <b-col>
          *City
          <b-form-input v-model="declaration.consignorCity"></b-form-input>
        </b-col>
        <b-col>
          Country
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
import httpClient from "./../Utils/HttpRequestWrapper";

export default {
  props: {
    declaration: Object
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
          console.log("data fethec consigner countries");
          console.log(response);
          console.log("testing");
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
@import url("./Style/DeclarationStyle.css");
</style>
