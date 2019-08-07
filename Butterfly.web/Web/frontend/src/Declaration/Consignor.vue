<template>
  <div>
    <b-form
      style="padding:10px; background:#F2F2F2;"
      @submit="onSubmit" @reset="onReset"
      v-if="show"
    >
     <p class="block-heading">Consignor/exporter</p>
      <b-form-group label="*Name:">
        <b-form-input v-model="declaration.consignorName" required></b-form-input>
      </b-form-group>
      <b-form-group label="*Address1:">
        <b-form-input v-model="declaration.consignorAddress1" required></b-form-input>
      </b-form-group>
      <b-form-group label="*Address2:">
        <b-form-input v-model="declaration.consignorAddress2" required></b-form-input>
      </b-form-group>
      <b-row>
        <b-col>
          *postal code
          <b-form-input v-model="declaration.consignorPostalCode"></b-form-input>
        </b-col>
        <b-col>
          *City
          <b-form-input v-model="declaration.consignorCity"></b-form-input>
        </b-col>
        <b-col>
          Country
          <b-form-select v-model="declaration.consignorCountry" :options="countryList" required></b-form-select>
        </b-col>
      </b-row>
    </b-form>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  props:{
    declaration: Object,
  },
  data() {
    return {
      consignorName:"",
      consignorAddress1:"",
      consignorAddress2:"",
      consignorPostalCode:"",
      consignorCity:"",
      consignorCountry:"",
      show: true,
      countryList:[],
    };
  },
  mounted(){
       axios.get('https://localhost:44313/getdropdownitems/Country')
            .then((response)=>{
              if(response.data){
                console.log(response.data.data)
                  this.countryList= response.data.data.map(x=>
                    {
                      return {text:x.value}
                  })
                }
            }
            )
            .catch((error)=>console.log(error))
  },
  methods:{
      onReset(){

      },
      onSubmit(){

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
