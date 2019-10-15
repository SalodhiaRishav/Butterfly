<template>
  <div class="chip">
    {{ text }}
    <span class="closebtn" @click="$emit('click', $event)">&times;</span>
  </div>
</template>

<script>
export default {
  props: {
    text: {
      type: String,
      default: ""
    }
  }
};
</script>

<style scoped>
@import url("./styles/customChipStyle.css");
</style>
