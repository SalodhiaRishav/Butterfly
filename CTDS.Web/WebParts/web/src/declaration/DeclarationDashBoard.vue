<template>
  <div>
    <appCustomSearch :searchObjects="declarationAdvanceSearchObject" @applyFilter="onApplyFilter"></appCustomSearch>
    <div class="totalFoundText">{{totalRows}} declarations found</div>
    <div class="font-mono">
      <b-table
        striped
        hover
        :fields="fields"
        :items="myProvider"
        :current-page="currentPage"
        :per-page="maxRowsPerPage"
        @row-clicked="getDeclaration"
      ></b-table>
    </div>
    <b-row>
      <b-col md="6" class="my-1">
        <b-pagination
          v-model="currentPage"
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
import declarationTableField from "./Utils/declarationTableField.js";
import declarationAdvanceSearchObject from "./Utils/declarationAdvanceSearchObject.js";
import CustomSearch from "./../commonComponent/CustomSearch";

export default {
  components:{
    appCustomSearch:CustomSearch
  },
  mounted() {
    // this.getAllDeclaration(1, this.sortOrder);
  },
  data() {
    return {
      declarations: [],
      filters:null,
      currentPage: 1,
      totalRows: 0,
      maxRowsPerPage: 5,
      sortOrder: "DeclarationId",
      fields:declarationTableField,
      declarationAdvanceSearchObject,
    };
  },
  methods: {
     myProvider(ctx, callback) {
          httpClient.post("/declarationswithquery",{"Queries":this.filters,"MaxRowsPerPage":this.maxRowsPerPage,"PageNumber":this.currentPage})
            .then((response)=>{
                 if (response.data === "token refreshed") {
                    this.myProvider(ctx, callback);
                    return;
                }
               if (response.data.success === true) {
                 console.log(response);
            let declaration = [];
             const filteredDeclarations=response.data.data.declarations;
            for (let i = 0; i < filteredDeclarations.length; ++i) {
              let obj = {
                BaseID: filteredDeclarations[i].declarationId,
                CreatedOn: this.convertDate(filteredDeclarations[i].createdOn),
                status: filteredDeclarations[i].status,
                LRN: " ",
                MRN: " ",
                Country: filteredDeclarations[i].country,
                Procedure: filteredDeclarations[i].procedure,
                Type: filteredDeclarations[i].messageName,
                Status: filteredDeclarations[i].status,
                CustomResponse: " ",
                User: " ",
                TaxationDate: " ",
                DeclarationId:
                  "CD-" +
                  filteredDeclarations[i].declarationId.toString().substring(0, 5)
              };
              declaration.push(obj);
            }
            this.declarations = declaration;
             this.totalRows=response.data.data.totalCount;
             callback(this.declarations);
          } else {
            alert(response.data.message);
            callback([]);
          }
        })
        .catch(error => {
          alert(error);
          callback([]);
        });
        // Must return null or undefined to signal b-table that callback is being used
        return null
     },
    onApplyFilter(filters)
    {
     this.filters=filters;
        if(this.currentPage===1)
        {
           this.currentPage=2;
           setTimeout(function(){this.currentPage=1;}, 2000);
        }
        else
        {
          this.currentPage=1;
        }
    },
    sortData(key, val2, val3) {
      this.sortOrder = key;
      this.getAllDeclaration(1, this.sortOrder);
    },
    getNewData(val) {
      this.currentPage = parseInt(val);
      // console.log("get new data " + this.sortOrder);
      // this.getAllDeclaration(val, this.sortOrder);
    },
    convertDate(date) {
      return new Date(date.match(/\d+/)[0] * 1).toString().substring(4, 16);
    },
    getDeclaration: function(row) {
      this.$router.push(`/editdeclaration/${row.BaseID}`);
    },
    getAllDeclaration: function(val, orderBy) {
      console.log(this.sortOrder + " " + this.currentPage);
      const url = "/getalldeclaration";
      const index = parseInt(val);
      httpClient
        .get(url, index, orderBy)
        .then(response => {
          if (response.data === "token refreshed") {
            this.getAllDeclaration(index, orderBy);
            return;
          }
          if (response.data.success === true) {
            let declaration = [];
             const filteredDeclarations=response.data.data.declarations;
            for (let i = 0; i < filteredDeclarations.length; ++i) {
              let obj = {
                BaseID: filteredDeclarations[i].declarationId,
                CreatedOn: this.convertDate(filteredDeclarations[i].createdOn),
                status: filteredDeclarations[i].status,
                LRN: " ",
                MRN: " ",
                Country: filteredDeclarations[i].country,
                Procedure: filteredDeclarations[i].procedure,
                Type: filteredDeclarations[i].messageName,
                Status: filteredDeclarations[i].status,
                CustomResponse: " ",
                User: " ",
                TaxationDate: " ",
                DeclarationId:
                  "CD-" +
                  filteredDeclarations[i].declarationId.toString().substring(0, 5)
              };
              declaration.push(obj);
            }
            this.declarations = declaration;
             this.totalRows=response.data.data.totalCount;
             callback(this.declarations);
          } else {
            alert(response.data.message);
            callback([]);
          }
        })
        .catch(error => {
          alert(error);
          callback([]);
        });
    }
  }
};
</script>

<style scoped>
@import url("./Style/declarationDashboardStyle.css");
</style>
