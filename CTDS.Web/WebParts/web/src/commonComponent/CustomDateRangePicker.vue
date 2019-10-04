<template>
<div>
  <div class="label">
      {{label}}
  </div>
    <date-range-picker
         :value="value"
                   @input="$emit('input', $event)"
                    :options="options" />
</div>
    
</template>

<script>
export default {
    props:{
        id:{
            type:String,
            required:true
        },
        label:{
            type:String,
            required:false
        },
        value:{
            default:null
        }
    },
  data () {
    return {
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
  }
};
</script>