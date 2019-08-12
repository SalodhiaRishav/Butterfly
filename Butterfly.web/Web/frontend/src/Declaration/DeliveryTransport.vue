<template>
  <b-form
    style="padding:10px; background:#F2F2F2 ;"
    @submit="onSubmit"
    @reset="onReset"
    v-if="show"
  >
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
        v-model="declaration.modeOfTransPort"
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
import axios from "axios";

export default {
  props: {
    declaration: Object
  },
  data() {
    return {
      TermsOfDelivery: [],
      deliveryPlace: "",
      countryList: [],
      LocationOfGoods: [],
      ModeOfTransport: [],
      SupervisingCustomsOffice: [],
      dropDown: [{ text: "<Please select>", value: null }, "1", "2", "3", "4"],
      show: true
    };
  },
  mounted() {
    axios
      .get("https://localhost:44313/getdropdownitems/TermsOfDelivery")
      .then(response => {
        if (response.data) {
          console.log(response.data.data);
          this.TermsOfDelivery = response.data.data.map(x => {
            return { value: x.key, text: x.value };
          });
        }
      })
      .catch(error => console.log(error));
    axios
      .get("https://localhost:44313/getdropdownitems/Countries")
      .then(response => {
        if (response.data) {
         // console.log(response.data.data);
          this.countryList = response.data.data.map(x => {
            return { value: x.key, text: x.value };
          });
        }
      })
      .catch(error => console.log(error));
    axios
      .get("https://localhost:44313/getdropdownitems/LocationOfGoods")
      .then(response => {
        if (response.data) {
         // console.log(response.data.data);
          this.LocationOfGoods = response.data.data.map(x => {
            return { value: x.key, text: x.value };
          });
        }
      })
      .catch(error => console.log(error));
    axios
      .get("https://localhost:44313/getdropdownitems/ModeOfTransport")
      .then(response => {
        if (response.data) {
         // console.log(response.data.data);
          this.ModeOfTransport = response.data.data.map(x => {
            return { value: x.key, text: x.value };
          });
        }
      })
      .catch(error => console.log(error));
    axios
      .get("https://localhost:44313/getdropdownitems/SupervisingCustomOfiice")
      .then(response => {
        if (response.data) {
        //  console.log(response.data.data);
          this.SupervisingCustomsOffice = response.data.data.map(x => {
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
      // Reset our form values
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
