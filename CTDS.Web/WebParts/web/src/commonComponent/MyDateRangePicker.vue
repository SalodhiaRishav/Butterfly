<template>
  <div>
    <date-range-picker
      :value="value"
      @input="onDateRangeSelected"
      :options="options"
      class="myCustomDateRangePicker"
    />
  </div>
</template>

<script>
export default {
  props: {
    value: {
      default: null
    }
  },
  data() {
    return {
      options: {
        startDate: this.value[0],
        endDate: this.value[1],
        maxDate: this.$moment(),
        minDate: this.$moment()
          .subtract(10, "year")
          .startOf("year"),
        ranges: {
          Today: [this.$moment(), this.$moment()],
          Yesterday: [
            this.$moment().subtract(1, "days"),
            this.$moment().subtract(1, "days")
          ],
          "Last 7 Days": [this.$moment().subtract(6, "days"), this.$moment()],
          "Last 30 Days": [this.$moment().subtract(29, "days"), this.$moment()],
          "This Month": [this.$moment().startOf("month"), this.$moment()],
          "Last Month": [
            this.$moment()
              .subtract(1, "month")
              .startOf("month"),
            this.$moment()
              .subtract(1, "month")
              .endOf("month")
          ]
        }
      }
    };
  },
  methods: {
    onDateRangeSelected(range) {
      this.$emit("input", range);
    }
  }
};
</script>

<style scoped>
@import url("./styles/dashboard2.css");
</style>
