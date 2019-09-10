<template>
  <div>
    <div style="background-color:#eee;">
      <appNavigationbar :onDash2="onDash2"></appNavigationbar>
      <div class="row">
        <div class="col-sm-3">
          <appSideBar></appSideBar>
        </div>
        <div class="col-sm-9" style="margin-top:30px;">
          <div class="row">
            <div
              v-b-tooltip.hover
              :title="caseTitle"
              class="col-sm-3 box"
              style="line-height:33px"
            >
              <span class="heading">{{ caseCount }}</span>
              <br />
              <div>
                <span class="counter">Cases</span>
              </div>
            </div>
            <div
              v-b-tooltip.hover
              :title="declarationTitle"
              class="col-sm-3 box box-blue margin-left-30"
            >
              <span class="heading">{{ declarationCount }}</span>
              <br />
              <div>
                <span class="count">Declaration</span>
              </div>
            </div>
          </div>
          <div class="row" style="margin-top:20px;">
            <div class="col-sm-9 box box-white">
              <appBarGraph
                style="color:black"
                chartTitle="Declarations vs Status"
                xAxisHeading="Status"
                yAxisHeading="No Of Declarations"
                :chartData="chartData"
              ></appBarGraph>
            </div>
            <!-- <div class="col-sm-5 box box-white margin-left-22">
              <h1 style="color:black">Graph 2</h1>
            </div> -->
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
import BarGraph from "./BarGraph";

export default {
  components: {
    appSideBar: SideBar,
    appNavigationbar: Navigationbar,
    appBarGraph: BarGraph
  },
  data() {
    return {
      caseCount: 0,
      declarationCount: 0,
      declarationTitle: "",
      caseCount: 0,
      onDash2: true,
      chartData: [
        {
          label: "Processing",
          value: 0,
          barColor: "blue"
        },
        {
          label: "Cleared",
          value: 0,
          barColor: "green"
        },
        {
          label: "Rejected",
          value: 0,
          barColor: "red"
        }
      ]
    };
  },
  created() {
    this.getDeclarationCount();
    this.getCasesInLastSevenDays();
    this.getDeclarationsInLastSevenDays();
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
    getCasesInLastSevenDays() {
      const url = "/casesinsevendays";
      httpClient
        .get(url)
        .then(response => {
          if (response.data.success === true) {
            this.caseTitle = `${response.data.data} Cases Created in Last Seven Days`;
          } else {
            console.log(response.data.message);
          }
        })
        .catch(error => console.log(error));
    },
    getDeclarationsInLastSevenDays() {
      const url = "/declarationsinsevendays";
      httpClient
        .get(url)
        .then(response => {
          if (response.data.success === true) {
            this.declarationTitle = `${response.data.data} Declarations Created in Last seven days `;
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
            // console.log(this.chartData);
            this.chartData[0].value = response.data.data.processing;
            this.chartData[1].value = response.data.data.cleared;
            this.chartData[2].value = response.data.data.rejected;
            console.log(this.chartData);
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
