<template>
  <div>
    <appGroupedBarGraph
      chartTitle="Declarations"
      xAxisHeading="Years"
      yAxisHeading="Percentage"
      :chartData="chartData"
    ></appGroupedBarGraph>
  </div>
</template>

<script>
import GroupedBarGraph from "./GroupedBarGraph";
export default {
  components: {
    appGroupedBarGraph: GroupedBarGraph
  },
  data() {
    return {
      chartData: {
        labels: ["In Process", "Closed", "New"],
        dataLabels: ["High", "Medium", "Low"],
        dataLabelColors: ["Red", "Blue", "Green"],
        data: [[11, 42, 53], [12, 53, 43], [22, 0, 93]]
      }
    };
  }
};
</script>
