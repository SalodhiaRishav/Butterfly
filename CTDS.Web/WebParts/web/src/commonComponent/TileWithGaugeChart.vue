<template>
           <div  v-b-tooltip.hover
            :title="tooltipTitle"
             class="box"
             :class="boxColorClass">
               <div class="row">
                   <div class="col-3">
                    <div class="tileCounter">{{counter}}</div>
                    <div class="tileTitle">{{title}}</div>
                   </div>
                   <div class="col-9 chartDiv">
                    <div> <line-chart :width="100" :height="100" :data="chartData" :options="chartOptions"></line-chart></div>
                    <div class="chartTitle">{{chartTitle}}</div>
                   </div>
               </div>
          </div>
          
</template>

<script>
import LineChart from "./PieChart.js";

export default {
    computed:{
        boxColorClass:function(){
            return "box-"+this.boxColor;
        }
    },
    data: () => {
        return {
       chartOptions: {
            maintainAspectRatio:false,
            legend: {
                display: false,
            },
            circumference: 1 * Math.PI,
            rotation: 1 * Math.PI,
            cutoutPercentage: 55
        },
      };
    },
    components:{
        LineChart
    },
    props:{
       boxColor:{
           type:String,
           default:"blue"
       } ,
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
       },
       chartTitle:{
           type:String,
           default:"Chart Title"
       }
    }
};
</script>

<style scoped>
@import url("./styles/tileStyle.css");
</style>
