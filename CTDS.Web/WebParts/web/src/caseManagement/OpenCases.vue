<template>
  <div>
     <appCustomSearch :searchObjects="casesAdvanceSearchObjects" @applyFilter="onApplyFilter"></appCustomSearch>
    <div class="totalFoundText">{{totalRows}} declarations found</div>
    <div>
      <b-table
        striped
        hover
        fixed
        :fields="fields"
        :items="myProvider"
        :current-page="pageNumber"
        :per-page="maxRowsPerPage"
        @row-clicked="editCase"
      >
      </b-table>
    </div>
    <b-row>
      <b-col md="6" class="my-1">
        <b-pagination
          v-model="pageNumber"
          :total-rows="totalRows"
          :per-page="maxRowsPerPage"
          @change="getNewData"
          class="my-0"
        ></b-pagination>
      </b-col>
    </b-row>
  </div>
</template>

<script>
import httpClient from "./../utils/httpRequestWrapper";
import caseTableFields from "./utils/caseTableFields.js"
import CaseStatusDropDown from "./CaseStatusDropDown.vue";
import CasePriorityDropDown from "./CasePriorityDropDown.vue";
import CustomSearch2 from "./../commonComponent/CustomSearch2";
import casesAdvanceSearchObjects from "./utils/casesAdvanceSearchObjects.js";

export default {
  components: {
    appCaseStatusDropDown: CaseStatusDropDown,
    appCasePriorityDropDown: CasePriorityDropDown,
    appCustomSearch:CustomSearch2
  },
  data() {
    return {
      casesAdvanceSearchObjects,
      filters:null,
      openCases: [],
      pageNumber: 1,
      maxRowsPerPage: 5,
      totalRows: 0,
      fields: caseTableFields,
    };
  },
  methods: {
    showModal() {
        this.$refs['my-modal'].show()
      },
    myProvider(ctx, callback) {
          httpClient.post("/casewithquery",{"Queries":this.filters,"MaxRowsPerPage":this.maxRowsPerPage,"PageNumber":this.pageNumber})
            .then((response)=>{
                 if (response.data === "token refreshed") {
                    this.onApplyFilter(filters);
                    return;
                }
               if(response.data.success === true)
               {
                 const filteredCases=response.data.data.cases;
                   this.openCases=[];
                   let myOpenCases=[];
                    for(let index =0 ; index<filteredCases.length;++index)
                    {
                        let obj = {
                          CaseId: "KGH-19-" + filteredCases[index].caseId,
                          Id: filteredCases[index].id,
                          CreatedDate: this.convertDate(filteredCases[index].createdOn),
                          Status: filteredCases[index].status,
                          Description: filteredCases[index].description,
                          Client: filteredCases[index].client,
                          Notes:filteredCases[index].notes,
                          Priority: filteredCases[index].priority,
                        };
                        myOpenCases.push(obj);
                    }
                    this.openCases=myOpenCases;
                    this.totalRows=response.data.data.totalCount;
                     callback(this.openCases);

               }
               else
               {
                   alert(response.data.message);
                     callback([]);
               }
            })
            .catch((error)=>{
                console.log(error);
                     callback([]);
            })
        return null
     },
      onApplyFilter(filters)
      {
        this.filters=filters;
        if(this.pageNumber===1)
        {
           this.pageNumber=2;
           setTimeout(function(){this.pageNumber=1;}, 2000);
        }
        else
        {
          this.pageNumber=1;
        }
      },
    sortData(key, val2, val3) {
      this.sortOrder = key;
      this.getAllCases(1, this.sortOrder);
    },
    getNewData(val) {
      this.pageNumber = parseInt(val);
    },
    convertDate(someDate) {
      return new Date(someDate.match(/\d+/)[0] * 1).toString().substring(0, 16);
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
    }
  }
};
</script>
<style scoped>
@import url("./styles/openCasesStyle.css");
</style>
