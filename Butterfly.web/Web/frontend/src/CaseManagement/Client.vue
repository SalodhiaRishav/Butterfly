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
              <b-form-group
                id="city"
                label="Client Identifier"
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
export default {
  data() {
    return {
      clientDetails: this.$store.getters.clientDetails
    };
  },
  computed: {
    countries: () => {
      const countries = [
        { text: "Select Country", value: null },
        "India",
        "Pakistan",
        "Poland",
        "Germany",
        "USA"
      ];
      return countries;
    },
    identifierTypes: () => {
      const identifierTypes = ["EORI", "TIN", "CNR"];
      return identifierTypes;
    }
  }
};
</script>
