<template>
  <div>
    <div v-if="showTextBox">
      <b-form-group>
        <div class="label">{{ label }}</div>
        <b-form-input
          :id="id"
          :value="value"
          :placeholder="label"
          @input="$emit('input', $event)"
        ></b-form-input>
      </b-form-group>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    id: {
      type: String,
      required: true
    },
    label: {
      type: String,
      required: true
    },
    showTextBox: {
      type: Boolean,
      default: true
    },
    value: {
      default: null
    }
  }
};
</script>
