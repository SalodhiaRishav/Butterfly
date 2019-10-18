<template>
  <div>
    <appCustomSearch
      :searchObjects="declarationAdvanceSearchObject"
      @applyFilter="onApplyFilter"
    ></appCustomSearch>
    <div class="totalFoundText">{{ totalRows }} declarations found</div>
    <div>
      <b-table
        striped
        hover
        :fields="fields"
        :items="myProvider"
         :no-sort-reset="true"
        :no-local-sorting="true"
        :current-page="currentPage"
        :per-page="maxRowsPerPage"
        @sort-changed="onSortChange"
        @row-clicked="getDeclaration"
        class="font-size-80"
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
  components: {
    appCustomSearch: CustomSearch
  },

  data() {
    return {
      sortBy:"DecId",
      sortDesc:false,
      declarations: [],
      filters: null,
      currentPage: 1,
      totalRows: 0,
      maxRowsPerPage: 5,
      fields: declarationTableField,
      declarationAdvanceSearchObject
    };
  },
  methods: {
    onSortChange(tableContext){
      this.currentPage=1;
    this.sortBy=tableContext.sortBy;
    this.sortDesc=tableContext.sortDesc;
    },
    myProvider(ctx, callback) {
      httpClient
        .post("/declarationswithquery", {
          Queries: this.filters,
          MaxRowsPerPage: this.maxRowsPerPage,
          PageNumber: this.currentPage,
           SortBy:this.sortBy,
          SortDesc:this.sortDesc
        })
        .then(response => {
          if (response.data === "token refreshed") {
            this.myProvider(ctx, callback);
            return;
          }
          if (response.data.success === true) {
            let declaration = [];
            const filteredDeclarations = response.data.data.declarations;
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
                DecId: "KGH-19-" + filteredDeclarations[i].decId
                };
              declaration.push(obj);
            }
            this.declarations = declaration;
            this.totalRows = response.data.data.totalCount;
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
      return null;
    },
    onApplyFilter(filters) {
      this.filters = filters;
      if (this.currentPage === 1) {
        this.currentPage = 2;
        setTimeout(function() {
          this.currentPage = 1;
        }, 2000);
      } else {
        this.currentPage = 1;
      }
    },
  
    convertDate(date) {
      return new Date(date.match(/\d+/)[0] * 1).toString().substring(4, 16);
    },
    getDeclaration: function(row) {
      this.$router.push(`/editdeclaration/${row.BaseID}`);
    },
  }
};
</script>

<style scoped>
@import url("./Style/declarationDashboardStyle.css");
</style>
