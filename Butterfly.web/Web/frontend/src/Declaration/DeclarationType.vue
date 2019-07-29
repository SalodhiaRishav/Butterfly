<template>
     <b-form style="padding:10px; background:#F2F2F2;" @submit="onSubmit" @reset="onReset" v-if="show">       
            <p class="block-heading"> Declaration type </p>
 
            <b-form-group label="*Message Name">
              <b-form-input v-model="declaration.declarationType.messageName" required ></b-form-input>
            </b-form-group>
            <b-form-group label="Declaration Type(1:1):" >
              <b-form-select v-model="declaration.declarationType.declarationType1" :options="dropDown" required>{{newDeclarationType1}}</b-form-select>
            </b-form-group>
            <b-form-group label="Declaration Type(1:2):">
              <b-form-select v-model="declaration.declarationType.declarationType2" :options="dropDown" required></b-form-select>
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
      messageName:"",
      declarationType1:"",
      declarationType2:"",
      dropDown: [{ text: "<Please select>", value: "" }, "1", "2", "3", "4"],
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
     //add some text
    },        
  }
}
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
