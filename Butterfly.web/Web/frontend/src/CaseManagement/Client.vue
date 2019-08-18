<template>
  <div>
    <div role="tablist">
      <b-card no-body>
        <div class="componentHeader">
          <b-card-header
            header-tag="header"
            header="Client"
            header-text-variant="white"
            v-b-toggle.accordion-client
            class="p-1"
            role="tab"
          >
          </b-card-header>
        </div>
        <b-collapse id="accordion-client" visible role="tabpanel">
          <b-card-body class="componentCard">
            <b-form>
              <div v-if="identifierFetched">
                <b-form-group
                  id="clientIdentifier"
                  label="Client Identifier"
                  label-for="clientIdentifierInput"
                >
                  <b-form-input
                    id="clientIdentifierInput"
                    v-model="clientDetails.clientIdentifier"
                    required
                  ></b-form-input>
                </b-form-group>
              </div>
              <b-form-group
                id="identifierType"
                label="Identifier Type"
                label-for="identifierTypeInput"
              >
                <b-form-radio-group
                  v-model="clientDetails.identifierType"
                  :options="identifierTypes"
                ></b-form-radio-group>
              </b-form-group>
              <b-form-group id="name" label="Name" label-for="nameInput">
                <b-form-input
                  id="nameInput"
                  v-model="clientDetails.name"
                  required
                ></b-form-input>
              </b-form-group>
              <b-form-group
                id="address"
                label="Address"
                label-for="addressInput"
              >
                <b-form-input
                  id="addressInput"
                  v-model="clientDetails.address"
                  required
                ></b-form-input>
              </b-form-group>
              <b-form-group
                id="postalCode"
                label="Postal Code"
                label-for="postalCodeInput"
              >
                <b-form-input
                  id="postalCodeInput"
                  v-model="clientDetails.postalCode"
                  required
                ></b-form-input>
              </b-form-group>
              <b-form-group id="city" label="City" label-for="cityInput">
                <b-form-input
                  id="cityInput"
                  v-model="clientDetails.city"
                  required
                ></b-form-input>
              </b-form-group>

              <b-form-group
                id="country"
                label="Country"
                label-for="countryInput"
              >
                <b-form-select
                  id="countryInput"
                  v-model="clientDetails.country"
                  :options="countries"
                  required
                ></b-form-select>
              </b-form-group>

              <b-form-group id="email" label="E-mail" label-for="emailInput">
                <b-form-input
                  id="emailInput"
                  v-model="clientDetails.email"
                  required
                ></b-form-input>
              </b-form-group>
            </b-form>
          </b-card-body>
        </b-collapse>
      </b-card>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  mounted() {
    this.getIdentiferTypes()
      .then(response => {
        if (response !== null) {
          this.identifierTypes = response;
          this.identifierFetched = true;
        }
      })
      .catch(error => {
        alert(error);
      });
    this.getCountries().then(response => {
      let countriesObj = response;
      let countries = [];
      if (countriesObj !== null) {
        for (let i = 0; i < response.length; ++i) {
          countries.push(countriesObj[i].value);
        }
        this.countries = countries;
      }
    });
  },
  data() {
    return {
      countries: [],
      identifierFetched: false,
      identifierTypes: [],
      clientDetails: this.$store.getters.clientDetails
    };
  },
  methods: {
    getCountries: function() {
      return new Promise((resolve, reject) => {
        const url = "https://localhost:44313/getdropdownitems/countries";
        axios
          .get(url)
          .then(response => {
            if (response.data.success === true) {
              resolve(response.data.data);
            } else {
              resolve(null);
            }
          })
          .catch(error => {
            reject(error);
          });
      });
    },
    getIdentiferTypes: function() {
      return new Promise((resolve, reject) => {
        const url = "https://localhost:44313/identifiertypes";
        axios
          .get(url)
          .then(response => {
            if (response.data.success === true) {
              resolve(response.data.data);
            } else {
              resolve(null);
            }
          })
          .catch(error => {
            reject(error);
          });
      });
    }
  }
};
</script>
