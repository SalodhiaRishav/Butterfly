<template>
  <div>
    <div style="font-family:monospace !important">
      <b-table
        striped
        hover
        fixed
        :fields="fields"
        :items="openCases"
        :current-page="currentPage"
        :per-page="perPage"
        @row-clicked="editCase"
      >
        <span slot-scope="data" slot="status">
          <appCaseStatusDropDown :defaultValue="data.item.caseStatus">
          </appCaseStatusDropDown>
        </span>
        <span slot-scope="data" slot="priority">
          <appCasePriorityDropDown :defaultValue="data.item.casePriority">
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
          class="my-0"
        ></b-pagination>
      </b-col>
    </b-row>
  </div>
</template>

<script>
import httpClient from "./../utils/httpRequestWrapper";
import CaseStatusDropDown from "./CaseStatusDropDown.vue";
import CasePriorityDropDown from "./CasePriorityDropDown.vue";

export default {
  components: {
    appCaseStatusDropDown: CaseStatusDropDown,
    appCasePriorityDropDown: CasePriorityDropDown
  },
  mounted() {
    this.getAllCases();
  },
  data() {
    return {
      allCases: [],
      openCases: [],
      currentPage: 1,
      perPage: 3,
      totalRows: 0,
      fields: [
        {
          key: "caseId",
          sortable: true
        },
        {
          key: "createdDate",
          sortable: true
        },
        {
          key: "status",
          sortable: true
        },
        {
          key: "description",
          sortable: true
        },
        {
          key: "client",
          sortable: true
        },
        {
          key: "priority",
          sortable: true
        },
        {
          key: "references",
          sortable: true
        },
        {
          key: "notes",
          sortable: true
        }
      ]
    };
  },
  methods: {
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
    getAllCases: function() {
      const resource = "/casemanagement";
      httpClient
        .get(resource)
        .then(response => {
          if (response.data === "token refreshed") {
            this.getAllCases();
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
                caseId: "KGH-19-" + this.allCases[i].caseId,
                id: this.allCases[i].id,
                createdDate: this.convertDate(this.allCases[i].createdOn),
                caseStatus: this.allCases[i].caseStatus.status,
                description: this.allCases[i].caseInformation.description,
                client: this.allCases[i].client.clientIdentifier,
                notes: this.allCases[i].notes.notesByCpa,
                casePriority: this.allCases[i].caseInformation.priority,
                references: referencesString
              };
              openCase.push(obj);
            }
            this.openCases = openCase;
            this.totalRows = this.openCases.length;
          }
        })
        .catch(error => {
          console.log(error);
        });
    }
  }
};
</script>
