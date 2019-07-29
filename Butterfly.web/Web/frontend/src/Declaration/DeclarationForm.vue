<template>
  <div>
    <declarationheader :declaration="declaration"></declarationheader>
    <b-tabs card style="color:black; background-color:#E6E6E6">
      <b-tab title="Header" active>
        <div style="padding-top:10px; padding-right:0px; padding-left:0px">
          <b-row>
            <b-col cols="3" class="pd-lf-27">
              <!-- Declaration type -->
              <DeclarationType :declaration="declaration"></DeclarationType>
            </b-col>
            <b-col cols="5" class="pd-lf-0">
              <!-- consignor-->
              <Consignor :declaration="declaration"></Consignor>
            </b-col>
            <b-col class="pd-lf-0 pd-rt-27">
              <!-- Consignee -->
              <Consignee :declaration="declaration"></Consignee>
            </b-col>
          </b-row>
          <b-row style="padding-top:14px">
            <b-col cols="4" class="pd-lf-27">
              <!-- Declarant -->
              <Declarant :declaration="declaration"></Declarant>
            </b-col>
            <b-col cols="3" class="pd-lf-0">
              <!-- Delivery and transport -->
              <Delivery :declaration="declaration"></Delivery>
            </b-col>
            <b-col col="5" class="pd-lf-0 pd-rt-27">
              <!-- Value Details -->
              <ValueDetails :declaration="declaration"></ValueDetails>
            
            </b-col>
          </b-row>
        </div>
      </b-tab>
    </b-tabs>
  </div>
</template>

<script>
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
import declarationheader from './header.vue';
import DeclarationType from "./DeclarationType";
import Consignor from "./Consignor";
import Consignee from "./Consignee";
import Declarant from "./Declarant";
import Delivery from "./DeliveryTransport";
import ValueDetails from "./ValueDetails";

export default {
  components: {
       declarationheader,
    DeclarationType,
    Consignor,
    Consignee,
    Declarant,
    Delivery,
    ValueDetails
  },
  data() {
    return {
      declaration : {
        declarationType:{
        messageName:"",
        declarationType1:"",
        declarationType2:"",
        },
        consignor:{
          name:"",
          address1:"",
          address2:"",
          postalCode:"",
          city:"",
          country:""
        },
        consignee:{
          orgNumber:"",
          name:"",
          address1:"",
          address2:"",
          customCreditNumber:"",
          defferedPayment:""
        },
        declarant:{
          orgNumber:"",
          name:"",
          address1:"",
          address2:"",
          postalCode:"",
          city:"",
          country:"",
          contactPerson:""
        },
        deliverySupport:{
          termsOfDelivery:"",
          deliveryPlace:"",
          countryOfDispatch:"",
          nationalityOfTransport1:"",
          modeOfTransport:"",
          locationOfGoods:"",
          supervisingCustomOffice:"",
        },
        valueDetails:{
          freight:"",
          amount:"",
          currency:"",
          rate:"",
        },
        reference:[],
      }
    };
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
