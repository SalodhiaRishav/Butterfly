<template>
  <b-form class="pd-10 form-bg-color">
    <p class="block-heading">{{ language.lang.declarationType }}</p>
    <b-form-group>
      <label>{{ language.lang.messageName }}</label>
      <b-form-select
        v-model="declaration.messageName"
        :options="messageNameList"
        required
      ></b-form-select>
    </b-form-group>
    <b-form-group>
      <label>{{ language.lang.declarationType1 }}</label>
      <b-form-select
        v-model="declaration.declarationType1"
        :options="declarationType1List"
        required
        >{{ newDeclarationType1 }}</b-form-select
      >
    </b-form-group>
    <b-form-group>
      <label>{{ language.lang.declarationType2 }}</label>
      <b-form-select
        v-model="declaration.declarationType2"
        :options="declarationType2List"
        required
      ></b-form-select>
    </b-form-group>
  </b-form>
</template>

<script>
import httpClient from "./../utils/httpRequestWrapper";
import allLanguages from "./../utils/languageSwitch";

export default {
  props: {
    declaration: Object,
    language: Object
  },
  data() {
    return {
      messageNameList: [],
      declarationType2List: [],
      declarationType1List: [],
      lan: allLanguages.lang.en.englishForm
    };
  },
  // watch:{
  //   language: {
  //     handler(val){
  //       if(val.lang === "se"){
  //           this.lan = allLanguages.lang.se.swedishForm;
  //       }
  //       else{
  //         this.lan = allLanguages.lang.en.englishForm;
  //       }
  //       console.log(val.lang);
  //     },
  //     deep:true,
  //   },
  mounted() {
    this.getDeclarationType1();
    this.getDeclarationType2();
    this.getMessageNames();
  },
  methods: {
    getMessageNames() {
      const url = "/getdropdownitems/MessageName";
      httpClient
        .get(url)
        .then(response => {
          if (response.data === "token refreshed") {
            this.getMessageNames();
            return;
          }
          if (response.data) {
            this.messageNameList = response.data.data.map(x => {
              return { value: x.key, text: x.value };
            });
          }
        })
        .catch(error => console.log(error));
    },
    getDeclarationType2() {
      const url = "/getdropdownitems/DeclarationType2";
      httpClient
        .get(url)
        .then(response => {
          if (response.data === "token refreshed") {
            this.getDeclarationType2();
            return;
          }
          if (response.data) {
            this.declarationType2List = response.data.data.map(x => {
              return { value: x.key, text: x.value };
            });
          }
        })
        .catch(error => console.log(error));
    },
    getDeclarationType1() {
      const url = "/getdropdownitems/DeclarationType1";
      httpClient
        .get(url)
        .then(response => {
          if (response.data === "token refreshed") {
            this.getDeclarationType1();
            return;
          }
          if (response.data) {
            this.declarationType1List = response.data.data.map(x => {
              return { value: x.key, text: x.value };
            });
          }
        })
        .catch(error => console.log(error));
    }
  }
};
</script>

<style>
@import url("./style/declarationStyle.css");
</style>
