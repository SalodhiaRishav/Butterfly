<template>
           <div
            v-b-tooltip.hover
            :title="tooltipTitle"
            class="box"
            :class="boxColorClass"
          >
              <span class="tileWithoutChartCounter">{{counter}}</span>
            <br />
            <div>
            <span class="tileWithoutChartTitle">{{title}}</span>
            </div>
          </div>
          
</template>

<script>

export default {
   computed:{
        boxColorClass:function(){
            return "box-"+this.boxColor;
        }
    },
    props:{
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
       boxColor:{
           type:String,
           default:"blue"
       }
    }
};
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css?family=Source+Sans+Pro:200,400,900&display=swap");
@import url("./styles/tileWithoutChartStyle.css");
</style>
