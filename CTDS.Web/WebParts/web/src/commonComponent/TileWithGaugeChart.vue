<template>
  <div
    class="box"
    :class="boxColorClass"
    @click="tileClicked"
  >
    <div class="row">
      <div class="col-5">
        <div class="tileCounter">{{ counter }}</div>
        <div class="tileTitle">{{ title }}</div>
      </div>
      <div class="col-7 chartDiv">
        <div>
          <pie-chart
            :width="100"
            :height="100"
            :data="chartData"
            :options="chartOptions"
          ></pie-chart>
        </div>
        <div class="chartTitle">{{ chartTitle }}</div>
      </div>
    </div>
  </div>
</template>

<script>
import PieChart from "./PieChart.js";

export default {
  components: {
    PieChart
  },
  props: {
    chartData: {
      type: Object
    },
    tooltipTitle: {
      type: String,
      default: "Tooltip title"
    },
    counter: {
      type: Number,
      default: 0
    },
    title: {
      type: String,
      default: "Title"
    },
    chartTitle: {
      type: String,
      default: "Chart Title"
    }
  },
  data: () => {
    return {
      chartOptions: {
        maintainAspectRatio: false,
        legend: {
          display: false
        },
        circumference: 1 * Math.PI,
        rotation: 1 * Math.PI,
        cutoutPercentage: 55
      }
    };
  },
  methods: {
    tileClicked() {
      this.$emit("tileClicked", "true");
    }
  }
};
</script>

<style scoped>
@import url("./styles/tileStyle.css");
</style>
