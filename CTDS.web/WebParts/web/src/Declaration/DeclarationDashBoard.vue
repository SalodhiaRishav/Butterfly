<template>
  <div>
    <div class="font-mono">
      <b-table
        striped
        hover
        :fields="fields"
        :items="declarations"
        :current-page="currentPage"
        :per-page="perPage"
        @row-clicked="getDeclaration"
      ></b-table>
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
    </b-row>
  </div>
</template>

<script>
import httpClient from "./../utils/httpRequestWrapper";

export default {
  mounted() {
    this.getAllDeclaration(1);
  },
  data() {
    return {
      declarations: [],
      currentPage: 1,
      totalRows: 1,
      perPage: 3,
      fields: [
        {
          key: "ID",
          sortable: true
        },
        {
          key: "LRN",
          sortable: true
        },
        {
          key: "MRN",
          sortable: true
        },
        {
          key: "Country",
          sortable: true
        },
        {
          key: "Procedure",
          sortable: true
        },
        {
          key: "Type",
          sortable: true
        },
        {
          key: "Status",
          sortable: true
        },
        {
          key: "customResponse",
          sortable: true
        },
        {
          key: "User",
          sortable: true
        },
        {
          key: "createdOn",
          sortable: true
        },
        {
          key: "taxationDate",
          sortable: true
        }
      ]
    };
  },
  methods: {
    getNewData(val) {
      this.currentPage = parseInt(val);
      this.getAllDeclaration(val);
    },
    convertDate(date) {
      return new Date(date.match(/\d+/)[0] * 1).toString().substring(4, 16);
    },
    getDeclaration: function(row) {
      this.$router.push(`/editdeclaration/${row.BaseID}`);
    },
    getAllDeclaration: function(val) {
      const url = "/getalldeclaration";
      const index = parseInt(val);
      httpClient
        .get(url, index)
        .then(response => {
          if (response.data === "token refreshed") {
            this.getAllDeclaration(index);
          }
          if (response.data.success === true) {
            let declaration = [];
            for (let i = 0; i < response.data.data.length; ++i) {
              let obj = {
                BaseID: response.data.data[i].declarationId,
                createdOn: this.convertDate(response.data.data[i].createdOn),
                status: response.data.data[i].status,
                LRN: " ",
                MRN: " ",
                Country: response.data.data[i].country,
                Procedure: response.data.data[i].procedure,
                Type: response.data.data[i].messageName,
                Status: response.data.data[i].status,
                CustomResponse: " ",
                User: " ",
                TaxationDate: " ",
                ID:
                  "CD-" +
                  response.data.data[i].declarationId.toString().substring(0, 5)
              };
              declaration.push(obj);
            }
            this.declarations = declaration;
            if (this.declarations.length != 0)
              this.totalRows = this.currentPage * this.perPage + 1;
          } else {
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
