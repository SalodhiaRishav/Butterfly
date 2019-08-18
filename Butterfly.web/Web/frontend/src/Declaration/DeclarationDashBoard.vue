<template>
<div>
  <div>
    <div>
      <b-table
        striped
        hover
        :fields="fields"
        :items="declarations"
        :current-page="currentPage"
        :per-page="perPage"
        @row-clicked="someFunction"
      ></b-table>
    </div>
    <b-row>
      <b-col md="6" class="my-1">
        <b-pagination
          v-model="currentPage"
          :total-rows="3"
          :per-page="perPage"
          class="my-0"
        ></b-pagination>
      </b-col>
    </b-row>
  </div>
</div>
</template>

<script>
import axios from "axios";
import appNavbar from './../CommonComponent/Navbar';

export default {
  
  mounted() {
    this.getAllDeclaration()
      .then(response => {
        let declaration = [];

        for (let i = 0; i < response.length; ++i) {
          let obj = {
            BaseID: response[i].declarationId,
            createdOn: this.convertDate(response[i].createdOn),
            status: response[i].status,
            LRN: " ",
            MRN: " ",
            Country: response[i].country,
            Procedure: response[i].procedure,
            Type: response[i].messageName,
            Status: "Processing",
            CustomResponse: " ",
            User: " ",
            TaxationDate: " ",
            ID: "CD-" + response[i].declarationId.toString().substring(0, 5)
          };
          declaration.push(obj);
        }
        this.declarations = declaration;
      })
      .catch(error => {});
  },
  data() {
    return {
      declarations: [],
      currentPage: 1,
      perPage: 5,
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
    convertDate(date) {
      return new Date(date.match(/\d+/)[0] * 1).toString().substring(4, 16);
    },
    someFunction: function(row) {
      //console.log(row);
      // if(foundCase!==null)
      // {
      //   this.$store.dispatch("setCaseToEdit",foundCase);
      // }
      this.$router.push({ path: `/editdeclaration/${row.BaseID}` });
    },
    getAllDeclaration: function() {
      return new Promise((resolve, reject) => {
        const url = "https://localhost:44313/getalldeclaration";
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
