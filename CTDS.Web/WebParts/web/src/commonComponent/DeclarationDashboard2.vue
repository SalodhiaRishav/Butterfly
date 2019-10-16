<template>
  <div>
    <div class="background-gray">
      <div class="row tilesRow" v-if="declarationStatusDataFetched">
        <div
          class="col-sm-4 col-md-3 tileBox"
        >
          <appTileWithGaugeChart   v-bind:class="{ tileShadow : nullActive }"
            @tileClicked="onTileClick(null)"
            class="colorGreen"
            tooltipTitle="Total Declarations"
            chartTitle="Total Declarations"
            :counter="totalDeclaration"
            title="Total Declarations"
            :chartData="declarationTotalChartData"
          ></appTileWithGaugeChart>
        </div>
        <div class="col-sm-4 col-md-3 tileBox">
          <appTileWithGaugeChart   v-bind:class="{ tileShadow : clearedActive }"
            @tileClicked="onTileClick('Cleared')"
            class="colorBrown"
            tooltipTitle="Declarations Cleared"
            chartTitle="Declarations Cleared / Total Declarations"
            :counter="declarationCleared"
            title="Declaration Cleared"
            :chartData="declarationClearedChartData"
          ></appTileWithGaugeChart>
        </div>
        <div class="col-sm-4 col-md-3 tileBox">
          <appTileWithGaugeChart   v-bind:class="{ tileShadow : processingActive }"
            @tileClicked="onTileClick('Processing')"
            class="colorCyan"
            tooltipTitle="Declarations InProcess"
            chartTitle="Declarations In Process / Total Declarations"
            :counter="declarationInProcess"
            title="Declaration In Process"
            :chartData="declarationInProcessChartData"
          ></appTileWithGaugeChart>
        </div>
        <div class="col-sm-4 col-md-3 tileBox">
          <appTileWithGaugeChart   v-bind:class="{ tileShadow : rejectedActive }"
            @tileClicked="onTileClick('Rejected')"
            class="colorCrimson"
            tooltipTitle="Declarations Rejected"
            chartTitle="Declarations Rejected / Total Declarations"
            :counter="declarationRejected"
            title="Declaration Rejected"
            :chartData="declarationRejectedChartData"
          ></appTileWithGaugeChart>
        </div>
      </div>
      <div class="row tilesRow">
        <div class="col-md-12 tileBox shadowBox">
          <table class="dashboardTable">
            <tr>
              <th>
                <appDateRangePicker
                  class="dateRangePicker"
                  v-model="range"
                  @input="getDeclarationsByStatus()"
                ></appDateRangePicker>
              </th>
              <th><font-awesome-icon icon="calendar" /></th>
            </tr>
          </table>
          <button @click="shouldShowChart = true">ShowChart</button>
          <button @click="shouldShowChart = false">ShowTable</button>
          <div v-if="!shouldShowChart">
            <div>
              <b-table
                class="font-size-80"
                striped
                hover
                fixed
                :fields="fields"
                :items="filterDeclarations"
                :current-page="currentPage"
                :per-page="perPage"
                @row-clicked="getDeclaration"
              >
              </b-table>
            </div>
            <b-row>
              <b-col md="6" class="my-1 font-size-80">
                <b-pagination
                  v-model="currentPage"
                  :total-rows="totalRows"
                  :per-page="perPage"
                  class="my-0"
                >
                </b-pagination>
              </b-col>
            </b-row>
          </div>
          <div class="dashboardChartDiv" v-if="shouldShowChart">
            <appDeclarationDashboardLineChart
              :status="fixedDeclarationStatus"
              :startDate="range[0]"
              :endDate="range[1]"
            ></appDeclarationDashboardLineChart>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import httpClient from "./../utils/httpRequestWrapper";
import TileWithGaugeChart from "./TileWithGaugeChart";
import MyDateRangePicker from "./MyDateRangePicker";
import DeclarationDashboardLineChart from "./DeclarationDashboardLineChart";

export default {
  components: {
    appDeclarationDashboardLineChart: DeclarationDashboardLineChart,
    appDateRangePicker: MyDateRangePicker,
    appTileWithGaugeChart: TileWithGaugeChart
  },
  data() {
    return {
      nullActive:true,
      clearedActive: false,
      processingActive:false,
      rejectedActive: false,
      shouldShowChart: false,
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
      range: [this.$moment().subtract(29, "days"), this.$moment()],
      declarationStatusDataFetched: false,
      totalDeclaration: "",
      declarationCleared: "",
      declarationRejected: "",
      declarationInProcess: "",
      declarationTotalChartData: {},
      declarationClearedChartData: {},
      declarationRejectedChartData: {},
      declarationInProcessChartData: {},
      declarationPieChartData: {},
      declarationCount: 0,
      fixedDeclarationStatus: null
    };
  },
  created() {
    this.getStatusCount();
    this.getDeclarationsByStatus();
  },
  methods: {
    onTileClick(status) {

      if(status == 'Cleared'){
        
        this.nullActive=false;
        this.clearedActive=true;
        this.processingActive=false;
        this.rejectedActive=false;
        
      }
      else if(status == 'Processing'){
        
        this.nullActive=false;
        this.clearedActive=false;
        this.processingActive=true;
        this.rejectedActive=false;
      }
      else if(status == 'Rejected'){
        
        this.nullActive=false;
        this.clearedActive=false;
        this.processingActive=false;
        this.rejectedActive=true;
    
      }
      else{
        this.nullActive=true;
        this.clearedActive=false;
        this.processingActive=false;
        this.rejectedActive=false;
      }
      
      this.fixedDeclarationStatus = status;
      if (this.shouldShowChart === false) {
        this.getDeclarationsByStatus();
      } else {
        this.shouldShowChart = false;
        this.shouldShowChart = true;
      }
    },
    getDeclaration: function(row) {
      this.$router.push(`/editdeclaration/${row.DeclarationId}`);
    },
    getDeclarationsByStatus() {
      const status = this.fixedDeclarationStatus;
      this.filterDeclarations = null;
      const url = "/declarationbystatus";
      let postObject = {
          DeclarationStatus: status,
          StartDate: this.range[0],
          EndDate: this.range[1]
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
            for (let i = 0; i < allCases.length; ++i) {
              let obj = {
                DeclarationId: "KGH-19-" + allCases[i].decId,
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
    getStatusCount() {
      const url = "/getdeclarationstatuscount";
      httpClient
        .get(url)
        .then(response => {
          if (response.data.success === true) {
            const declarationCleared = response.data.data.cleared;
            const declarationRejected = response.data.data.rejected;
            const declarationInProcess = response.data.data.processing;
            const totalDeclaration =
              declarationCleared + declarationRejected + declarationInProcess;
            const declarationInProcessChartData = {
              labels: ["InProcess", "Others"],
              datasets: [
                {
                  backgroundColor: ["white", "#66000000"],
                  borderColor: "#fff",
                  borderWidth: 0.7,
                  data: [
                    declarationInProcess,
                    totalDeclaration - declarationInProcess
                  ]
                }
              ]
            };
            const declarationClearedChartData = {
              labels: ["Cleared", "Remaining"],
              datasets: [
                {
                  backgroundColor: ["white", "#66000000"],
                  borderColor: "#fff",
                  borderWidth: 0.7,
                  data: [
                    declarationCleared,
                    totalDeclaration - declarationCleared
                  ]
                }
              ]
            };
            const declarationRejectedChartData = {
              labels: ["Rejected", "Remaining"],
              datasets: [
                {
                  backgroundColor: ["white", "#66000000"],
                  borderColor: "#fff",
                  borderWidth: 0.7,
                  data: [
                    declarationRejected,
                    totalDeclaration - declarationRejected
                  ]
                }
              ]
            };
            const declarationTotalChartData = {
              labels: ["Total"],
              datasets: [
                {
                  backgroundColor: ["white", "#66000000"],
                  borderColor: "#fff",
                  borderWidth: 0.7,
                  data: [totalDeclaration]
                }
              ]
            };
            this.declarationTotalChartData = declarationTotalChartData;
            this.declarationClearedChartData = declarationClearedChartData;
            this.declarationRejectedChartData = declarationRejectedChartData;
            this.declarationInProcessChartData = declarationInProcessChartData;
            this.declarationCleared = declarationCleared;
            this.declarationRejected = declarationRejected;
            this.declarationInProcess = declarationInProcess;
            this.totalDeclaration = totalDeclaration;
            this.declarationStatusDataFetched = true;
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
