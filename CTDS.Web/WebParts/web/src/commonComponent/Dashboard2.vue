<template>
  <div>
    <div style="background-color:#eee;">
      <appNavigationbar></appNavigationbar>
     <div class="row tilesRow">
         <div class="col-sm-4 col-md-3 tileBox">
        <appTile tooltipTitle="Total Declarations" :counter=declarationCount title="Declaration"  :chartData="caseTileChartData"></appTile>
       </div>
       <div class="col-sm-4 col-md-3 tileBox">
        <appTileWithGaugeChart boxColor="green" tooltipTitle="Declaration Cleared in last seven days" :counter=declarationCleared title="Declaration Cleared"  :chartData="declarationInProcessChartData"></appTileWithGaugeChart>
       </div>
       <div class="col-sm-4 col-md-3 tileBox">
        <appTileWithGaugeChart boxColor="blue" tooltipTitle="Declaration InProcess in last seven days" :counter=declarationInProcess title="Declaration In Process"  :chartData="declarationInProcessChartData"></appTileWithGaugeChart>
       </div>
       <div class="col-sm-4 col-md-3 tileBox">
        <appTileWithGaugeChart boxColor="red" tooltipTitle="Declaration Rejected in last seven days" :counter=declarationRejected title="Declaration Rejected"  :chartData="declarationInProcessChartData"></appTileWithGaugeChart>
       </div>
      </div>
      <div class="row tilesRow">
         <div class="col-sm-4 col-md-3 tileBox">
        <appTile tooltipTitle="Total Declarations" :counter=declarationCount title="Declaration"  :chartData="caseTileChartData"></appTile>
       </div>
       <div class="col-sm-4 col-md-3 tileBox">
        <appTileWithGaugeChart boxColor="green" tooltipTitle="Declaration Cleared in last seven days" :counter=declarationCleared title="Declaration Cleared"  :chartData="declarationInProcessChartData"></appTileWithGaugeChart>
       </div>
       <div class="col-sm-4 col-md-3 tileBox">
        <appTileWithGaugeChart boxColor="blue" tooltipTitle="Declaration InProcess in last seven days" :counter=declarationInProcess title="Declaration In Process"  :chartData="declarationInProcessChartData"></appTileWithGaugeChart>
       </div>
       <div class="col-sm-4 col-md-3 tileBox">
        <appTileWithGaugeChart boxColor="red" tooltipTitle="Declaration Rejected in last seven days" :counter=declarationRejected title="Declaration Rejected"  :chartData="declarationInProcessChartData"></appTileWithGaugeChart>
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
import Tile from "./Tile";
import TileWithoutChart from "./TileWithoutChart";
import TileWithGaugeChart from "./TileWithGaugeChart";


export default {
  components: {
    appSideBar: SideBar,
    appNavigationbar: Navigationbar,
    appGroupedBarGraph: GroupedBarGraph,
    appNavigationbar: Navigationbar,
    appBarGraph: BarGraph,
    PieChart,
    appTile:Tile,
    appTileWithoutChart:TileWithoutChart,
    appTileWithGaugeChart:TileWithGaugeChart
  },
  data() {
    return {
      declarationInProcessChartData:{
           labels: ["Cleared", "Remaining", ],
            datasets: [{
                label: "My First dataset",
                backgroundColor: ["white","#66000000"],
                borderColor: '#fff',
                borderWidth:0.7,
                data: [5, 10],
            }]
      },
       caseTileChartData: {
         labels: ['M', 'Tu', 'W', 'Th', 'F', 'Sa', 'Su'],
        datasets: [{
            borderColor: "#ffffff",
            pointBorderColor: "#ffffff",
            pointBackgroundColor: "#ffffff",
            pointHoverBackgroundColor: "#66000000",
            pointHoverBorderColor: "#0000ff",
            pointBorderWidth: 1,
            pointHoverRadius: 7,
            pointHoverBorderWidth: 0.5,
            pointRadius: 4,
            fill: false,
            borderWidth: 1,
            data: [100, 120, 150, 170, 180, 170, 300]
        }]
    },
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
