<template>
  <b-form
    style="padding:10px; background:#F2F2F2 ;"
    @submit="onSubmit"
    @reset="onReset"
    v-if="show"
  >
    <p class="block-heading">Consignee</p>

    <b-form-group label="Org. number:">
      <b-form-input
        v-model="declaration.consigneeOrganisationNumber"
        required
      ></b-form-input>
    </b-form-group>

    <b-form-group label="Name">
      <b-form-input v-model="declaration.consigneeName" required></b-form-input>
    </b-form-group>

    <b-form-group label="Address 1">
      <b-form-input
        v-model="declaration.consigneeAddress1"
        required
      ></b-form-input>
    </b-form-group>

    <b-form-group label="Address 2">
      <b-form-input
        v-model="declaration.consigneeAddress2"
        required
      ></b-form-input>
    </b-form-group>
    <b-row>
      <b-col>
        *postal code
        <b-form-input v-model="declaration.consigneePostalCode"></b-form-input>
      </b-col>
      <b-col>
        *City
        <b-form-input v-model="declaration.consigneeCity"></b-form-input>
      </b-col>
      <b-col>
        Country
        <b-form-select
          v-model="declaration.consigneeCountry"
          :options="countryList"
          required
        ></b-form-select>
      </b-col>
    </b-row>
    <b-form-group label="Customs credit number(48)">
      <b-form-input
        v-model="declaration.customCreditNumber"
        required
      ></b-form-input>
    </b-form-group>

    <b-form-group label="Deffered payment(48)">
      <b-form-select
        v-model="declaration.defferedPayment"
        :options="defferedPayment"
        required
      ></b-form-select>
    </b-form-group>
  </b-form>
</template>

<script>
import httpClient from "./../Utils/HttpRequestWrapper";

export default {
  props: {
    declaration: Object
  },
  data() {
    return {
      OrgNum: "",
      consigneeName: "",
      consigneeAddress1: "",
      consigneeAddress2: "",
      customsCreditNumber: "",
      defferedPayment: [],
      dropDown: [{ text: "<Please select>", value: null }, "1", "2", "3", "4"],
      show: true,
      countryList: []
    };
  },
  mounted() {
      this.getDefferedPayment();
      this.getCountries();
  },
  methods: {
    getDefferedPayment(){
      const url="/getdropdownitems/DefferedPayment";
      console.log("testing payment");
      httpClient
      .get(url)
      .then(response => {
        console.log("data fethec defferedpayment");
        console.log(response);
        console.log("testing");
        if(response.data=="token refreshed")
        {
          this.getDefferedPayment();
          return ;
        }
        if (response.data) {
          this.defferedPayment = response.data.data.map(x => {
            return { text: x.value };
          });
        }
      })
      .catch(error => console.log(error));
    },

    getCountries(){
      const url="/getdropdownitems/Countries";
       httpClient
      .get(url)
      .then(response => {
        
        if (response.data) {
        if(response.data=="token refreshed")
        {
          this.getCountries();
        }
          this.countryList = response.data.data.map(x => {
            return { value: x.key, text: x.value };
          });
        }
      })
      .catch(error => console.log(error));
    },

    onSubmit(evt) {
      //   evt.preventDefault();
      //   alert(JSON.stringify(this.form));
      //some code here
    },
    onReset(evt) {
      //add some code here
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
