<template>
  <div>
    <div class="background-gray">
      <div class="row tilesRow" v-if="caseStatusDataFetched" >
        <div class="col-sm-4 col-md-3 tileBox" >
          <appTileWithGaugeChart    v-bind:class="{ tileShadow : nullActive }"
            @tileClicked="onTileClick(null)"
            class="colorGreen"
            :counter="totalCases"
            title="Total Cases"
            chartTitle="Total Cases"
            :chartData="caseTotalChartData"
          ></appTileWithGaugeChart>
        </div>
        <div class="col-sm-4 col-md-3 tileBox">
          <appTileWithGaugeChart  v-bind:class="{ tileShadow : newActive }"
            @tileClicked="onTileClick('New')"
            class="colorBrown"
            :counter="newCases"
            title="New Cases"
            chartTitle="New Cases / Total Cases"
            :chartData="caseNewChartData"
          ></appTileWithGaugeChart>
        </div>
        <div class="col-sm-4 col-md-3 tileBox">
          <appTileWithGaugeChart  v-bind:class="{ tileShadow : inProcessActive }"
            @tileClicked="onTileClick('InProcess')"
            class="colorCyan"
            :counter="inProcessCases"
            chartTitle="InProcess Cases / Total Cases"
            title="Cases In Process"
            :chartData="caseInProcessChartData"
          ></appTileWithGaugeChart>
        </div>
        <div class="col-sm-4 col-md-3 tileBox">
          <appTileWithGaugeChart   v-bind:class="{ tileShadow : closedActive }"
            @tileClicked="onTileClick('Closed')"
            class="colorCrimson"
            :counter="closedCases"
            chartTitle="Closed Cases / Total Cases"
            title="Closed Cases"
            :chartData="caseClosedChartData"
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
                  @input="getCasesByStatus()"
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
                  class="my-0"
                >
                </b-pagination>
              </b-col>
            </b-row>
          </div>
          <div class="dashboardChartDiv" v-if="shouldShowChart">
            <appCaseDashboardLineChart
              :status="fixedCaseStatus"
              :startDate="range[0]"
              :endDate="range[1]"
            ></appCaseDashboardLineChart>
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
import CaseTableFields from "./../caseManagement/utils/caseTableFields";
import CaseDashboardLineChart from "./CaseDashboardLineChart";

export default {
  components: {
    appCaseDashboardLineChart: CaseDashboardLineChart,
    appDateRangePicker: MyDateRangePicker,
    appTileWithGaugeChart: TileWithGaugeChart
  },
  data() {
    return {
      nullActive:true,
      newActive: false,
      inProcessActive:false,
      closedActive: false,
      filterCases: [],
      currentPage: 1,
      perPage: 5,
      totalRows: 0,
      caseTableFields: CaseTableFields,
      range: [this.$moment().subtract(29, "days"), this.$moment()],
      shouldShowChart: false,
      caseLineChartDataFetched: false,
      caseStatusDataFetched: false,
      newCases: "",
      closedCases: "",
      inProcessCases: "",
      totalCases: "",
      caseTotalChartData: {},
      caseNewChartData: {},
      caseInProcessChartData: {},
      caseClosedChartData: {},
      dataFetched: false,
      fixedCaseStatus: null
    };
  },
  mounted() {
    this.getFilteredCaseCount();
    this.getCasesByStatus();
  },
  methods: {
    editCase: function(row) {
      const urlResource = `/casemanagement/${row.Id}`;
      httpClient
        .get(urlResource)
        .then(response => {
          if (response.data.success === true) {
            this.$store.dispatch("setCase", response.data.data);
            const url = `/case/${row.Id}`;
            this.$router.push(url);
          } else {
            console.log(response.data.data);
          }
        })
        .catch(error => {
          console.log(error);
        });
    },
    onTileClick(status) {
      
      if(status == 'New'){
        
        this.nullActive=false;
        this.newActive=true;
        this.inProcessActive=false;
        this.closedActive=false;
        
      }
      else if(status == 'InProcess'){
        
        this.nullActive=false;
        this.newActive=false;
        this.inProcessActive=true;
        this.closedActive=false;
      }
      else if(status == 'Closed'){
        
        this.nullActive=false;
        this.newActive=false;
        this.inProcessActive=false;
        this.closedActive=true;
    
      }
      else{
        this.nullActive=true;
        this.newActive=false;
        this.inProcessActive=false;
        this.closedActive=false;
      }
      
      this.fixedCaseStatus = status;
      if (this.shouldShowChart === false) {
        this.getCasesByStatus();
      } else {
        this.shouldShowChart = false;
        this.shouldShowChart = true;
      }
    },
    getCasesByStatus() {
      const status = this.fixedCaseStatus;
      this.filterCases = null;
      const url = "/casebystatus";
      let postObject = {
          CaseStatus: status,
          StartDate: this.range[0],
          EndDate: this.range[1]
        };
      httpClient
        .post(url, postObject)
        .then(res => {
          if (res.data === "token refreshed") {
            this.getCasesByStatus();
          }
          if (res.data.success === true) {
            let filterCase = [];
            const allCases = res.data.data;
            for (let i = 0; i < allCases.length; ++i) {
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
            this.totalRows=filterCase.length;
          }
          else
          {
            alert(response.data.message);
          }
        })
        .catch(error => {
          console.log(error);
        });
    },
    convertDate(someDate) {
      return new Date(someDate.match(/\d+/)[0] * 1).toString().substring(0, 16);
    },
    getFilteredCaseCount() {
      const url = "/filtercasecount";
      httpClient
        .get(url)
        .then(response => {
          if (response.data === "token refreshed") {
            this.getFilteredCaseCount();
          }
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
            const newCases = newHigh + newMed + newLow;
            const caseInProcess =
              inProgressHigh + inProgressMed + inProgressLow;
            const closedCases = closedHigh + closedMedium + closedLow;
            const totalCases = caseInProcess + closedCases + newCases;

            const caseInProcessChartData = {
              labels: ["InProcess", "Others"],
              datasets: [
                {
                  backgroundColor: ["white", "#66000000"],
                  borderColor: "#fff",
                  borderWidth: 0.7,
                  data: [caseInProcess, totalCases - caseInProcess]
                }
              ]
            };
            const caseClosedChartData = {
              labels: ["Closed", "Others"],
              datasets: [
                {
                  backgroundColor: ["white", "#66000000"],
                  borderColor: "#fff",
                  borderWidth: 0.7,
                  data: [closedCases, totalCases - closedCases]
                }
              ]
            };
            const caseNewChartData = {
              labels: ["New", "Others"],
              datasets: [
                {
                  backgroundColor: ["white", "#66000000"],
                  borderColor: "#fff",
                  borderWidth: 0.7,
                  data: [newCases, totalCases - newCases]
                }
              ]
            };
            const caseTotalChartData = {
              labels: ["Total"],
              datasets: [
                {
                  backgroundColor: ["white", "#66000000"],
                  borderColor: "#fff",
                  borderWidth: 0.7,
                  data: [totalCases]
                }
              ]
            };
            this.caseTotalChartData = caseTotalChartData;
            this.caseNewChartData = caseNewChartData;
            this.caseClosedChartData = caseClosedChartData;
            this.caseInProcessChartData = caseInProcessChartData;
            this.closedCases = closedCases;
            this.newCases = newCases;
            this.inProcessCases = caseInProcess;
            this.totalCases = totalCases;
            this.caseStatusDataFetched = true;
          } else {
            console.log(response.data.message);
          }
        })
        .catch(error => {
          console.log(error);
        });
    },
  }
};
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css?family=Source+Sans+Pro:200,400,900&display=swap");
@import url("./styles/dashboard2.css");
@import url("./styles/tileDash2Style.css");
</style>
