<template>
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
</template>

<script>
import axios from 'axios';

export default {
  mounted(){
    this.getAllCases()
    .then((response)=>{
      let declaration=[];
     // this.allCases=response;
      for(let i=0;i<response.length;++i)
      {
        let obj={
          ID:response[i].declarationId,
          createdDate:"",
          status:response[i].status,
          LRN: " ",
          MRN: " ",
          Country: response[i].country,
          Procedure: response[i].procedure,
          Type: response[i].messageName,
          Status: "Processing",
          CustomResponse:" ",
          User: " ",
          TaxationDate: " ",
          }
          declaration.push(obj);
      }
      this.declarations=declaration;
    })
    .catch((error)=>{
      
    })
  },
  data() {
    return {
      allCases:[],
      openCases: [],
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
          key: "Custom Response",
          sortable: true
        },
        {
          key: "User",
          sortable: true
        },
        {
          key: "Creation Date",
          sortable: true
        },{
          key: "Taxation date",
          sortable: true
        }
      ]
    };
  },
  methods:{
    someFunction:function(row)
    {
      const foundCase = this.allCases.find(function(element) { 
                return element.id === row.caseId; 
            });
            if(foundCase!==null)
            {
              this.$store.dispatch("setCaseToEdit",foundCase);
            }
            this.$router.push('/editcase');

    },
      getAllCases:function(){
       return new Promise((resolve, reject)=> {
          const url= "https://localhost:44313/casemanagement"
          axios.get(url)
          .then((response)=>{
            if(response.data.success===true)
            {
             resolve(response.data.data)
            }
            else
            {
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
