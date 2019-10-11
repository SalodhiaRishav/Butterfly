<template>
  <div>
    <div class="background-gray">
     <div class="row tilesRow" v-if="caseStatusDataFetched">
         <div class="col-sm-4 col-md-3 tileBox" v-if="caseLineChartDataFetched">
            <appTileWithGaugeChart @tileClicked="onTileClick(null)()" class="colorGreen" tooltipTitle="Total Cases" :counter=totalCases title="Total Cases" chartTitle="Total Cases" :chartData="caseTotalChartData"></appTileWithGaugeChart>
       </div>
       <div class="col-sm-4 col-md-3 tileBox">
        <appTileWithGaugeChart @tileClicked="onTileClick('New')" class="colorBrown" tooltipTitle="New Cases" :counter=newCases title="New Cases" chartTitle="New Cases / Total Cases" :chartData="caseNewChartData"></appTileWithGaugeChart>
       </div>
       <div class="col-sm-4 col-md-3 tileBox">
        <appTileWithGaugeChart @tileClicked="onTileClick('InProcess')" class="colorCyan"  tooltipTitle="Cases In Process" :counter=inProcessCases chartTitle="InProcess Cases / Total Cases" title="Cases In Process"  :chartData="caseInProcessChartData"></appTileWithGaugeChart>
       </div>
       <div class="col-sm-4 col-md-3 tileBox">
        <appTileWithGaugeChart @tileClicked="onTileClick('Closed')" class="colorCrimson" tooltipTitle="Closed Cases" :counter=closedCases chartTitle="Closed Cases / Total Cases" title="Closed Cases"  :chartData="caseClosedChartData"></appTileWithGaugeChart>
       </div>
      </div>
      <div class="row tilesRow">
        <div class="col-md-12 tileBox shadowBox">
           <!-- <div class="col-md-4 toggler shadowBox">
            <toggle-switch :options="myOptions">
            </toggle-switch>
           </div> -->
           
           <table style="float:right; backgroundColor:white;">
            <tr >
              <th><appDateRangePicker class="dateRangePicker" v-model="range" @input="getCasesByStatus(false)"></appDateRangePicker>
            </th >
              <th><font-awesome-icon icon="calendar"/></th>
              </tr>
          </table>
             <button @click="shouldShowChart=true">ShowChart</button>
              <button @click="shouldShowChart=false">ShowTable</button>
           
            <!-- <div class="col-md-12 table" v-if="chartswitch">
              <appTile boxColor="darkblue" tooltipTitle="Total Cases" chartTitle="Cases Last Week" :counter=totalCases title="Total Cases"  :chartData="caseTileChartData"></appTile>
            </div> -->
            <div v-if="!shouldShowChart">
              <div >
                <b-table class="font-size-80"
                  striped
                  hover
                  fixed
                  :fields="caseTableFields"
                  :items="filterCases"
                  :current-page="currentPage"
                  :per-page="perPage"
                  @row-clicked="editCase"
                >
                </b-table>
              </div>
              <b-row>
                <b-col md="6" class="my-1 font-size-80">
                  <b-pagination
                    v-model="currentPage"
                    :total-rows="totalRows"
                    :per-page="perPage"
                    class="my-0">
                  </b-pagination>
                </b-col>
              </b-row>
          </div>
           <div class="dashboardChartDiv" v-if="shouldShowChart">
            <appCaseDashboardLineChart :status="fixedCaseStatus" :startDate="range[0]" :endDate="range[1]"></appCaseDashboardLineChart>
          </div>
        </div>
       </div>
      </div>
     

     
    </div>
     <!-- <div class="col-md-6 chartBox">
          <appToggler></appToggler>
          <div class="shadowBox box-white" v-if="declarationPieChartDataFetched">
              <appBarChart :width="100" :height="400" :data="caseGroupedBarChartData" :options="caseGroupedBarChartOptions"></appBarChart>
          </div>
        </div>
        <div class="col-md-6 chartBox">
            <appToggler></appToggler> 
          <div class="shadowBox box-white" v-if="declarationPieChartDataFetched">
             <pie-chart :width="100" :height="400" :data="declarationPieChartData" :options="declarationPieChartOptions"></pie-chart>
          </div> -->
</template>

<script>
import httpClient from "./../utils/httpRequestWrapper";
import GroupedBarGraph from "./GroupedBarGraph";
import BarGraph from "./BarGraph";
import PieChart from "./PieChart.js";
import BarChart from "./BarChart.js";
import Tile from "./Tile";
import TileWithoutChart from "./TileWithoutChart";
import TileWithGaugeChart from "./TileWithGaugeChart";
import ChartView from "./ChartView";
import Toggler from "./Toggler";
import MyDateRangePicker from "./MyDateRangePicker";
import CaseTableFields from "./../caseManagement/utils/caseTableFields";
import CaseDashboardLineChart from  "./CaseDashboardLineChart";



export default {
  components: {
    appCaseDashboardLineChart:CaseDashboardLineChart,
    appDateRangePicker:MyDateRangePicker,
    appGroupedBarGraph: GroupedBarGraph,
    appBarGraph: BarGraph,
    PieChart,
    appBarChart:BarChart,
    appTile:Tile,
    appTileWithoutChart:TileWithoutChart,
    appTileWithGaugeChart:TileWithGaugeChart,
    appChartView:ChartView,
    appToggler:Toggler
  },
  data() {
    return {
      filterCases: [],
      currentPage: 1,
      perPage: 5,
      totalRows: 0,
      caseTableFields:CaseTableFields,
      range: [this.$moment().subtract(29, 'days'), this.$moment()],
      myOptions: {
        layout: {
          color: 'black',
          backgroundColor: 'lightgray',
          selectedColor: 'white',
          selectedBackgroundColor: 'green',
          borderColor: 'black',
          fontFamily: 'Arial',
          fontWeight: 'normal',
          fontWeightSelected: 'bold',
          squareCorners: false,
          noBorder: false
        },
        items: {
          delay: .4,
          preSelected: 'Chart',
          disabled: false,
          labels: [
            {name: 'Chart', color: 'white', backgroundColor: 'red'}, 
            {name: 'Table', color: 'white', backgroundColor: 'green'}
          ]
        }
      },
      
      chartswitch : false,
      shouldShowChart:false,
      caseLineChartDataFetched:false,
      caseStatusDataFetched:false,
      newCases:"",
      closedCases:"",
      inProcessCases:"",
      totalCases:"",
      caseTotalChartData:{},
      caseNewChartData:{},
      caseInProcessChartData:{},
      caseClosedChartData:{},
      caseTileChartData: {},
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
      dataFetched: false,
      caseCount: 0,
      caseTitle: "",
      val: "",
      fixedCaseStatus : null
    };
  },
  created() {
    this.getFilteredCaseCount();
    this.getCasesInLastSevenDays();
    this.getCaseCount();
    this.getPerDayCaseCountLastWeek();
    this.getCasesByStatus();
  },
  methods: {
    showChart(){
      this.shouldShowChart=true;
    },
    randomColor() {
      var letters = '0123456789ABCDEF';
      var color = '#';
      for (var i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
      }
      const styleObject={background:color};
      return styleObject;
    },
     editCase: function(row) {
      const urlResource=`/casemanagement/${row.Id}`;
      httpClient.get(urlResource)
      .then((response)=>{
        if (response.data.success === true) {
          this.$store.dispatch("setCase", response.data.data);
          const url = `/case/${row.Id}`;
          this.$router.push(url);
        }
        else
        {
          console.log(response.data.data);
        }
      })
      .catch((error)=>{
        console.log(error);
      })
    },
    onTileClick(status){
      this.fixedCaseStatus=status;
      if(this.shouldShowChart === false)
      {
        this.getCasesByStatus();
      }
      else
      {
        this.shouldShowChart=false;
        this.shouldShowChart=true;
      }
    },
     getCasesWithAnyStatus(){
      this.fixedCaseStatus=null;
      this.getCasesByStatus();
    },
    getCasesByNew() {
      this.fixedCaseStatus="New";
      this.getCasesByStatus();
    },
    getCasesByProcess() {
      this.fixedCaseStatus="InProcess";
      this.getCasesByStatus();
    },
    getCasesByClosed() {
      this.fixedCaseStatus="Closed";      
      this.getCasesByStatus();
    },
    getCasesByStatus(start = true){
      const status=this.fixedCaseStatus;
      this.filterCases = null;
      const url = "/casebystatus";
      let postObject = null;
      if(start === true)
      {
         postObject={ CaseStatus : status,
                   StartDate : this.range[0],
                   EndDate : this.range[1]
                   };
      }
      else{
        postObject={ CaseStatus : status,
                   StartDate : this.range[0],
                   EndDate : this.range[1]
                   };
      }
      httpClient
      .post(url, postObject)
      .then(res => {
         if (res.data === "token refreshed") {
            this.getCasesByStatus();
            return;
          }
         if (res.data.success === true) {
            let filterCase = [];
            const allCases = res.data.data;
             for (let i = 0; i < allCases.length; ++i){
              let obj = {
                  CaseId: "KGH-19-" + allCases[i].caseId,
                   Id: allCases[i].id,
                  CreatedDate: this.convertDate(allCases[i].createdOn),
                  Status: allCases[i].status,
                  Description: allCases[i].description,
                  Client: allCases[i].client,
                  Notes: allCases[i].notes,
                  Priority: allCases[i].priority,
                  References: null
                };
                filterCase.push(obj);
             }
             this.filterCases = filterCase;
              if (this.filterCases.length != 0)
              this.totalRows = this.currentPage * this.perPage + 1;
          }
         })
      .catch(error => {
          console.log(error);
        });
    },
    convertDate(someDate) {
      return new Date(someDate.match(/\d+/)[0] * 1).toString().substring(0, 16);
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
            };
            const caseTotalChartData={
               labels: ["Total"],
              datasets: [{
                  backgroundColor: ["white","#66000000"],
                  borderColor: '#fff',
                  borderWidth:0.7,
                  data: [totalCases],
              }]
            };
            this.caseTotalChartData=caseTotalChartData;
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
@import url("./styles/tileDash2Style.css");
</style>
