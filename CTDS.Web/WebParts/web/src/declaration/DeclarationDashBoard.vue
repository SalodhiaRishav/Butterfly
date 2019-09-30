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
        @head-clicked="sortData"
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
    this.getAllDeclaration(1, this.sortOrder);
  },
  data() {
    return {
      declarations: [],
      currentPage: 1,
      totalRows: 1,
      perPage: 3,
      sortOrder: "DeclarationId",
      fields: [
        {
          key: "DeclarationId",
          sortable: false
        },
        {
          key: "LRN",
          sortable: false
        },
        {
          key: "MRN",
          sortable: false
        },
        {
          key: "Country",
          sortable: false
        },
        {
          key: "Procedure",
          sortable: false
        },
        {
          key: "Type",
          sortable: false
        },
        {
          key: "Status",
          sortable: false
        },
        {
          key: "CustomResponse",
          sortable: false
        },
        {
          key: "User",
          sortable: false
        },
        {
          key: "CreatedOn",
          sortable: false
        },
        {
          key: "TaxationDate",
          sortable: false
        }
      ]
    };
  },
  methods: {
    sortData(key, val2, val3) {
      this.sortOrder = key;
      this.getAllDeclaration(1, this.sortOrder);
    },
    getNewData(val) {
      this.currentPage = parseInt(val);
      console.log("get new data " + this.sortOrder);
      this.getAllDeclaration(val, this.sortOrder);
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
            for (let i = 0; i < response.data.data.length; ++i) {
              let obj = {
                BaseID: response.data.data[i].declarationId,
                CreatedOn: this.convertDate(response.data.data[i].createdOn),
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
                DeclarationId:
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
