<template>
        <div class="row">
        <appTileWithGaugeChart tooltipTitle="Total Cleared Declarations" :counter=4 title="Declaration"  :chartData="declarationInProcessChartData"></appTileWithGaugeChart>
<!-- <appTile tooltipTitle="Declarations" counter=4 title="Declarations" :chartOptions="chartOptions" :chartData="chartData"></appTile>
<appTile tooltipTitle="Declarations" counter=4 title="Declarations" :chartOptions="chartOptions" :chartData="chartData"></appTile>
<appTile tooltipTitle="Declarations" counter=4 title="Declarations" :chartOptions="chartOptions" :chartData="chartData"></appTile>
<appTile tooltipTitle="Declarations" counter=4 title="Declarations" :chartOptions="chartOptions" :chartData="chartData"></appTile> -->
        </div>
</template>

<script>
import Tile from "./Tile";
import TileWithGaugeChart from "./TileWithGaugeChart"

export default {
   components:{
       appTile:Tile,
       appTileWithGaugeChart:TileWithGaugeChart
   },
  data: () => {
    return {
     chartData: {
         labels: ['M', 'Tu', 'W', 'Th', 'F', 'Sa', 'Su'],
        datasets: [{
            borderColor: "#0000FF",
            pointBorderColor: "#0000FF",
            pointBackgroundColor: "#0000FF",
            pointHoverBackgroundColor: "#80b6f4",
            pointHoverBorderColor: "#80b6f4",
            pointBorderWidth: 6,
            pointHoverRadius: 10,
            pointHoverBorderWidth: 1,
            pointRadius: 1,
            fill: false,
            borderWidth: 2,
            data: [100, 120, 150, 170, 180, 170, 300]
        }]
    },
    chartOptions: {
         maintainAspectRatio:false,
        legend: {
            display: false,
        },
        scales: {
            yAxes: [{
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
             }],
            xAxes: [{
                gridLines: {
                    drawBorder: false,
                     drawTicks: false,
                    display: false
                },
                ticks: {
                    padding: 2,
                    fontColor: "rgba(0,0,0,0.5)",
                    maxTicksLimit: 7,
                }
            }]
        },
    }
    };
  }
};
</script>
