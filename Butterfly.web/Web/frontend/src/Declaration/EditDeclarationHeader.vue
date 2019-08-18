<template>
  <b-card style="background-color:#666; border-radius:0px" text-variant="white">
    <b-card-text>
      <b-row>
        <b-col class="border-rt">
          NO Import
        </b-col>
        <b-col class="border-rt">
          Declaration ID: <br />
          <p>CD - {{ declaration.declarationId.toString().substring(0, 5) }}</p>
          LRN <br />
          <p>--</p>
          MRN<br />
          <p>--</p>
        </b-col>
        <b-col class="border-rt">
          Total # of packages<br />
          <p>--</p>
          Total # of items <br />
          <p>--</p>
          Total Gross Mass<br />
          <p>--</p>
        </b-col>
        <b-col>
          <b-button
            style="float:right; margin-right:17px"
            pill
            @click="onSave()"
            >Edit</b-button
          >
          Declaration status <br />
          <p>--</p>
          Customs response <br />
          <p>--</p>
          Taxation data<br />
          <p>--</p>
        </b-col>
      </b-row>
    </b-card-text>
  </b-card>
</template>
<script>
//import declarationform from './DeclarationForm';
import axios from "axios";

export default {
  props: {
    declaration: Object
  },
  data() {
    return {
      postBody: null
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
    onSave() {
      //add some code here
      console.log(this.declaration);
      // this.postBody = Object.assign({},declaration : {
      //   declaration : this.declaration
      // })
      axios
        .post("https://localhost:44313/editdeclaration", {
          declaration: this.declaration
        })
        .then(response => {
          console.log("Success");
          console.log(response.data.data);
        });
    }
  }
};
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
