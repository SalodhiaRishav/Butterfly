<template>
  <div>
    <div style="background-color:#eee;">
      <appNavigationbar></appNavigationbar>
     <div class="row tilesRow" v-if="caseStatusDataFetched">
         <div class="col-sm-4 col-md-3 tileBox" v-if="caseLineChartDataFetched">
        <appTile boxColor="darkblue" tooltipTitle="Total Cases" chartTitle="Cases Last Week" :counter=totalCases title="Total Cases"  :chartData="caseTileChartData"></appTile>
       </div>
       <div class="col-sm-4 col-md-3 tileBox">
        <appTileWithGaugeChart boxColor="green" tooltipTitle="New Cases" :counter=newCases title="New Cases" chartTitle="New Cases / Total Cases" :chartData="caseNewChartData"></appTileWithGaugeChart>
       </div>
       <div class="col-sm-4 col-md-3 tileBox">
        <appTileWithGaugeChart boxColor="blue" tooltipTitle="Cases In Process" :counter=inProcessCases chartTitle="InProcess Cases / Total Cases" title="Cases In Process"  :chartData="caseInProcessChartData"></appTileWithGaugeChart>
       </div>
       <div class="col-sm-4 col-md-3 tileBox">
        <appTileWithGaugeChart boxColor="red" tooltipTitle="Closed Cases" :counter=closedCases chartTitle="Closed Cases / Total Cases" title="Closed Cases"  :chartData="caseClosedChartData"></appTileWithGaugeChart>
       </div>
      </div>
      <div class="row tilesRow" v-if="declarationStatusDataFetched">
         <div class="col-sm-4 col-md-3 tileBox" v-if="declarationLineChartDataFetched">
        <appTile boxColor="darkblue" tooltipTitle="Total Declarations" :counter=totalDeclaration chartTitle="Declarations Last Week" title="Total Declarations"  :chartData="declarationTileChartData"></appTile>
       </div>
       <div class="col-sm-4 col-md-3 tileBox">
        <appTileWithGaugeChart boxColor="green" tooltipTitle="Declarations Cleared" chartTitle="Declarations Cleared / Total Declarations" :counter=declarationCleared title="Declaration Cleared"  :chartData="declarationClearedChartData"></appTileWithGaugeChart>
       </div>
       <div class="col-sm-4 col-md-3 tileBox">
        <appTileWithGaugeChart boxColor="blue" tooltipTitle="Declarations InProcess" chartTitle="Declarations In Process / Total Declarations" :counter=declarationInProcess title="Declaration In Process"  :chartData="declarationInProcessChartData"></appTileWithGaugeChart>
       </div>
       <div class="col-sm-4 col-md-3 tileBox">
        <appTileWithGaugeChart boxColor="red" tooltipTitle="Declarations Rejected" chartTitle="Declarations Rejected / Total Declarations" :counter=declarationRejected title="Declaration Rejected"  :chartData="declarationRejectedChartData"></appTileWithGaugeChart>
       </div>
      </div>
        <!-- <div class="row" style="margin-top:10px; margin-right:15px">
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
        </div> -->
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

      declarationLineChartDataFetched:false,
      caseLineChartDataFetched:false,
      caseStatusDataFetched:false,
      newCases:"",
      closedCases:"",
      inProcessCases:"",
      totalCases:"",
      caseNewChartData:{},
      caseInProcessChartData:{},
      caseClosedChartData:{},
      caseTileChartData: {},
      declarationTileChartData: {},

      declarationStatusDataFetched:false,
      totalDeclaration:"",
      declarationCleared:"",
      declarationRejected:"",
      declarationInProcess:"",
      declarationClearedChartData:{},
      declarationRejectedChartData:{},
      declarationInProcessChartData:{},
      chartOptions: {},
      declarationChartDataFetched: false,
      declarationChartData: {},
      dataFetched: false,
      caseCount: 0,
      declarationCount: 0,
      
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
    this.getPerDayCaseCountLastWeek();
    this.getPerDayDeclarationCountLastWeek();
  },
  methods: {
    getPerDayDeclarationCountLastWeek() {
      const url = "/perdaydeclarationcount";
      httpClient
      .get(url)
      .then(response => {
        if(response.data.success === true) {
          const declarationCountList = response.data.data;
          var weekday = new Array(7);
          weekday[0] = "Su";
          weekday[1] = "Mo";
          weekday[2] = "Tu";
          weekday[3] = "We";
          weekday[4] = "Th";
          weekday[5] = "Fr";
          weekday[6] = "Sa";
          const d = new Date();
          var today = d.getDay();
          const myLabels = new Array();
          for(var i=1 ; i<=7;i++)
          {
            if(today < 6)
            {
              today = today + 1;
            }
            else
            {
              today = 0;
            }
            myLabels.push(weekday[today]);
          }
          const declarationTileChartData = {
          labels: myLabels,
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
            data: declarationCountList
            }]
          };
          this.declarationTileChartData = declarationTileChartData;
          this.declarationLineChartDataFetched=true;
        }
        else {
            console.log(response.data.message);
          }
        })
      .catch(error => {
          console.log(error);
      });
    },
    getPerDayCaseCountLastWeek() {
      const url = "/perdaycasecount";
      httpClient
      .get(url)
      .then(response => {
        if(response.data.success === true) {
          const caseCountList = response.data.data;
          var weekday = new Array(7);
          weekday[0] = "Su";
          weekday[1] = "Mo";
          weekday[2] = "Tu";
          weekday[3] = "We";
          weekday[4] = "Th";
          weekday[5] = "Fr";
          weekday[6] = "Sa";
          const d = new Date();
          var today = d.getDay();
          const myLabels = new Array();
          for(var i=1 ; i<=7;i++)
          {
            if(today < 6)
            {
              today = today + 1;
            }
            else
            {
              today = 0;
            }
            myLabels.push(weekday[today]);
          }
          const caseTileChartData = {
          labels: myLabels,
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
            data: caseCountList
            }]
          };
          this.caseTileChartData = caseTileChartData;
          this.caseLineChartDataFetched=true;
        }
        else {
            console.log(response.data.message);
          }
        })
      .catch(error => {
          console.log(error);
      });
    },
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
            const newHigh = response.data.data.newHigh;
            const newMed = response.data.data.newMed;
            const newLow = response.data.data.newLow;
            const newCases = newHigh+newMed+newLow;
            const caseInProcess=inProgressHigh+inProgressMed+inProgressLow;
            const closedCases=closedHigh+closedMedium+closedLow;
            const totalCases=caseInProcess+closedCases+newCases;

             const  caseInProcessChartData={
            labels: ["InProcess", "Others", ],
              datasets: [{
                  backgroundColor: ["white","#66000000"],
                  borderColor: '#fff',
                  borderWidth:0.7,
                  data: [caseInProcess,totalCases-caseInProcess ],
              }]
            };
            const  caseClosedChartData={
            labels: ["Closed", "Others", ],
              datasets: [{
                  backgroundColor: ["white","#66000000"],
                  borderColor: '#fff',
                  borderWidth:0.7,
                  data: [closedCases, totalCases-closedCases],
              }]
            };
            const  caseNewChartData={
            labels: ["New", "Others", ],
              datasets: [{
                  backgroundColor: ["white","#66000000"],
                  borderColor: '#fff',
                  borderWidth:0.7,
                  data: [newCases, totalCases-newCases],
              }]
            }
            this.caseNewChartData=caseNewChartData;
            this.caseClosedChartData=caseClosedChartData;
            this.caseInProcessChartData=caseInProcessChartData;
            this.closedCases=closedCases;
            this.newCases=newCases;
            this.inProcessCases=caseInProcess;
            this.totalCases=totalCases;
            this.caseStatusDataFetched=true;
            // const obj = {
            //   labels: ["In Process", "Closed"],
            //   dataLabels: ["High", "Medium", "Low"],
            //   dataLabelColors: ["Green", "Blue", "Red"],
            //   data: [
            //     [inProgressHigh, inProgressMed, inProgressLow],
            //     [closedHigh, closedMedium, closedLow]
            //   ]
            // };
            // this.groupedBarChartData = obj;
            // this.dataFetched = true;
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
            const declarationCleared = response.data.data.cleared;
             const declarationRejected = response.data.data.rejected;
             const declarationInProcess = response.data.data.processing;
             const totalDeclaration=declarationCleared+declarationRejected+declarationInProcess;
            const  declarationInProcessChartData={
            labels: ["InProcess", "Others", ],
              datasets: [{
                  backgroundColor: ["white","#66000000"],
                  borderColor: '#fff',
                  borderWidth:0.7,
                  data: [declarationInProcess,totalDeclaration-declarationInProcess ],
              }]
            };
             const  declarationClearedChartData={
            labels: ["Cleared", "Remaining", ],
              datasets: [{
                  backgroundColor: ["white","#66000000"],
                  borderColor: '#fff',
                  borderWidth:0.7,
                  data: [declarationCleared, totalDeclaration-declarationCleared],
              }]
            };
            const  declarationRejectedChartData={
            labels: ["Rejected", "Remaining", ],
              datasets: [{
                  backgroundColor: ["white","#66000000"],
                  borderColor: '#fff',
                  borderWidth:0.7,
                  data: [declarationRejected, totalDeclaration-declarationRejected],
              }]
            };
            this.declarationClearedChartData=declarationClearedChartData;
            this.declarationRejectedChartData=declarationRejectedChartData;
            this.declarationInProcessChartData=declarationInProcessChartData;
            this.declarationCleared=declarationCleared;
            this.declarationRejected=declarationRejected;
            this.declarationInProcess=declarationInProcess;
            this.totalDeclaration=totalDeclaration;
            this.declarationStatusDataFetched=true;
            // const options = {
            //   hoverBorderWidth: 20,
            //   borderWidth: 10,
            //   hoverBackgroundColor: "red",
            //   title: {
            //     display: true,
            //     text: "Declaration vs Status",
            //     fontSize: 24
            //   },
            //   responsive: true,
            //   maintainAspectRatio: false
            // };
            // this.declarationCleared = response.data.data.cleared;
            // this.declarationRejected = response.data.data.rejected;
            // this.declarationInProcess = response.data.data.processing;
            // this.chartOptions = options;
            // let pieChartData = [
            //   response.data.data.cleared,
            //   response.data.data.rejected,
            //   response.data.data.processing
            // ];
            // const declarationChartData = {
            //   hoverBackgroundColor: "red",
            //   hoverBorderWidth: 10,
            //   labels: ["Cleared", "Rejected", "Processing"],
            //   datasets: [
            //     {
            //       label: "Data One",
            //       backgroundColor: ["#41B883", "#E46651", "#00D8FF"],
            //       data: pieChartData
            //     }
            //   ]
            // };
            // this.declarationChartData = declarationChartData;
            // this.declarationChartDataFetched = true;
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
