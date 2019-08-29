<template>
  <b-form class="pd-10 form-bg-color">
    <div>
      <p class="block-heading">Delivery and transport</p>
    </div>
    <b-row>
      <b-col>
        *Terms of delivery
        <b-form-select
          v-model="declaration.termsOfDelivery"
          :options="TermsOfDelivery"
          required
        ></b-form-select>
      </b-col>
      <b-col>
        *Delivery place(20:2)
        <b-form-input
          v-model="declaration.deliveryPlace"
          required
        ></b-form-input>
      </b-col>
    </b-row>
    <b-form-group label="*Country of dispatch/export">
      <b-form-select
        v-model="declaration.countryOfDispatch"
        :options="countryList"
        required
      ></b-form-select>
    </b-form-group>
    <b-form-group label="*Nationality of transport at border(21):">
      <b-form-select
        v-model="declaration.nationalityOfTransport"
        :options="countryList"
        required
      ></b-form-select>
    </b-form-group>
    <b-form-group label="*Mode of transport at the border(25):">
      <b-form-select
        v-model="declaration.modeOfTransport"
        :options="ModeOfTransport"
        required
      ></b-form-select>
    </b-form-group>
    <b-form-group label="*Location of goods(30):">
      <b-form-select
        v-model="declaration.locationOfGoods"
        :options="LocationOfGoods"
        required
      ></b-form-select>
    </b-form-group>
    <b-form-group label="*Supervising customs office:">
      <b-form-select
        v-model="declaration.supervisingCustomOffice"
        :options="SupervisingCustomsOffice"
        required
      ></b-form-select>
    </b-form-group>
  </b-form>
</template>

<script>
import httpClient from "./../utils/httpRequestWrapper";

export default {
  props: {
    declaration: Object
  },
  data() {
    return {
      TermsOfDelivery: [],
      countryList:[],
      LocationOfGoods:[],
      SupervisingCustomsOffice:[],
      ModeOfTransport: [],
    }
  },
  mounted() {
    this.getTermsOfDelivery();
    this.getCountries();
    this.getLocationOfGoods();
    this.getSupervisingCustomOffice();
    this.getModeOfTransport();
  },

  methods: {
    getSupervisingCustomOffice() {
      const url = "/getdropdownitems/SupervisingCustomOfiice";
      httpClient
        .get(url)
        .then(response => {
          if (response.data === "token refreshed") {
            this.getSupervisingCustomOffice();
            return;
          }
          if (response.data) {
            this.SupervisingCustomsOffice = response.data.data.map(x => {
              return { value: x.key, text: x.value };
            });
          }
        })
        .catch(error => console.log(error));
    },
    getModeOfTransport() {
      const url = "/getdropdownitems/ModeOfTransport";
      httpClient
        .get(url)
        .then(response => {
          if (response.data === "token refreshed") {
            this.getModeOfTransport();
            return;
          }
          if (response.data) {
            this.ModeOfTransport = response.data.data.map(x => {
              return { value: x.key, text: x.value };
            });
          }
        })
        .catch(error => console.log(error));
    },
    getLocationOfGoods() {
      const url = "/getdropdownitems/LocationOfGoods";
      httpClient
        .get(url)
        .then(response => {
          if (response.data === "token refreshed") {
            this.getLocationOfGoods();
            return;
          }
          if (response.data) {
            this.LocationOfGoods = response.data.data.map(x => {
              return { value: x.key, text: x.value };
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
          if (response.data === "token refreshed") {
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
    },
    getTermsOfDelivery() {
      const url = "/getdropdownitems/TermsOfDelivery";
      httpClient
        .get(url)
        .then(response => {
          if (response.data === "token refreshed") {
            this.getTermsOfDelivery();
            return;
          }
          if (response.data) {
            console.log(response.data.data);
            this.TermsOfDelivery = response.data.data.map(x => {
              return { value: x.key, text: x.value };
            });
          }
        })
        .catch(error => console.log(error));
    },
  }
};
</script>

<style>
@import url("./style/declarationStyle.css");
</style>
