<template>
  <div>
    <div role="tablist">
      <b-card no-body>
        <div class="componentHeader">
          <b-card-header
            header-tag="header"
            :header="labels.client"
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
                  :label="labels.clientIdentifier"
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
                :label="labels.identifierType"
                label-for="identifierTypeInput"
              >
                <b-form-radio-group
                  v-model="clientDetails.identifierType"
                  :options="identifierTypes"
                ></b-form-radio-group>
              </b-form-group>
              <b-form-group
                id="name"
                :label="labels.name"
                label-for="nameInput"
              >
                <b-form-input
                  id="nameInput"
                  v-model="clientDetails.name"
                  required
                ></b-form-input>
              </b-form-group>
              <b-form-group
                id="address"
                :label="labels.address"
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
                :label="labels.postalCode"
                label-for="postalCodeInput"
              >
                <b-form-input
                  id="postalCodeInput"
                  v-model="clientDetails.postalCode"
                  required
                ></b-form-input>
              </b-form-group>
              <b-form-group
                id="city"
                :label="labels.city"
                label-for="cityInput"
              >
                <b-form-input
                  id="cityInput"
                  v-model="clientDetails.city"
                  required
                ></b-form-input>
              </b-form-group>

              <b-form-group
                id="country"
                :label="labels.country"
                label-for="countryInput"
              >
                <b-form-select
                  id="countryInput"
                  v-model="clientDetails.country"
                  :options="countries"
                  required
                ></b-form-select>
              </b-form-group>

              <b-form-group
                id="email"
                :label="labels.email"
                label-for="emailInput"
              >
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
import httpClient from "./../utils/httpRequestWrapper";

export default {
  props: ["labels"],
    data() {
    return {
      countries: [],
      identifierFetched: false,
      identifierTypes: [],
      clientDetails: this.$store.getters.clientDetails
    };
  },
  mounted() {
    this.getIdentiferTypes();
    this.getCountries();
  },
  methods: {
    getCountries: function() {
      const resource = "/getdropdownitems/countries";
      httpClient
        .get(resource)
        .then(response => {
          if (response.data === "token refreshed") {
            this.getCountries();
            return;
          }
          if (response.data.success === true) {
            let countries = response.data.data;
            let countriesNames = [];
            if (countries !== null) {
              for (let i = 0; i < countries.length; ++i) {
                countriesNames.push(countries[i].value);
              }
              this.countries = countriesNames;
            } else {
              alert(response.data.message);
            }
          }
        })
        .catch(error => {
          alert(error);
        });
    },
    getIdentiferTypes: function() {
      const resource = "/identifiertypes";
      httpClient
        .get(resource)
        .then(response => {
          if (response.data === "token refreshed") {
            this.getIdentiferTypes();
            return;
          }
          if (response.data.success === true) {
            this.identifierTypes = response.data.data;
            this.identifierFetched = true;
          } else {
            alert(response.data.message);
          }
        })
        .catch(error => {
          alert(error);
        });
    }
  }
};
</script>
