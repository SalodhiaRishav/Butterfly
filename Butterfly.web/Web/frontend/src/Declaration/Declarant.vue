<template>
  <b-form
    style="padding:10px; background:#F2F2F2;"
    @submit="onSubmit"
    @reset="onReset"
    v-if="show"
  >
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
import axios from "axios";

export default {
  props: {
    declaration: Object
  },
  data() {
    return {
      orgNumber: "",
      declarantName: "",
      declarantAddress1: "",
      declarantAddress2: "",
      declarantPostalCode: "",
      declarantCity: "",
      Country: [],
      declarantContactPerson: "",
      dropDown: [{ text: "<Please select>", value: null }, "1", "2", "3", "4"],
      show: true
    };
  },
  mounted() {
    axios
      .get("https://localhost:44313/getdropdownitems/Countries")
      .then(response => {
        if (response.data) {
          console.log(response.data.data);
          this.Country = response.data.data.map(x => {
            return { value: x.key, text: x.value };
          });
        }
      })
      .catch(error => console.log(error));
  },
  methods: {
    onSubmit(evt) {
      //   evt.preventDefault();
      //   alert(JSON.stringify(this.form));
      //some code here
    },
    onReset(evt) {
      evt.preventDefault();
      // Reset our form values
      this.form.email = "";
      this.form.name = "";
      this.form.food = null;
      this.form.checked = [];
      // Trick to reset/clear native browser form validation state
      this.show = false;
      this.$nextTick(() => {
        this.show = true;
      });
    }
  }
};
</script>

<style>
.block-heading {
  margin: -10px -10px 0px -10px;
  color: white;
  background: #929397;
  padding: 3px;
}
.pd-rt-0 {
  padding-right: 0px;
}
.pd-rt-27 {
  padding-right: 27px;
}
.pd-lf-0 {
  padding-left: 0px;
}
.pd-lf-27 {
  padding-left: 27px;
}
.border-rt {
  border-right: 1px solid #908787;
}
</style>
