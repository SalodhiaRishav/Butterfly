<template>


  <div>
    <div style="background-color:#eee;">
      <div class="row tilesRow" v-if="declarationStatusDataFetched">
       <div class="col-sm-4 col-md-3 tileBox" v-if="declarationLineChartDataFetched">
        <!-- <appTile @tileClicked="getDeclarationsWithAnyStatus()" class="colorGreen" tooltipTitle="Total Declarations" :counter=totalDeclaration chartTitle="Declarations Last Week" title="Total Declarations"  :chartData="declarationTileChartData"></appTile> -->
        <appTileWithGaugeChart @tileClicked="getDeclarationsWithAnyStatus()" class="colorGreen" tooltipTitle="Total Declarations" chartTitle="Total Declarations" :counter=totalDeclaration title="Total Declarations"  :chartData="declarationTotalChartData"></appTileWithGaugeChart>
       </div>
       <div class="col-sm-4 col-md-3 tileBox">
        <appTileWithGaugeChart @tileClicked="getClearedDeclarations()" class="colorBrown" tooltipTitle="Declarations Cleared" chartTitle="Declarations Cleared / Total Declarations" :counter=declarationCleared title="Declaration Cleared"  :chartData="declarationClearedChartData"></appTileWithGaugeChart>
       </div>
       <div class="col-sm-4 col-md-3 tileBox">
        <appTileWithGaugeChart @tileClicked="getProcessingDeclarations()" class="colorCyan" tooltipTitle="Declarations Processing" chartTitle="Declarations Processing / Total Declarations" :counter=declarationInProcess title="Declaration In Process"  :chartData="declarationInProcessChartData"></appTileWithGaugeChart>
       </div>
       <div class="col-sm-4 col-md-3 tileBox">
        <appTileWithGaugeChart @tileClicked="getRejectedDeclarations()" class="colorCrimson" tooltipTitle="Declarations Rejected" chartTitle="Declarations Rejected / Total Declarations" :counter=declarationRejected title="Declaration Rejected"  :chartData="declarationRejectedChartData"></appTileWithGaugeChart>
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
           
            <!-- <div class="col-md-12 table" v-if="chartswitch">
              <appTile boxColor="darkblue" tooltipTitle="Total Cases" chartTitle="Cases Last Week" :counter=totalCases title="Total Cases"  :chartData="caseTileChartData"></appTile>
            </div> -->
            <div>
              <div>
                <b-table class="font-size-80"
                  striped
                  hover
                  fixed
                  :fields="fields"
                  :items="filterDeclarations"
                  :current-page="currentPage"
                  :per-page="perPage"
                >
                </b-table>
              </div>
              <b-row>
                <b-col md="6" class="my-1 font-size-80" >
                  <b-pagination
                    v-model="currentPage"
                    :total-rows="totalRows"
                    :per-page="perPage"
                    class="my-0">
                  </b-pagination>
                </b-col>
              </b-row>
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



export default {
  components: {
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
      filterDeclarations: [],
      currentPage: 1,
      perPage: 5,
      totalRows: 0,
      fields: [
        {
          key: "DeclarationId",
          sortable: false
        },
        {
          key: "CreatedDate",
          sortable: false
        },
        {
          key: "Status",
          sortable: false
        },
        {
          key: "Country",
          sortable: false
        },
        {
          key: "Procedure",
          sortable: false
        }
      ],

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
      declarationLineChartDataFetched:false,
      declarationTileChartData: {},

      declarationStatusDataFetched:false,
      totalDeclaration:"",
      declarationCleared:"",
      declarationRejected:"",
      declarationInProcess:"",
      declarationTotalChartData:{},
      declarationClearedChartData:{},
      declarationRejectedChartData:{},
      declarationInProcessChartData:{},
      declarationPiechartOptions: {},
      declarationPieChartDataFetched: false,
      declarationPieChartData: {},
      dataFetched: false,
      declarationCount: 0,
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
      ],
      fixedDeclarationStatus : null
    };
  },
  created() {
    this.getDeclarationCount();
    this.getDeclarationsInLastSevenDays();
    this.getStatusCount();
    this.getPerDayDeclarationCountLastWeek();
    this.getDeclarationsByStatus();
  },
  methods: {
    randomColor() {
      var letters = '0123456789ABCDEF';
      var color = '#';
      for (var i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
      }
      const styleObject={background:color};
      return styleObject;
    },
    getProcessingDeclarations() {
        this.fixedDeclarationStatus="Processing";
        this.getDeclarationsByStatus();
    },
    getClearedDeclarations() {
        this.fixedDeclarationStatus="Cleared";
        this.getDeclarationsByStatus();
    },
    getRejectedDeclarations() {
        this.fixedDeclarationStatus="Rejected";
        this.getDeclarationsByStatus();
    },
    getDeclarationsWithAnyStatus(){
       this.fixedDeclarationStatus=null;
       this.getDeclarationsByStatus();
    },
    getDeclarationsByStatus(start = true){
      const status=this.fixedDeclarationStatus;
      this.filterDeclarations = null;
      const url = "/declarationbystatus";
      let postObject = null;
      if(start === true)
      {
         postObject={ DeclarationStatus : status,
                   StartDate : this.range[0],
                   EndDate : this.range[1]
                   };
      }
      else{
        postObject={ DeclarationStatus : status,
                   StartDate : this.range[0],
                   EndDate : this.range[1]
                   };
      }
      httpClient
      .post(url, postObject)
      .then(res => {
         if (res.data === "token refreshed") {
            this.getDeclarationsByStatus();
            return;
          }
         if (res.data.success === true) {
            let filterDeclaration = [];
            const allCases = res.data.data;
             for (let i = 0; i < allCases.length; ++i){
              let obj = {
                  DeclarationId: "KGH-19-" + allCases[i].declarationId,
                  CreatedDate: this.convertDate(allCases[i].createdOn),
                  Status: allCases[i].status,
                  Country: allCases[i].country,
                  Procedure: allCases[i].procedure 
                };
                filterDeclaration.push(obj);
             }
             this.filterDeclarations = filterDeclaration;
              if (this.filterDeclarations.length != 0)
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
    getPerDayDeclarationCountLastWeek(){
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
            const declarationTotalChartData={
              labels: ["Total"],
              datasets: [{
                  backgroundColor: ["white","#66000000"],
                  borderColor: '#fff',
                  borderWidth:0.7,
                  data: [totalDeclaration],
              }]
            };
            this.declarationTotalChartData=declarationTotalChartData;
            this.declarationClearedChartData=declarationClearedChartData;
            this.declarationRejectedChartData=declarationRejectedChartData;
            this.declarationInProcessChartData=declarationInProcessChartData;
            this.declarationCleared=declarationCleared;
            this.declarationRejected=declarationRejected;
            this.declarationInProcess=declarationInProcess;
            this.totalDeclaration=totalDeclaration;
            this.declarationStatusDataFetched=true;
            const options = {
              hoverBorderWidth: 20,
              borderWidth: 10,
              hoverBackgroundColor: "red",
              title: {
                display: true,
                text: "Declaration vs Status",
                fontSize: 24
              },
              maintainAspectRatio: false
            };
        
            this.declarationPieChartOptions = options;
            let pieChartData = [
              response.data.data.cleared,
              response.data.data.rejected,
              response.data.data.processing
            ];
            const declarationPieChartData = {
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
            this.declarationPieChartData = declarationPieChartData;
            this.declarationPieChartDataFetched = true;
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
