<template>
    <div>
         <div v-if="showDropDown" >
                <b-form-group
                :label="label"
                :label-for="id"
              >
              <div class="label">{{label}}</div>
                <b-form-select
                  :id="id"
                   :value="value"
                   @input="$emit('input', $event)"
                  :options="dropDownOptions"
                  :multiple=true
                ></b-form-select>
              </b-form-group>
        </div>
    </div>
</template>

<script>
import httpClient from "./../utils/httpRequestWrapper"
export default {
    
    mounted(){
         this.fetchDataToFillDropDown(this.dataSource);
    },
    methods:{
        fetchDataToFillDropDown(source)
        {
        httpClient
        .get(source)
        .then(response => {
          if (response.data === "token refreshed") {
            this.fetchDataToFillDropDown();
            return;
          }
          if (response.data.success === true) {
            this.dropDownOptions = response.data.data;
            this.showDropDown = true;
            return;
          } else {
            alert(response.data.message);
            return;
          }
        })
        .catch(error => {
          alert(error);
        });
        }
    },
    data(){
        return{
            showDropDown:true,
            dropDownOptions:[],
        }
    },
    props:{
        id:{
            type:String,
            required:true
        },
        label:{
            type:String,
            required:true
        },
        dataSource:{
            type:String,
            required:true
        },
        value:{
          default:null
        }
    },
}
</script>