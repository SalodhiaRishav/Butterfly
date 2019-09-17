<template>
        <!-- <div
            v-b-tooltip.hover
            :title="tooltipTitle"
            class="col-sm-4 col-md-2 box box-blue margin-left-39"
          >
            <span class="heading">{{counter}}</span>
            <br />
            <div>
              <span class="counter">{{title}}</span>
            </div>
          </div> -->
           <div class="col-sm-4 col-md-2 box box-blue ">
               <div class="row">
                   <div class="col-3">
                    <div class="counter">{{counter}}</div>
                    <div class="title">{{title}}</div>
                   </div>
                   <div class="col-9 chartDiv">
                    <div> <line-chart :width="100" :height="100" :data="chartData" :options="chartOptions"></line-chart></div>
                   </div>
               </div>
          </div>
          
</template>

<script>
import LineChart from "./LineChart.js";

export default {
    components:{
        LineChart
    },
    props:{
      chartOptions:{
          type:Object,
      },
      chartData:{
          type:Object,
      },
      tooltipTitle: {
        type: String,
        default: "Tooltip title"
       },
       counter:{
           type:Number,
           default:0
       },
       title:{
           type:String,
           default:"Title"
       }
    }
};
</script>

<style scoped>
@import url("./styles/tileStyle.css");
</style>
