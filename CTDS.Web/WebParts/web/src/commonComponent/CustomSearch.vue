<template>
    <div style="height:800px">
        <div class="row customSearchHeadingRow">
            Advance Search
        </div>
        <div class="row customSearchBody">
            <div class="col-md-2 col-sm-6">
               <b-dropdown id="filterDropDown" text="Filter" ref="dropdown" class="m-3">
                <b-dropdown-form>
                    <b-form-checkbox-group
                    id="filterCheckboxGroup"
                     @input="onCheckBoxInput"
                    v-model="selectedSearchOptions"
                    stacked>
                        <b-form-checkbox v-for="searchObject in searchObjects"  :key="searchObject.title" :value="searchObject.title">{{searchObject.props.label}}</b-form-checkbox>
                    </b-form-checkbox-group>
                </b-dropdown-form>
                </b-dropdown>
                 <!-- <button @click="showData">ShowData</button>  -->
            </div>
            <div class="col-md-10 col-sm-6">
                <div class="row customSearchComponentRow">
                <div class="col-md-2 col-sm-4 col-xs-12" v-for="searchObject in searchObjects" :key="searchObject.title">
                 <component :is="searchObject.type" v-model="searchObject.value" v-bind="searchObject.props" v-if="searchObject.show"></component>
                </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import CustomTextBox from "./CustomTextBox";
import CustomDropDown from "./CustomDropDown";
import SearchObjects from "./CustomSearchObject.js";
import CustomMultiSelectDropDown from "./CustomMultiSelectDropDown";

export default {

    methods:{
        onCheckBoxInput(){
            let arr=[];
            for(let index = 0;index<this.searchObjects.length;++index)
            {
                let isFound=this.selectedSearchOptions.indexOf(this.searchObjects[index].title);
                if(isFound !== -1)
                {
                    this.searchObjects[index].show=true;
                }
                else
                {
                    if(this.searchObjects[index].valueType == Array)
                    {
                        this.searchObjects[index].value=[];
                    }
                    else if(this.searchObjects[index].valueType == String)
                    {
                        this.searchObjects[index].value="";
                    }
                    this.searchObjects[index].show=false;
                }
            }
        },
        showData(){
            for(let ind=0;ind<SearchObjects.length;++ind)
            {
                console.log(SearchObjects[ind].title+" "+SearchObjects[ind].value);
            }
        }
    },
    components:{
        appCustomTextBox:CustomTextBox,
        appCustomDropDown:CustomDropDown,
        appCustomMultiSelectDropDown:CustomMultiSelectDropDown
    },
    data(){
        return {
            searchObjects:SearchObjects,
            selectedSearchOptions:[]
        }
    }
}
</script>

<style scoped>
@import url("./styles/customSearchStyle.css");
</style>


