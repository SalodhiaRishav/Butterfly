<template>
  <div role="tablist">
    <b-table fixed striped hover :items="references" :fields="fields">
      <template slot="#" slot-scope="data">
        <button @click="deleteReference(data.index)">Delete</button>
      </template>
    </b-table>
    <b-table fixed :fields="fields">
      <template slot="HEAD_invoiceDate" slot-scope="data">
        <b-form-input
          id="invoiceDateInput"
          :placeholder="data.label"
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
      <template slot="HEAD_reference" slot-scope="data">
        <b-form-input
          id="referenceInput"
          :placeholder="data.label"
          v-model="referenceForm.reference"
        ></b-form-input>
      </template>
      <template slot="HEAD_#">
        {{&nbsp;}}
      </template>
    </b-table>
    <b-button @click="addNewReference">Add</b-button>
  </div>
</template>

<script>
export default {
  data() {
    return {
      showReferenceForm: false,
      fields: ["reference", "invoiceDate", "type", "#"],
      references: [],
      referenceForm: {
        reference: "",
        invoiceDate: "",
        type: null
        // date
      }
    };
  },
  computed: {
    referenceTypes: () => {
      return [{ text: "Select type", value: null }, "1", "2", "3"];
    }
  },
  methods: {
    deleteReference(index) {
      this.references.splice(index, 1);
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
        this.references.push(newReferenceDetails);
        this.resetReferenceForm();
      }
    }
  }
};
</script>
