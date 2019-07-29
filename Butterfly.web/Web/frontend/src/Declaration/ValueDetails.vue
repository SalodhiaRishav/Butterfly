<template>
<div>
     <b-form style="padding:10px; background:#F2F2F2;" @submit="onSubmit" @reset="onReset" v-if="show">
            
            <p class="block-heading">Value details</p>
            <b-form-group label="freight, outward NDK">
              <b-form-input v-model="declaration.valueDetails.freight" required ></b-form-input>
            </b-form-group>
            Total invoice amount <br>
            <b-row>
              <b-col>
              Amount<br>
              <b-form-input v-model="declaration.valueDetails.amount" required></b-form-input>
            </b-col>
            <b-col>
            Cuurency <br>
              <b-form-select v-model="declaration.valueDetails.currency" :options="dropDown" required></b-form-select>
            </b-col>
            <b-col>
              Rate <br> 
              <b-form-select v-model="declaration.valueDetails.rate" :options="dropDown" required></b-form-select>
            </b-col>      
            </b-row>   
          </b-form> 
          <div role="tablist" style="padding:10px; background:#F2F2F2;">
            <p class="block-heading">References</p>
          <b-table  hover :items="references" :fields="fields">
            <template slot="#" slot-scope="data">
              <button @click="deleteReference(data.index)">Delete</button>
            </template>
          </b-table>
          <b-table  :fields="fields">
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
  props:{
    declaration:Object,
  },
 data() {
    return {
      frieght:"",
      amount:"",
      currency:"",
      rate:"",
      dropDown: [{ text: "<Please select>", value: null }, "1", "2", "3", "4"],
      show: true,
      showReferenceForm: false,
      fields: ["type", "invoiceDate", "reference", "#"],
      references: [],
      referenceForm: {
        reference: "",
        invoiceDate: "",
        type: null,
      }
    };
  },
   computed: {
    referenceTypes: () => {
      return [
        { text: "Select", value: null },
        "1234",
        "2345",
        "34567"
      ];
    }
  },
  methods: {
    deleteReference(index) {
      this.references.splice(index, 1);
      this.declaration.reference = this.references;
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
        this.declaration.reference = this.references;
        this.resetReferenceForm();
      }
    },
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
}
</script>

<style>
.block-heading {
  margin: -10px -10px 0px -10px;
  color: white;
  background: #929397 ;
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
