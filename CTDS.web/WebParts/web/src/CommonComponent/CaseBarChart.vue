<template>
  <div class="container">
    <appBarChart
      v-if="loaded"
      :chartdata="chartdata"
      :options="options"
      :width="300"
      :height="300"
    ></appBarChart>
  </div>
</template>

<script>
import BarChart from "./BarChart.vue";

export default {
  components: {
    appBarChart: BarChart
  },
  data: () => ({
    loaded: false,
    chartdata: null,
    options: null
  }),
  mounted() {
    this.createGroupedBarChartData().then(response => {
      this.chartdata = response.chartdata;
      this.options = response.options;
      this.loaded = true;
    });
  },
  computed: {
    myStyles() {
      return {
        height: `700px`
      };
    }
  },
  methods: {
    createGroupedBarChartData() {
      return new Promise((resolve, rejects) => {
        const barChartData = {
          labels: ["InProgress", "Closed"],
          datasets: [
            {
              label: "Low",
              backgroundColor: "pink",
              borderColor: "red",
              borderWidth: 1,
              data: [3, 5]
            },
            {
              label: "Medium",
              backgroundColor: "lightblue",
              borderColor: "blue",
              borderWidth: 1,
              data: [4, 7]
            },
            {
              label: "High",
              backgroundColor: "lightgreen",
              borderColor: "green",
              borderWidth: 1,
              data: [10, 7]
            }
          ]
        };

        const chartOptions = {
          maintainAspectRatio: false,
          legend: {
            position: "top"
          },
          title: {
            display: true,
            text: "Grouped Bar Chart"
          },
          scales: {
            yAxes: [
              {
                ticks: {
                  beginAtZero: true
                }
              }
            ]
          }
        };
        resolve({ chartdata: barChartData, options: chartOptions });
      });
    }
  }
};
</script>
