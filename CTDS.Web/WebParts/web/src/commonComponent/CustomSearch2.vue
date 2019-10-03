<template>
    <div id="customAdvanceSearchElement">
         <b-button id="show-btn" @click="$bvModal.show('bv-modal-example')">Show Advance Search</b-button>
         <b-modal size="xl" id="bv-modal-example">
              <template v-slot:modal-title>
               <div class="row customSearchHeadingRow">
                    Advance Search
               </div>
              </template>
          <template v-slot:default>
              <div class="row customSearchBody">
            <div class="col-md-3 col-sm-6">
                <div class="filterDropDown">
                    <div class="label">
                        Filters
                    </div>
                    <b-dropdown text="Filter" ref="dropdown">
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
                </div>
            </div>
            <div class="col-md-9 col-sm-6">
                <div class="row customSearchComponentRow">
                    <div class="col-md-4 col-sm-6 col-xs-12" v-for="filterElement in filterElements" :key="filterElement.title">
                    <component :is="filterElement.type" v-model="filterElement.value" v-bind="filterElement.props"></component>
                    </div>
                </div>
            </div>
              </div>
        </template>
         <template v-slot:modal-footer="{hide }">
                <div class="row buttonsRow">
                        <button class="btn btn-primary filterButton" @click="applyFilter">Apply</button> 
                        <button class="btn btn-danger filterButton" @click="clearFilters">Clear</button> 
                        <button class="btn btn-normal filterButton" @click="hide('Close')">Close</button> 
                </div>
       </template>
         </b-modal>
        </div>
</template>

<script>
import CustomTextBox from "./CustomTextBox";
import CustomDropDown from "./CustomDropDown";
import CustomMultiSelectDropDown from "./CustomMultiSelectDropDown";
import CustomDateRangePicker from "./CustomDateRangePicker";
// import CustomSearchObject from "./CustomSearchObject.js";

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
            filterElements:[],
            // searchObjects:CustomSearchObject
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
@import url("./styles/customSearch2Style.css");
</style>


