<template>
  <svg :width="svgWidth" :height="svgHeight"> 
    <text :x="titlePositionX" :y="titlePositionY" :fill="titleColor" transform="translate(100,0)" font-size="24px">{{chartTitle}}</text>
    <g v-if="flag" transform = "translate(100,100)">
    </g>
  </svg>
</template>

<script>
import * as d3 from 'd3';

export default {
    props:{
        svgHeight : {
        type: Number,
        default: 500
        },
        svgWidth : {
        type: Number,
        default: 600
        },
        chartTitle : {
        type: String,
        default: "Graph"
        },
        titleColor : {
        type: String,
        default: "Gray"
        },
        chartData : {
            type:Array,
        },
        yAxisHeading : {
            type:String,
            default:"YAxisHeading"
        },
        xAxisHeading : {
            type:String,
            default:"XAxisHeading"
        },
    },
  computed : {
      width:function(){
          return this.svgWidth-this.margin;
      },
      height:function(){
          return this.svgHeight-this.margin;
      }
  },
  data() {
    return {
      titlePositionY:50,
      titlePositionX:50,
      margin:200,
      xAxisHeadingFontSize:16,
      xAxisHeadingFontColor:"Black",
      yAxisHeadingFontSize:16,
      yAxisHeadingFontColor:"Black",
      flag:false,
      yAxisScale:0,
    };
  },
  mounted() {
    this.flag=true;
     this.createBarGraph(this.chartData);
      },
 watch:{
    chartData:{
      handler(val){
        this.flag=true;
        this.createBarGraph(val);
      },
       deep:true,
    },  
  },
  methods: {
   createScales(data){
       const xScale = d3.scaleBand().range([0, this.width]).padding(0.6);
       const yScale = d3.scaleLinear().range([this.height, 0]);
       xScale.domain(data.map(function(d) { return d.label; }));
       yScale.domain([0, this.yAxisScale]);
       return {xScale:xScale,yScale:yScale}
   },
   createXAxis(xScale,xAxisHeading)
   {
       var g = d3.select("g");
        g.append("g")
         .attr("class","xAxis")
         .attr("transform", "translate(0," + this.height + ")")
         .call(d3.axisBottom(xScale))
         .selectAll("text")
            .style("font-size", 15)
            .style("font-weight", "bold")
            .style("fill", "gray")

         d3.select(".xAxis")
         .append("text")
         .attr("y", this.height - 250)
         .attr("x", this.width/2)
         .attr("text-anchor", "end")
         .text(this.xAxisHeading)
         .attr("fill",this.xAxisHeadingFontColor)
         .attr("font-size",this.xAxisHeadingFontSize);
   },
   createYAxis(yScale,yAxisHeading){
        var g = d3.select("g");
        g.append("g")
         .call(d3.axisLeft(yScale).tickFormat(function(d){
             return  d;
         })
         .ticks(this.yAxisScale))
         .append("text")
         .attr("transform", "rotate(-90)")
         .attr("y", 6)
         .attr("dy", "-3.1em")
         .attr("dx", "-5em")
         .attr("text-anchor", "end")
         .attr("fill", this.yAxisHeadingFontColor)
         .attr("font-size",this.yAxisHeadingFontSize)
         .text(this.yAxisHeading);
   },
   createBars(data,scales,height){
       var g = d3.select("g");
       g.selectAll(".bar")
         .data(data)
         .enter().append("rect")
         .attr("fill",function(d) { return d.barColor; })
         .attr("class","bar")
         .attr("x", function(d) { return scales.xScale(d.label); })
         .attr("y", function(d) { return scales.yScale(d.value); })
         .attr("width", scales.xScale.bandwidth())
         .attr("height",function(d){return (height - scales.yScale(d.value));} );
   },
   createBarGraph(data){
     var valueArray = data.map(x => {return x.value});
     this.yAxisScale = d3.max(valueArray) + 2;
      const scales=this.createScales(data);
      this.createXAxis(scales.xScale,this.xAxisHeading);
      this.createYAxis(scales.yScale,this.yAxisHeading);
      this.createBars(data,scales,this.height);
   }
  }
};
</script>

<style scoped>
@import url("./styles/barGraphStyle.css");     
 </style>