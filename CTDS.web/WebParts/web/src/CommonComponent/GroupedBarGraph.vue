<template>
  <svg :width="svgWidth" :height="svgHeight">
    <text
      :x="titlePositionX"
      :y="titlePositionY"
      :fill="titleColor"
      transform="translate(100,50)"
      font-size="24px"
    >
      {{ chartTitle }}
    </text>
    <g class="chartbox" transform="translate(100,200)"></g>
    <g class="labelbox" transform="translate(150,150)"></g>
  </svg>
</template>
<script>
import * as d3 from "d3";
export default {
  props: {
    svgHeight: {
      type: Number,
      default: 600
    },
    svgWidth: {
      type: Number,
      default: 700
    },
    chartTitle: {
      type: String,
      default: "Graph"
    },
    titleColor: {
      type: String,
      default: "Gray"
    },
    chartData: {
      type: Object,
      default: {}
    },
    yAxisHeading: {
      type: String,
      default: "YAxisHeading"
    },
    xAxisHeading: {
      type: String,
      default: "XAxisHeading"
    }
  },
  computed: {
    height: function() {
      return this.svgHeight - this.margin;
    },
    width: function() {
      return this.svgWidth - this.margin;
    }
  },
  data: () => {
    return {
      yAxisHeadingFontColor: "Black",
      yAxisHeadingFontSize: 20,
      xAxisHeadingFontColor: "Black",
      xAxisHeadingFontSize: 20,
      titlePositionX: 50,
      titlePositionY: 50,
      margin: 300,
      barPadding: 0.3
    };
  },
  mounted() {
    this.createGraph();
  },
  methods: {
    createLabelBox(chartData) {
      const labelBoxObject = [];
      for (let index = 0; index < chartData.dataLabels.length; ++index) {
        const obj = {
          dataLabel: chartData.dataLabels[index],
          dataLabelColor: chartData.dataLabelColors[index]
        };
        labelBoxObject.push(obj);
      }
      var dataLabels = d3
        .select(".labelbox")
        .selectAll(".dataLabel")
        .data(labelBoxObject)
        .enter()
        .append("g")
        .attr("class", "dataLabel")
        .attr("transform", (d, i) => `translate(${i * 100},0)`);

      dataLabels
        .selectAll(`.colorBox`)
        .data(d => [d])
        .enter()
        .append("rect")
        .attr("class", ".colorBox")
        .attr("width", 10)
        .attr("height", 10)
        .attr("fill", d => {
          return d.dataLabelColor;
        });

      dataLabels
        .selectAll(`.labelText`)
        .data(d => [d])
        .enter()
        .append("text")
        .attr("class", ".labelText")
        .attr("dx", "1em")
        .attr("dy", "1em")
        .attr("fill", "black")
        .attr("font-size", 15)
        .text(d => {
          return d.dataLabel;
        });
    },
    createScales() {
      var xScale0 = d3
        .scaleBand()
        .range([0, this.width])
        .padding(this.barPadding);
      var xScale1 = d3.scaleBand();
      var yScale = d3.scaleLinear().range([this.height, 0]);
      xScale0.domain(this.chartData.labels);
      xScale1.domain(this.chartData.dataLabels).range([0, xScale0.bandwidth()]);
      yScale.domain([0, 100]);
      return { xScale0: xScale0, xScale1: xScale1, yScale: yScale };
    },
    createXAxis(xScale0) {
      var xAxis = d3.axisBottom(xScale0).tickSizeOuter(0); //todo learn outerticksize
      d3.select("g")
        .append("g")
        .attr("class", "xAxis")
        .attr("transform", `translate(0,${this.height})`)
        .call(xAxis)
        .selectAll("text")
        .style("font-size", 15)
        .style("font-weight", "bold")
        .style("fill", "gray");

      d3.select(".xAxis")
        .append("text")
        .attr("y", this.height - 250)
        .attr("x", this.width / 2)
        .attr("text-anchor", "end")
        .text(this.xAxisHeading)
        .attr("fill", this.xAxisHeadingFontColor)
        .attr("font-size", this.xAxisHeadingFontSize);
    },
    createYAxis(yScale) {
      var yAxis = d3
        .axisLeft(yScale)
        .ticks(10)
        .tickSizeOuter(0); //todo outerticksize
      d3.select("g")
        .append("g")
        .attr("class", "yAxis")
        .call(yAxis)
        .append("text")
        .attr("transform", "rotate(-90)")
        .attr("y", 6)
        .attr("dy", "-3.1em")
        .attr("dx", "-5em")
        .attr("text-anchor", "end")
        .attr("fill", this.yAxisHeadingFontColor)
        .attr("font-size", this.yAxisHeadingFontSize)
        .text(this.yAxisHeading);
    },
    createBars(chartData, scales) {
      var label = d3
        .select("g")
        .selectAll(".label")
        .data(chartData.labels)
        .enter()
        .append("g")
        .attr("class", "label")
        .attr("transform", d => `translate(${scales.xScale0(d)},0)`);

      const arr = this.chartData.dataLabels;
      for (let i = 0; i < arr.length; ++i) {
        label
          .selectAll(`.bar.${arr[i]}`)
          .data(d => [d])
          .enter()
          .append("rect")
          .attr("class", `bar ${arr[i]}`)
          .style("fill", this.chartData.dataLabelColors[i])
          .attr("x", d => scales.xScale1(arr[i]))
          .attr("y", d => {
            const index = this.chartData.labels.indexOf(d);
            return scales.yScale(this.chartData.data[index][i]);
          })
          .attr("width", scales.xScale1.bandwidth())
          .attr("height", d => {
            const index = this.chartData.labels.indexOf(d);
            return this.height - scales.yScale(this.chartData.data[index][i]);
          });
      }
    },
    createGraph() {
      this.createLabelBox(this.chartData);
      const scales = this.createScales();
      this.createXAxis(scales.xScale0);
      this.createYAxis(scales.yScale);
      this.createBars(this.chartData, scales);
    }
  }
};
</script>

<style scoped>
@import url("./styles/groupedBarGraphStyle.css");
</style>
