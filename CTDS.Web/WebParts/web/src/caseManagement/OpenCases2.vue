<template>
  <div>
    <appCustomSearch :searchObjects="casesAdvanceSearchObjects"></appCustomSearch>
    <div>
      <b-table
        striped
        hover
        fixed
        :fields="fields"
        :items="openCases"
        :current-page="currentPage"
        :per-page="perPage"
      >
        <!-- <span slot-scope="data" slot="Status">
          <appCaseStatusDropDown :defaultValue="data.item.Status">
          </appCaseStatusDropDown>
        </span>
        <span slot-scope="data" slot="Priority">
          <appCasePriorityDropDown :defaultValue="data.item.Priority">
          </appCasePriorityDropDown>
        </span> -->
      </b-table>
    </div>
    <b-row>
      <b-col md="6" class="my-1">
        <b-pagination
          v-model="currentPage"
          :total-rows="totalRows"
          :per-page="perPage"
          class="my-0"
        ></b-pagination>
      </b-col>
    </b-row>
    <!-- <div style="font-family:monospace !important">
      <b-table
        striped
        hover
        fixed
        :fields="fields"
        :items="openCases"
        :current-page="currentPage"
        :per-page="perPage"
        @head-clicked="sortData"
        @row-clicked="editCase"
      >
        <span slot-scope="data" slot="Status">
          <appCaseStatusDropDown :defaultValue="data.item.Status">
          </appCaseStatusDropDown>
        </span>
        <span slot-scope="data" slot="Priority">
          <appCasePriorityDropDown :defaultValue="data.item.Priority">
          </appCasePriorityDropDown>
        </span>
      </b-table>
    </div>
    <b-row>
      <b-col md="6" class="my-1">
        <b-pagination
          v-model="currentPage"
          :total-rows="totalRows"
          :per-page="perPage"
          @change="getNewData"
          class="my-0"
        ></b-pagination>
      </b-col>
    </b-row> -->
  </div>
</template>

<script>
import httpClient from "./../utils/httpRequestWrapper";
import CaseStatusDropDown from "./CaseStatusDropDown.vue";
import CasePriorityDropDown from "./CasePriorityDropDown.vue";
import CustomSearch from "./../commonComponent/CustomSearch";
import casesAdvanceSearchObjects from "./utils/casesAdvanceSearchObjects.js";

export default {
  components: {
    appCaseStatusDropDown: CaseStatusDropDown,
    appCasePriorityDropDown: CasePriorityDropDown,
    appCustomSearch:CustomSearch
  },
  mounted() {
    this.getAllCases(1, this.sortOrder);
  },
  data() {
    return {
      casesAdvanceSearchObjects,
      allCases: [],
      openCases: [],
      currentPage: 1,
      perPage: 3,
      sortOrder: "CaseId",
      totalRows: 0,
      fields: [
        {
          key: "CaseId",
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
          key: "Description",
          sortable: false
        },
        {
          key: "Client",
          sortable: false
        },
        {
          key: "Priority",
          sortable: false
        },
        {
          key: "References",
          sortable: false
        },
        {
          key: "Notes",
          sortable: false
        }
      ]
    };
  },
  methods: {
    sortData(key, val2, val3) {
      this.sortOrder = key;
      this.getAllCases(1, this.sortOrder);
    },
    getNewData(val) {
      this.currentPage = parseInt(val);
      this.getAllCases(this.currentPage, this.sortOrder);
    },
    convertDate(someDate) {
      return new Date(someDate.match(/\d+/)[0] * 1).toString().substring(0, 16);
    },
    editCase: function(row) {
      const caseToEdit = this.allCases.find(function(element) {
        return element.id === row.id;
      });
      if (caseToEdit !== null) {
        this.$store.dispatch("setCase", caseToEdit);
      }
      const url = `/case/${caseToEdit.id}`;
      this.$router.push(url);
    },
    getAllCases: function(val, orderBy) {
      const url = "/casemanagement";
      const index = parseInt(val);
      console.log("index:" + index, "orderBy: " + orderBy);

      httpClient
        .get(url, index, orderBy)
        .then(response => {
          console.log(response);
          if (response.data === "token refreshed") {
            this.getAllCases(index, orderBy);
            return;
          }
          if (response.data.success === true) {
            let openCase = [];

            this.allCases = response.data.data;
            for (let i = 0; i < this.allCases.length; ++i) {
              let referencesString = "";

              if (this.allCases[i].references) {
                referencesString = this.allCases[i].references[0].type;
                for (let j = 1; j < this.allCases[i].references.length; ++j) {
                  referencesString =
                    referencesString +
                    ", " +
                    this.allCases[i].references[j].type;
                }
              }

              let obj = {
                CaseId: "KGH-19-" + this.allCases[i].caseId,
                id: this.allCases[i].id,
                CreatedDate: this.convertDate(this.allCases[i].createdOn),
                Status: this.allCases[i].caseStatus.status,
                Description: this.allCases[i].caseInformation.description,
                Client: this.allCases[i].client.clientIdentifier,
                Notes: this.allCases[i].notes.notesByCpa,
                Priority: this.allCases[i].caseInformation.priority,
                References: referencesString
              };
              openCase.push(obj);
            }
            this.openCases = openCase;
            if (this.openCases.length != 0)
              this.totalRows = this.currentPage * this.perPage + 1;
          }
        })
        .catch(error => {
          console.log(error);
        });
    }
  }
};
</script>
