<template>
  <div>
    <div style="background-color:#eee;">
      <appNavigationbar :onDash2="onDash2"></appNavigationbar>
     <div class="row" style="margin-top:10px; margin-right:15px">
          <div
            v-b-tooltip.hover
            :title="caseTitle"
            class="col-sm-4 col-md-2 box box-blue margin-left-39"
            style="line-height:33px"
          >
            <span class="heading">{{caseCount}}</span>
            <br />
            <div>
              <span class="counter">Cases</span>
            </div>
          </div>
      </div>
      <div class="row" style="margin-top:10px; margin-right:15px">
          <div
            v-b-tooltip.hover
            :title="declarationTitle"
            class="col-sm-4 col-md-2 box box-blue margin-left-39"
          >
            <span class="heading">{{declarationCount}}</span>
            <br />
            <div>
              <span class="counter">Declaration</span>
            </div>
          </div>
          <div
            v-b-tooltip.hover
            :title="declarationTitle"
            class="col-sm-4 col-md-2 box box-blue margin-left-39"
          >
            <span class="heading">{{declarationInProcess}}</span>
            <br />
            <div>
              <span class="counter">Declaration in Process</span>
            </div>
          </div>
           <div
            v-b-tooltip.hover
            :title="declarationTitle"
            class="col-sm-4 col-md-2 box box-blue margin-left-39"
          >
            <span class="heading">{{declarationCleared}}</span>
            <br />
            <div>
              <span class="counter">Declaration Cleared</span>
            </div>
          </div>
          <div
            v-b-tooltip.hover
            :title="declarationTitle"
            class="col-sm-4 col-md-2 box box-blue margin-left-39"
          >
            <span class="heading">{{declarationRejected}}</span>
            <br />
            <div>
              <span class="counter">Declaration Rejected</span>
            </div>
          </div>
      </div>
        <div class="row" style="margin-top:10px; margin-right:15px">
          <div class="col-md-5 box box-white margin-left-39 box-height-572">
            <appGroupedBarGraph
              chartTitle="Case Progress Chart"
              xAxisHeading="Priority & Status"
              yAxisHeading="No. of cases"
              :chartData="groupedBarChartData"
              v-if="dataFetched"
            ></appGroupedBarGraph>
          </div>
          <div
            class="col-md-5 box box-white margin-left-39 box-height-572"
            v-if="declarationChartDataFetched"
          >
            <pie-chart :data="declarationChartData" :options="chartOptions"></pie-chart>
          </div>
        </div>
      </div>
    </div>
</template>
<script>
import SideBar from "./SideBar";
import Navigationbar from "./Navigationbar";
import httpClient from "./../utils/httpRequestWrapper";
import GroupedBarGraph from "./GroupedBarGraph";
import BarGraph from "./BarGraph";
import PieChart from "./PieChart.js";

export default {
  components: {
    appSideBar: SideBar,
    appNavigationbar: Navigationbar,
    appGroupedBarGraph: GroupedBarGraph,
    appNavigationbar: Navigationbar,
    appBarGraph: BarGraph,
    PieChart
  },
  data() {
    return {
      chartOptions: {},
      declarationChartDataFetched: false,
      declarationChartData: {},
      dataFetched: false,
      caseCount: 0,
      declarationCount: 0,
      declarationTitle: "",
      declarationCleared:"",
      declarationRejected:"",
      declarationInProcess:"",
      caseCount: 0,
      caseTitle: "",
      onDash2: true,
      val: "",
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
    this.getFilteredCaseCount();
    this.getDeclarationCount();
    this.getCasesInLastSevenDays();
    this.getDeclarationsInLastSevenDays();
    this.getStatusCount();
    this.getCaseCount();
  },
  methods: {
    getFilteredCaseCount() {
      const url = "/filtercasecount";
      httpClient
        .get(url)
        .then(response => {
          console.log("hola");
          console.log(response);
          console.log("hola");
          if (response.data.success === true) {
            const inProgressHigh = response.data.data.inProcessHigh;
            const inProgressMed = response.data.data.inProcessMed;
            const inProgressLow = response.data.data.inProcessLow;
            const closedHigh = response.data.data.closeHigh;
            const closedMedium = response.data.data.closeMed;
            const closedLow = response.data.data.closeLow;

            const obj = {
              labels: ["In Process", "Closed"],
              dataLabels: ["High", "Medium", "Low"],
              dataLabelColors: ["Green", "Blue", "Red"],
              data: [
                [inProgressHigh, inProgressMed, inProgressLow],
                [closedHigh, closedMedium, closedLow]
              ]
            };
            this.groupedBarChartData = obj;
            this.dataFetched = true;
          } else {
            console.log(response.data.message);
          }
        })
        .catch(error => {
          console.log(error);
        });
    },
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
            const options = {
              hoverBorderWidth: 20,
              borderWidth: 10,
              hoverBackgroundColor: "red",
              title: {
                display: true,
                text: "Declaration vs Status",
                fontSize: 24
              },
              responsive: true,
              maintainAspectRatio: false
            };
            this.declarationCleared = response.data.data.cleared;
            this.declarationRejected = response.data.data.rejected;
            this.declarationInProcess = response.data.data.processing;
            this.chartOptions = options;
            let pieChartData = [
              response.data.data.cleared,
              response.data.data.rejected,
              response.data.data.processing
            ];
            // console.log(pieChartData);
            const declarationChartData = {
              hoverBackgroundColor: "red",
              hoverBorderWidth: 10,
              labels: ["Cleared", "Rejected", "Processing"],
              datasets: [
                {
                  label: "Data One",
                  backgroundColor: ["#41B883", "#E46651", "#00D8FF"],
                  data: pieChartData
                }
              ]
            };
            this.declarationChartData = declarationChartData;
            this.declarationChartDataFetched = true;
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
