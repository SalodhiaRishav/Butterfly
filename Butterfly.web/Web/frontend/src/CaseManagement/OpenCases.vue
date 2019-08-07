<template>
  <div>
    <div>
      <b-table
        striped
        hover
        :fields="fields"
        :items="openCases"
        :current-page="currentPage"
        :per-page="perPage"
        @row-clicked="someFunction"
      ></b-table>
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

export default {
  mounted() {
    this.getAllCases()
      .then(response => {
        if (response !== null) {
          let openCase = [];
          this.allCases = response;
          for (let i = 0; i < response.length; ++i) {
            let obj = {
              caseId: response[i].id,
              createdDate: this.convertDate(response[i].createdOn),
              status: response[i].caseStatus.status,
              description: response[i].caseInformation.description,
              client: response[i].client.clientIdentifier,
              priority: response[i].caseInformation.priority
            };
            openCase.push(obj);
          }
          this.openCases = openCase;
          this.totalRows=this.openCases.length;
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
      perPage:3,
      totalRows:0,
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
        return element.id === row.caseId;
      });
      if (foundCase !== null) {
        this.$store.dispatch("setCaseToEdit", foundCase);
      }
      this.$router.push("/editcase");
    },
    getAllCases: function() {
      return new Promise((resolve, reject) => {
        const url = "https://localhost:44313/casemanagement";
        axios
          .get(url)
          .then(response => {
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
