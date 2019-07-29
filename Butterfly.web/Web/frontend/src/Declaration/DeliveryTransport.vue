<template>
     <b-form style="padding:10px; background:#F2F2F2 ;" @submit="onSubmit" @reset="onReset" v-if="show">
            <div>
              <p class="block-heading">Delivery and transport</p>
          </div>  
          <b-row>
            <b-col>
              *Terms of delivery
               <b-form-select v-model="declaration.deliverySupport.termsOfDelivery" :options="dropDown" required></b-form-select>
            </b-col>
            <b-col>
              *Delivery place(20:2)
               <b-form-input v-model="declaration.deliverySupport.deliveryPlace" required ></b-form-input>
            </b-col>
          </b-row>
            <b-form-group label="*Country of dispatch/export">
              <b-form-select  v-model="declaration.deliverySupport.countryOfDispatch" :options="dropDown" required></b-form-select>
            </b-form-group>
            <b-form-group label="*Nationality of transport at border(21):">
               <b-form-select v-model="declaration.deliverySupport.nationalityOfTransport1" :options="dropDown" required></b-form-select>
            </b-form-group>
            <b-form-group label="*Mode of transport at the border(25):">
              <b-form-select v-model="declaration.deliverySupport.modeOfTransPort" :options="dropDown" required></b-form-select>
            </b-form-group>
            <b-form-group label="*Location of goods(30):">
              <b-form-select v-model="declaration.deliverySupport.locationOfGoods" :options="dropDown" required></b-form-select>
            </b-form-group>
             <b-form-group label="*Supervising customs office:" >
              <b-form-select v-model="declaration.deliverySupport.supervisingCustomOffice" :options="dropDown" required></b-form-select>
            </b-form-group>
          </b-form>
</template>

<script>
export default {
 props:{
   declaration:Object,
 }, 
data() {
    return {
      termsOfDelivery:"",
      deliveryPlace:"",
      countryOfDispatch:"",
      nationalityOfTransport:"",
      locationOfGoods:"",
      supervisingCustomsOffice:"",
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
