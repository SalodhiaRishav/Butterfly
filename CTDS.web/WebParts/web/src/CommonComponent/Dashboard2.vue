<template>
  <div>
    <div style="background-color:#eee; height:100vh">
      <appNavigationbar :onDash2="onDash2"></appNavigationbar>
      <div class="row">
        <div class="col-sm-3">
          <appSideBar></appSideBar>
        </div>
        <div class="col-sm-9" style="margin-top:30px;">
          <div class="row">
            <div
              v-b-tooltip.hover
              title="cases in last 7 days 2"
              class="col-sm-3 box box-green"
            >
              <span
                class="heading"
              >{{caseCount}}</span>
              <br />
              <div>
                <span
                  class="counter"
                >Cases</span>
              </div>
            </div>
            <div
              v-b-tooltip.hover
              :title="declarationTitle"
              class="col-sm-3 box box-blue margin-left-30"
            >
              <span
                class="heading"
              >{{declarationCount}}</span>
              <br />
              <div>
                <span
                  class="count"
                >Declaration</span>
              </div>
            </div>
          </div>
          <div class="row" style="margin-top:20px;">
            <div class="col-sm-5 box box-white">
              <h1 style="color:black">Graph 1</h1>
            </div>
            <div class="col-sm-5 box box-white margin-left-22">
              <h1 style="color:black">Graph 2</h1>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import SideBar from "./SideBar";
import Navigationbar from "./Navigationbar";
import httpClient from "./../utils/httpRequestWrapper";

export default {
  components: {
    appSideBar: SideBar,
    appNavigationbar: Navigationbar
  },
  data() {
    return {
      declarationCount: 0,
      declarationTitle: "",
      caseCount: 0,
      onDash2:true,
    };
  },
  created() {
    this.getDeclarationCount();
    this.getDeclarationsinLastSevenDays();
    this.getStatusCount();
    this.getCaseCount();
  },
  methods: {
    getDeclarationCount() {
      const url = "/declarationcount";
      httpClient
        .get(url)
        .then(response => {
          if (response.data.success === true) {
            this.declarationCount = response.data.data;
          } else {
            console.log(response.data.message);
          }
        })
        .catch(error => {
          console.log(error);
        });
    },
    getDeclarationsinLastSevenDays() {
      const url = "/declarationsinsevendays";
      httpClient
        .get(url)
        .then(response => {
          if (response.data.success === true) {
            this.declarationTitle = `Declarations Created in Last seven days ${response.data.data}`;
          } else {
            console.log(response.data.message);
          }
        })
        .catch(error => console.log(error));
    },
    getStatusCount() {
      const url = "/getdeclarationstatuscount";
      httpClient
        .get(url)
        .then(response => {
          if (response.data.success === true) {
            console.log(response.data.data);
          } else {
            console.log(response.data.message);
          }
        })
        .catch(error => console.log(error));
    },
    getCaseCount() {
      const url = "/casecount";
      httpClient
        .get(url)
        .then(response => {
          if (response.data.success === true) {
            this.caseCount = response.data.data;
          } else {
            console.log(response.data.message);
          }
        })
        .catch(error => console.log(error));
    }
  }
};
</script>
<style scoped>
@import url("https://fonts.googleapis.com/css?family=Source+Sans+Pro:200,400,900&display=swap");
@import url("./styles/dashboard2.css");
</style>