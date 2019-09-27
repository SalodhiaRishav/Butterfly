<template>
    <div>
    <b-dropdown :id=id :text="label" ref="dropdown" class="m-2" v-if="showDropDown">
      <b-dropdown-form>
        <b-form-checkbox-group
         :value="value"
         @input="$emit('input', $event)"
         stacked>
            <b-form-checkbox v-for="checkBoxOption in checkBoxOptions"  :key="checkBoxOption" :value="checkBoxOption">{{checkBoxOption}}</b-form-checkbox>
        </b-form-checkbox-group>
      </b-dropdown-form>
    </b-dropdown>
    </div>
</template>

<script>
import httpClient from "./../utils/httpRequestWrapper"
export default {
    mounted(){
         this.fetchDataToFillDropDown(this.dataSource);
    },
    props:{
        id:{
            type:String,
            required:true
        },
        label:{
            type:String,
            default:"DropDownTitle"
        },
        value:{
            default:null
        },
        dataSource:{
            type:String,
        },
    },
     data(){
        return{
            showDropDown:false,
            checkBoxOptions:[],
        }
    },
     methods: {
      onClick() {
        this.$refs.dropdown.hide(true)
      },
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
            this.checkBoxOptions = response.data.data;
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
}
</script>

<style scoped>

</style>