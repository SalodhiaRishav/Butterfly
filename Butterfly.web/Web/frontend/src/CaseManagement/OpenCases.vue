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

 
        const accessToken=this.$store.getters.accessToken;
        if(accessToken ===  null)
        {
          alert("Refresh Token expired,Please login again");
          this.$router.push("/login");
          return;
        }
        let config = {
          headers: {
            "Authorization": accessToken
          }
         }
        const url = "https://localhost:44313/casemanagement";
        axios
          .get(url,config)
          .then(response => {
            if (response.data.success === true) {
              let openCase = [];

          this.allCases = response.data.data;
          for (let i = 0; i < this.allCases.length; ++i) {
            let referencesString = "";

            if (this.allCases[i].references) {
              referencesString = this.allCases[i].references[0].type;
              for (let j = 1; j < this.allCases[i].references.length; ++j) {
                referencesString =
                  referencesString + ", " + this.allCases[i].references[j].type;
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
            else if(response.data == "token expired")
            {
              const refreshTokenSerial=this.$store.getters.refreshTokenSerial;
              this.$store.dispatch("getNewToken",refreshTokenSerial)
              .then((myresponse)=>{
                    this.$store.dispatch("setAccessToken","bearer "+myresponse);
                    this.getAllCases();
              })
              .catch(error=>{
                alert(error);
              })
            }
            else{
              alert(response.data.message);
            }
          })
          .catch(error => {
            alert(error);
          });
     
    }
  }
};
</script>
