<template>
     <b-form style="padding:10px; background:#F2F2F2;" @submit="onSubmit" @reset="onReset" v-if="show">
        
              <p class="block-heading">Declarant</p>
 
            <b-form-group label="*Org. number">
              <b-form-input v-model="declaration.declarant.orgNumber" required></b-form-input>
            </b-form-group>
           
          <b-form-group label="Name">
               <b-form-input v-model="declaration.declarant.name" required></b-form-input>
            </b-form-group>

            <b-form-group label="Address 1:">
              <b-form-input v-model="declaration.declarant.address1" required></b-form-input>
            </b-form-group>
            <b-form-group label="Address 2:">
              <b-form-input v-model="declaration.declarant.address2" :options="foods" required></b-form-input>
            </b-form-group>
             <b-row>
            <b-col> 
              *postal code
             <b-form-input v-model="declaration.declarant.postalCode" 
                 ></b-form-input>
                 </b-col>
                 <b-col>
              *City
              <b-form-input v-model="declaration.declarant.city"></b-form-input>
                 </b-col>
                 <b-col>
               Country    
              <b-form-select v-model="declaration.declarant.country" :options="dropDown" required></b-form-select>
               </b-col>  
            </b-row>
             <b-form-group label="*Contact person:">
              <b-form-input v-model="declaration.declarant.contactPerson" required></b-form-input>
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
      orgNumber:"",
      declarantName:"",
      declarantAddress1:"",
      declarantAddress2:"",
      declarantPostalCode:"",
      declarantCity:"",
      declarantCountry:"",
      declarantContactPerson:"",
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
      evt.preventDefault();
      // Reset our form values
      this.form.email = "";
      this.form.name = "";
      this.form.food = null;
      this.form.checked = [];
      // Trick to reset/clear native browser form validation state
      this.show = false;
      this.$nextTick(() => {
        this.show = true;
      });
    }
  }
}
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
