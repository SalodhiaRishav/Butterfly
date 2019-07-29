<template>
     <b-form style="padding:10px; background:#F2F2F2 ;" @submit="onSubmit" @reset="onReset" v-if="show">             
            <p class="block-heading">Consignee</p>
             
            <b-form-group label="Org. number:">
              <b-form-input v-model="declaration.consignee.orgNumber" required></b-form-input>
            </b-form-group>
      
             <b-form-group label="Name">
              <b-form-select v-model="declaration.consignee.name" :options="dropDown" required></b-form-select>
            </b-form-group>

             <b-form-group label="Address 1">
              <b-form-select v-model="declaration.consignee.address1" :options="dropDown" required></b-form-select>
            </b-form-group>

            <b-form-group label="Address 2">
              <b-form-select v-model="declaration.consignee.address2" :options="dropDown" required></b-form-select>
            </b-form-group>

            <b-form-group label="Customs credit number(48)">
              <b-form-select v-model="declaration.consignee.customCreditNumber" :options="dropDown" required></b-form-select>
            </b-form-group>

             <b-form-group label="Deffered payment(48)">
              <b-form-select v-model="declaration.consignee.defferedPayment" :options="dropDown" required></b-form-select>
            </b-form-group>          
      </b-form>
</template>

<script>
export default {
 props:{
   declaration: Object,
 }, 
data() {
    return {
      OrgNum:"",
      consigneeName:"",
      consigneeAddress1:"",
      consigneeAddress2:"",
      customsCreditNumber:"",
      defferedPayment:"",
      dropDown: [{ text: "<Please select>", value: null }, "1", "2", "3", "4"],
      show: true
    };
  },
  methods: {
    onSubmit(evt) {
      //   evt.preventDefault();
      //   alert(JSON.stringify(this.form));
      //some code here
    },
    onReset(evt) {
     //add some code here
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
