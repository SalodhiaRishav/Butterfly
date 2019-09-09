<template>
 <div>
<appBarGraph chartTitle="Declarations" xAxisHeading="Years" yAxisHeading="Percentage" :chartData="chartData"></appBarGraph>
 </div>
</template>

<script>
import BarGraph from "./BarGraph";
export default {
    components:{
        appBarGraph:BarGraph
    },
  data() {
    return {
      chartData:[    
                {
                    "label": "In Processing",
                    "value": 53,
                    "barColor":"blue"
                },
                {
                    "label": "Cleared",
                    "value": 31,
                    "barColor":"green"
                },
                {
                    "label": "Rejected",
                    "value": 87,
                    "barColor":"red"
                },
            ]
    };
  },
};
</script>

<style scoped>
 </style>