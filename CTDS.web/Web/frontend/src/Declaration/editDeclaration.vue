<template>
  <div>
     <appNavbar></appNavbar>
    <editdeclarationheader :declaration="declaration" :referenceData="referenceData"></editdeclarationheader>
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
              <ValueDetails
                :declaration="declaration"
                :referenceData="referenceData"
              ></ValueDetails>
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
import editdeclarationheader from "./EditDeclarationHeader";
import DeclarationType from "./DeclarationType";
import Consignor from "./Consignor";
import Consignee from "./Consignee";
import Declarant from "./Declarant";
import Delivery from "./DeliveryTransport";
import ValueDetails from "./ValueDetails";
import appNavbar from './../CommonComponent/Navbar.vue'
import httpClient from "./../Utils/HttpRequestWrapper";
import { constants } from 'crypto';
// import axios from 'axios';

export default {
  components: {
    DeclarationType,
    Consignor,
    Consignee,
    Declarant,
    Delivery,
    ValueDetails,
    editdeclarationheader,
    appNavbar
  },
  mounted() {
  this.getDeclarationById();
  },
  data() {
    return {
      declaration: {
        declarationId: "",
        messageName: "",
        declarationType1: "",
        declarationType2: "",
        consignorName: "",
        consignorAddress1: "",
        consignorAdress2: "",
        consignorPostalCode: "",
        consignorCity: "",
        consignorCountry: "",
        consigneeOrganisationNumber: "",
        consigneeName: "",
        consigneeAddress1: "",
        consigneeAddress2: "",
        consigneePostalCode: "",
        consigneeCity: "",
        consigneeCountry: "",
        customCreditNumber: "",
        defferedPayment: "",
        declarantOrganisationNumber: "",
        declarantName: "",
        declarantAddress1: "",
        declarantAddress2: "",
        declarantPostalCode: "",
        declarantCity: "",
        declarantCountry: "",
        contactPerson: "",
        termsOfDelivery: "",
        deliveryPlace: "",
        countryOfDispatch: "",
        nationalityOfTransport: "",
        modeOfTransport: "",
        locationOfGoods: "",
        supervisingCustomOffice: "",
        freight: "",
        amount: "",
        currency: "",
        rate: ""
      },
      referenceData: {
        reference: []
      }
    };
  },

  methods: {
    getDeclarationById()
    {
    //  var guid = this.$store.getters.declrationIdToEdit;
    var guid=this.$route.params.id;
      httpClient
      .get(`/getdeclarationbyguid/${guid}`)
      .then(response => {
        if(response.data === "token refreshed")
        {
          this.getDeclarationById();
        }
        if (response.data.data)
          this.declaration = response.data.data.declaration;
        this.referenceData.reference = response.data.data.referenceData;
      })
      .catch(e => console.log(e));
    },
  }
};
</script>

<style>
@import url('./Style/DeclarationStyle.css');
</style>
