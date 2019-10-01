<template>
    <div>
        <div class="row customSearchHeadingRow">
            Advance Search
        </div>
        <div class="row customSearchBody">
            <div class="col-md-2 col-sm-6">
               <b-dropdown id="filterDropDown" text="Filter" ref="dropdown" class="m-3">
                <b-dropdown-form>
                    <b-form-checkbox-group
                    id="filterCheckBoxGroup"
                     @input="onCheckBoxInput"
                    v-model="selectedSearchOptions"
                    stacked>
                        <b-form-checkbox  ref="filterCheckBox" v-for="searchObject in searchObjects" v-model="searchObject.selected" :key="searchObject.title" :value="searchObject.title">{{searchObject.props.label}}</b-form-checkbox>
                    </b-form-checkbox-group>
                </b-dropdown-form>
                </b-dropdown>
                 <button @click="applyFilter">Apply Filters</button> 
                  <button @click="clearFilters">Clear Filters</button> 
            </div>
            <div class="col-md-10 col-sm-6">
                <div class="row customSearchComponentRow">
                <div class="col-md-2 col-sm-4 col-xs-12" v-for="filterElement in filterElements" :key="filterElement.title">
                 <component :is="filterElement.type" v-model="filterElement.value" v-bind="filterElement.props"></component>
                </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import CustomTextBox from "./CustomTextBox";
import CustomDropDown from "./CustomDropDown";
import CustomMultiSelectDropDown from "./CustomMultiSelectDropDown";
import CustomDateRangePicker from "./CustomDateRangePicker";

export default {
      components:{
        appCustomTextBox:CustomTextBox,
        appCustomDropDown:CustomDropDown,
        appCustomMultiSelectDropDown:CustomMultiSelectDropDown,
        appCustomDateRangePicker:CustomDateRangePicker
    },
    props:{
        searchObjects:{
            type:Array,
            default:[]
        },
    },
     data(){
        return {
            selectedSearchOptions:[],
            resultCount:0,
            filterElements:[]
        }
    },
    methods:{
        clearFilters(){
            this.filterElements=[];
            this.applyFilter();
        },
        onCheckBoxInput(){

            for(let index=0;index<this.filterElements.length;++index)
            {
                let isFound=this.selectedSearchOptions.indexOf(this.filterElements[index].title);
                if(isFound === -1)
                {
                   this.filterElements.splice(index,1);
                }   
            }

            for(let index =0;index<this.selectedSearchOptions.length;++index)
            {
                let isElementFoundInFilterElements=false;
                for(let j=0;j<this.filterElements.length;++j)
                {
                    if(this.filterElements[j].title === this.selectedSearchOptions[index])
                    {
                        isElementFoundInFilterElements=true;
                        break;
                    }
                }

                if(isElementFoundInFilterElements === false)
                {
                    for(let j=0;j<this.searchObjects.length;++j)
                    {
                        if(this.searchObjects[j].title === this.selectedSearchOptions[index])
                        {
                            this.filterElements.push(this.searchObjects[j]);
                            break;
                        }
                    }
                }
            }
            
        },
        applyFilter(){
            let filters=[];
            for(let ind=0;ind<this.filterElements.length;++ind)
            {
                const filter={
                    "property":this.filterElements[ind].title,
                    "values":this.filterElements[ind].value,
                    "ValueDataType":this.filterElements[ind].dataType
                }
                filters.push(filter);
            }
            this.$emit("applyFilter",filters);
        }
    },
  
   
}
</script>

<style scoped>
@import url("./styles/customSearchStyle.css");
</style>


