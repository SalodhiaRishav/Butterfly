<template>
  <div
    v-b-tooltip.hover
    :title="tooltipTitle"
    class="box"
    :class="boxColorClass"
  >
    <div class="row">
      <div class="col-3">
        <div class="tileCounter">{{ counter }}</div>
        <div class="tileTitle">{{ title }}</div>
      </div>
      <div class="col-9 chartDiv">
        <div>
          <line-chart
            :width="100"
            :height="100"
            :data="chartData"
            :options="chartOptions"
          ></line-chart>
        </div>
        <div class="chartTitle">{{ chartTitle }}</div>
      </div>
    </div>
  </div>
</template>

<script>
import LineChart from "./LineChart.js";

export default {
  computed: {
    boxColorClass: function() {
      return "box-" + this.boxColor;
    }
  },
  data: () => {
    return {
      chartOptions: {
        maintainAspectRatio: false,
        legend: {
          display: false
        },
        scales: {
          yAxes: [
            {
              ticks: {
                fontColor: "rgba(0,0,0,0.5)",
                beginAtZero: true,
                maxTicksLimit: 3,
                padding: 0.5,
                display: false
              },
              gridLines: {
                scaleShowLabels: false,
                drawBorder: false,
                drawTicks: false,
                display: false
              }
            }
          ],
          xAxes: [
            {
              gridLines: {
                drawBorder: false,
                drawTicks: false,
                display: false
              },
              ticks: {
                padding: 2,
                fontColor: "rgba(0,0,0,0.5)",
                maxTicksLimit: 7
              }
            }
          ]
        }
      }
    };
  },
  components: {
    LineChart
  },
  props: {
    boxColor: {
      type: String,
      default: "blue"
    },
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
  }
};
</script>

<style scoped>
@import url("./styles/tileStyle.css");
</style>
