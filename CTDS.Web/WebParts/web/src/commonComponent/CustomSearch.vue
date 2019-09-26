<template>
    <div>
        <div class="row">
            <div class="col-4">
    <b-form-group label="Filters">
      <b-form-checkbox-group id="checkboxGroup" @input="onCheckBoxInput" v-model="selectedSearchOptions" name="searchOptions" stacked>
        <b-form-checkbox v-for="searchObject in searchObjects"  :key="searchObject.title" :value="searchObject.title">{{searchObject.props.label}}</b-form-checkbox>
      </b-form-checkbox-group>
                <button @click="showData">ShowData</button> 
    </b-form-group>
            </div>
            <div class="col-8">
                <div v-for="searchObject in searchObjects" :key="searchObject.title">
                 <component :is="searchObject.type" v-model="searchObject.value" v-bind="searchObject.props" v-if="searchObject.show"></component>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import CustomTextBox from "./CustomTextBox";
import CustomDropDown from "./CustomDropDown";
import SearchObjects from "./CustomSearchObject.js";

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
        appCustomDropDown:CustomDropDown
    },
    data(){
        return {
            value:"hello",
            name:null,
            status:null,
            selectedSearchOptions:[],
            searchObjects:SearchObjects,
            searchForm:{
                name:"",
                status:"",
                priority:""
            }
        }
    }
}
</script>



