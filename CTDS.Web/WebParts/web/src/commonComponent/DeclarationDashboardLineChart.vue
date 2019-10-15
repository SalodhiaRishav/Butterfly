<template>
  <div>
    <div>
      <line-chart
        :height="390"
        :width="1400"
        :data="chartData"
        :options="chartOptions"
        v-if="dataFetched"
      ></line-chart>
    </div>
  </div>
</template>

<script>
import LineChart from "./LineChart.js";
import httpClient from "./../utils/httpRequestWrapper";

export default {
  components: {
    LineChart
  },
  props: {
    status: {
      type: String,
      required: true
    },
    startDate: {
      type: String,
      required: true
    },
    endDate: {
      type: String,
      required: true
    }
  },
  mounted() {
    this.getDeclarationsChartData();
  },
  data() {
    return {
      dataFetched: false,
      chartData: {},
      chartOptions: {
        animation: false,
        repsonsive: false,
        maintainAspectRatio: false,
        elements: {
          line: {
            tension: 0
          }
        },
        legend: {
          display: true,
          position: "top",
          labels: {
            boxWidth: 80,
            fontColor: "black"
          }
        },
        scales: {
          xAxes: [
            {
              gridLines: {
                display: false
              },
              type: "time"
            }
          ],
          yAxes: [
            {
              gridLines: {
                display: true
              },
              ticks: {
                beginAtZero: true
              },
              scaleLabel: {
                display: true,
                labelString: "Numbers Of Declaration Created",
                fontColor: "green"
              }
            }
          ]
        }
      }
    };
  },
  watch: {
    status: function(newvalue, oldvalue) {
      this.dataFetched = false;
      this.getDeclarationsChartData();
    },
    startDate: function(newvalue, oldvalue) {
      this.dataFetched = false;
      this.getDeclarationsChartData();
    },
    endDate: function(newvalue, oldvalue) {
      this.dataFetched = false;
      this.getDeclarationsChartData();
    }
  },
  methods: {
    convertDate(someDate) {
      return new Date(someDate.match(/\d+/)[0] * 1).toString();
    },
    getDeclarationsChartData() {
      const url = "/declarationchart";
      const postObject = {
        declarationStatus: this.status,
        startDate: this.startDate,
        endDate: this.endDate
      };
      httpClient
        .post(url, postObject)
        .then(response => {
          if(response.data ==="token refreshed")
          {
            this.getDeclarationsChartData();
            return;
          }
          if (response.data.success === true) {
            const caseData = response.data.data;
            let labelToShow = "";
            if (this.status === null) {
              labelToShow = "All" + " declarations";
            } else {
              labelToShow = this.status + " declarations";
            }
            let labels = [];
            let data = [];
            for (let i = 0; i < caseData.length; ++i) {
              const dateString = this.convertDate(caseData[i].date);
              labels.push(dateString);
              data.push(caseData[i].count);
            }
            (this.chartData = {
              labels: labels,
              datasets: [
                {
                  borderColor: "rgba(30, 63, 113,1)",
                  label: labelToShow,
                  data: data,
                  fill: false
                }
              ]
            }),
              (this.dataFetched = true);
          } else {
            console.log(response.data.message);
          }
        })
        .catch(error => {
          console.log(error);
        });
    }
  }
};
</script>
