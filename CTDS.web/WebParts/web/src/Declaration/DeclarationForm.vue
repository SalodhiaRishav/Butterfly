<template>
  <div>
    <Navbar></Navbar>
    <DeclarationHeader
      :declaration="declaration"
      :referenceData="referenceData"
    ></DeclarationHeader>
    <b-tabs card class="color-black bg-color-e6">
      <b-tab title="Header" active>
        <div class ="pd-top-10 pd-rt-0 pd-lf-0">
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
          <b-row class="pd-top-14">
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
import DeclarationHeader from "./DeclarationHeader.vue";
import DeclarationType from "./DeclarationType";
import Consignor from "./Consignor";
import Consignee from "./Consignee";
import Declarant from "./Declarant";
import Delivery from "./DeliveryTransport";
import ValueDetails from "./ValueDetails";
import Navbar from "./../commonComponent/Navigationbar";

export default {
  components: {
    DeclarationHeader,
    DeclarationType,
    Consignor,
    Consignee,
    Declarant,
    Delivery,
    ValueDetails,
    Navbar
  },
  data() {
    return {
      declaration: {
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
};
</script>

<style>
  @import url(./style/declarationStyle.css);
</style>
