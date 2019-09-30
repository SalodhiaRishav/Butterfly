<template>
<div>
    <date-range-picker v-model="range" @input="showSomeDate" :options="options" />
</div>
    
</template>

<script>
export default {

  data () {
    return {
        range: [this.$moment().format('YYYY-MM-DD'), this.$moment().format('YYYY-MM-DD')],
        options: {
             ranges: {
            'Today': [this.$moment(), this.$moment()],
            'Yesterday': [this.$moment().subtract(1, 'days'), this.$moment().subtract(1, 'days')],
            'Last 7 Days': [this.$moment().subtract(6, 'days'), this.$moment()],
            'Last 30 Days': [this.$moment().subtract(29, 'days'), this.$moment()],
            'This Month': [this.$moment().startOf('month'), this.$moment().endOf('month')],
            'Last Month': [this.$moment().subtract(1, 'month').startOf('month'), this.$moment().subtract(1, 'month').endOf('month')]
            }
        }
    }
  },
  methods:{
      showSomeDate(){
          console.log(this.range);
      }
  }
};
</script>