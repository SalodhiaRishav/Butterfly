<template>
    <b-card style="background-color:#666; border-radius:0px" text-variant="white">
    <b-card-text>
      <b-row>
    <b-col class="border-rt">
          <p>NO Import</p>
           <b-button v-b-modal.error-modal v-show="isError">Issues</b-button>
            <b-modal id="error-modal">
               <li v-for="(error,index) in errorList" :key="index">
                    {{ error }}
               </li>
            </b-modal>
           <b-alert
            :variant="alertVariant"
            :show="dismissCountDown"
            @dismissed="dismissCountDown = 0"
            @dismiss-count-down="countDownChanged"
            dismissible>
            {{alertMessage}}
            </b-alert> 

      </b-col>
      <b-col class="border-rt" >
          Declaration ID: <br>
          <p> CD - {{declaration.declarationId.toString().substring(0,5)}} </p>
           LRN <br>
          <p> -- </p>
          MRN<br>
          <p> -- </p>
      </b-col>
      <b-col class="border-rt">
          Total # of packages<br>
          <p> --</p>
          Total # of items <br>
          <p> -- </p>
          Total Gross Mass<br>
          <p> -- </p>  
      </b-col>
      <b-col>
        <b-button style="float:right; margin-right:17px" pill @click="onSave()">Edit</b-button>
          Declaration status <br>
          <p> -- </p>
          Customs response <br>
          <p> -- </p>
          Taxation data<br>
          <p> -- </p>
      </b-col>
      </b-row>
        
  </b-card-text>
  
</b-card> 
</template>
<script>
//import declarationform from './DeclarationForm';
import axios from 'axios'

export default {  
  props:{
    declaration:Object,
    referenceData: Object
  },
data() {
    return {
      postBody:null,
       dismissCountDown: 0,
      showDismissibleAlert: false,
       alertVariant: "",
      alertMessage: "",
      isError:false,
      errorList:[],
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
    },
    onSave(){
      //add some code here
    console.log(this.declaration);
    // this.postBody = Object.assign({},declaration : {
    //   declaration : this.declaration
    // })
      axios.post('https://localhost:44313/editdeclaration',
      {
        declaration:this.declaration, 
        referenceData:this.referenceData.reference
      })
      .then((response)=>{
            console.log("Success");
            if(response.data.success == true){
                 this.isError = false;
          console.log("Success");
          this.alertVariant = "success";
          this.alertMessage = "declaration saved!";
          this.dismissCountDown = 2;
            }
            else{
              console.log("error :",response.data.error);
              this.errorList = response.data.error;
              this.isError = true;      
            }
            console.log(response.data.data);
      })     
    }
  }
}
</script>

<style>
.block-heading {
  margin: -10px -10px 0px -10px;
  color: white;
  background: #aaa69d;
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