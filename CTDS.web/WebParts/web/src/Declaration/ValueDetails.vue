<template>
  <div>
    <b-form class="pd-10 form-bg-color">
      <p class="block-heading">Value details</p>
      <b-form-group label="freight, outward NDK">
        <b-form-input v-model="declaration.freight" required></b-form-input>
      </b-form-group>
      Total invoice amount <br />
      <b-row>
        <b-col>
          Amount<br />
          <b-form-input v-model="declaration.amount" required></b-form-input>
        </b-col>
        <b-col>
          Cuurency <br />
          <b-form-select
            v-model="declaration.currency"
            :options="dropDown"
          ></b-form-select>
        </b-col>
        <b-col>
          Rate <br />
          <b-form-input
            v-model="declaration.rate"
            :options="dropDown"
            required
          ></b-form-input>
        </b-col>
      </b-row>
    </b-form>
    <div role="tablist" class="pd-10 bg-f2">
      <p class="block-heading">References</p>
      <b-table hover :items="referenceData.reference" :fields="fields">
        <template slot="#" slot-scope="data">
          <button @click="deleteReference(data.index)">Delete</button>
        </template>
      </b-table>
      <b-table :fields="fields">
        <template slot="HEAD_invoiceDate">
          <b-form-input
            id="invoiceDateInput"
            type="date"
            v-model="referenceForm.invoiceDate"
          ></b-form-input>
        </template>
        <template slot="HEAD_type">
          <b-form-select
            id="referenceTypeInput"
            :options="referenceTypes"
            v-model="referenceForm.type"
          ></b-form-select>
        </template>
        <template slot="HEAD_reference">
          <b-form-input
            id="referenceInput"
            v-model="referenceForm.reference"
          ></b-form-input>
        </template>
        <template slot="HEAD_#">
          {{&nbsp;}}
        </template>
      </b-table>
      <b-button @click="addNewReference">Add</b-button>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    declaration: Object,
    referenceData: Object
  },
  data() {
    return {
      showReferenceForm: false,
      fields: ["type", "invoiceDate", "reference", "#"],
      references: [],
      referenceForm: {
        reference: "",
        invoiceDate: "",
        type: null
      }
    };
  },
  computed: {
    referenceTypes: () => {
      return [{ text: "Select", value: null }, "1234", "2345", "34567"];
    }
  },
  methods: {
    deleteReference(index) {
      this.references.splice(index, 1);
      this.referenceData.reference = this.references;
    },
    resetReferenceForm: function() {
      this.referenceForm.type = null;
      this.referenceForm.invoiceDate = "";
      this.referenceForm.reference = "";
    },
    addNewReference: function() {
      this.showReferenceForm = true;
      if (
        this.referenceForm.type !== null &&
        this.referenceForm.invoiceDate !== "" &&
        this.referenceForm.reference !== ""
      ) {
        const newReferenceDetails = {
          type: this.referenceForm.type,
          invoiceDate: this.referenceForm.invoiceDate,
          reference: this.referenceForm.reference
        };
        this.referenceData.reference.push(newReferenceDetails);
        this.resetReferenceForm();
      }
    }
  }
};
</script>

<style>
@import url("./style/declarationStyle.css");
</style>
