<template>
  <b-form
    style="padding:10px; background:#F2F2F2;"
    @submit="onSubmit"
    @reset="onReset"
    v-if="show"
  >
    <p class="block-heading">Declaration type</p>
    <b-form-group label="*Message Name">
      <b-form-select v-model="declaration.messageName" :options="messageNameList" required></b-form-select>
    </b-form-group>
    <b-form-group label="Declaration Type(1:1):">
      <b-form-select
        v-model="declaration.declarationType1"
        :options="declarationType1List"
        required
        >{{ newDeclarationType1 }}</b-form-select
      >
    </b-form-group>
    <b-form-group label="Declaration Type(1:2):">
      <b-form-select
        v-model="declaration.declarationType2"
        :options="declarationType2List"
        required
      ></b-form-select>
    </b-form-group>
  </b-form>
</template>

<script>
import axios from "axios";
export default {
  props: {
    declaration: Object
  },

  data() {
    return {
      messageName: "",
      declarationType1: "",
      declarationType2: "",
      dropDown: [{ text: "<Please Select>", value: "" }, "1", "2", "3", "4"],
      show: true,
      declarationType1List: [],
      declarationType2List: [],
      messageNameList: [],        
    };
  },
  
  mounted(){
      axios.get('https://localhost:44313/getdropdownitems/DeclarationType1')
            .then((response)=>{
              if(response.data){
                console.log(response.data.data)
                  this.declarationType1List= response.data.data.map(x=>{
                    return {value: x.key, text:x.value}
                  })
                }
            }
            )
            .catch((error)=>console.log(error))
        axios.get('https://localhost:44313/getdropdownitems/DeclarationType2')
            .then((response)=>{
              if(response.data){
                console.log(response.data.data)
                  this.declarationType2List= response.data.data.map(x=>{
                    return {value: x.key, text:x.value}
                  })
                }
            }
            )
            .catch((error)=>console.log(error))
            axios.get('https://localhost:44313/getdropdownitems/MessageName')
            .then((response)=>{
              if(response.data){
                console.log(response.data.data)
                  this.messageNameList= response.data.data.map(x=>{
                    return {value: x.key, text: x.value}
                  })
                }
            }
            )
            .catch((error)=>console.log(error))
  },
  methods: {
    onSubmit() {},
    onReset() {}
  }
};
</script>

<style>
.block-heading {
  margin: -10px -10px 0px -10px;
  color: white;
  background: #666;
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
