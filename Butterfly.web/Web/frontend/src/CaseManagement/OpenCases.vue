<template>
  <div>
    <div>
      <b-table
        striped
        hover
        fixed
        :fields="fields"
        :items="openCases"
        :current-page="currentPage"
        :per-page="perPage"
        @row-clicked="someFunction"
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
import axios from "axios";
import CaseStatusDropDown from "./CaseStatusDropDown.vue";
import CasePriorityDropDown from "./CasePriorityDropDown.vue";

export default {
  components: {
    appCaseStatusDropDown: CaseStatusDropDown,
    appCasePriorityDropDown: CasePriorityDropDown
  },
  mounted() {
    this.getAllCases()
      .then(response => {
        if (response !== null) {
          let openCase = [];

          this.allCases = response;
          for (let i = 0; i < response.length; ++i) {
            let referencesString = "";

            if (response[i].references) {
              referencesString = response[i].references[0].type;
              for (let j = 1; j < response[i].references.length; ++j) {
                referencesString =
                  referencesString + ", " + response[i].references[j].type;
              }
            }

            let obj = {
              caseId: "KGH-19-" + response[i].caseId,
              id: response[i].id,
              createdDate: this.convertDate(response[i].createdOn),
              caseStatus: response[i].caseStatus.status,
              description: response[i].caseInformation.description,
              client: response[i].client.clientIdentifier,
              notes: response[i].notes.notesByCpa,
              casePriority: response[i].caseInformation.priority,
              references: referencesString
            };
            openCase.push(obj);
          }
          this.openCases = openCase;
          this.totalRows = this.openCases.length;
        }
      })
      .catch(error => {
        alert(error);
      });
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
    someFunction: function(row) {
      const foundCase = this.allCases.find(function(element) {
        return element.id === row.id;
      });
      if (foundCase !== null) {
        this.$store.dispatch("setCaseToEdit", foundCase);
      }
      this.$router.push("/editcase");
    },
    getAllCases: function() {

      return new Promise((resolve, reject) => {
        let config = {
          headers: {
            "Authorization": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFkbWluQGJ1dHRlcmZseS5jb20iLCJyb2xlIjoiQWRtaW4iLCJuYmYiOjE1NjYxNDU5NDEsImV4cCI6MTU2NjE0NjA2MSwiaWF0IjoxNTY2MTQ1OTQxLCJpc3MiOiJyaXNoYXYgc2VydmVyIn0.ReUG4umjbMGPZRkuqy0szGCs30gzy03uryst1nEeNkg",
          }
}
        const url = "https://localhost:44313/casemanagement";
        axios
          .get(url,config)
          .then(response => {
            if(response.data === "token expired")
            {
              const refreshTokenUrl = "https://localhost:44313/refreshtoken";
              let postData={
                "refreshTokenSerialId":"9f66098a944a1cc3e81c0a45146932fa"
              }
              axios.post(refreshTokenUrl,postData)
              .then(myresponse =>{
                console.log(myresponse);
              })
            }
            if (response.data.success === true) {
              resolve(response.data.data);
            } else {
              resolve(null);
            }
          })
          .catch(error => {
            reject(error);
          });
      });
    }
  }
};
</script>
