<template>
  <div>
    <b-form>
      <b-form-select
        id="priorityInput"
        v-model="priorityForm.priority"
        :options="priorityTypes"
        required
      ></b-form-select>
    </b-form>
  </div>
</template>

<script>
import axios from "axios";

export default {
  props: ["defaultValue"],
  mounted() {
    this.getCasePriorityTypes().then(response => {
      this.priorityTypes = response;
      this.priorityTypesFetched = true;
    });
  },
  data() {
    return {
      priorityTypes: [],
      priorityTypesFetched: false,
      priorityForm: { priority: this.defaultValue }
    };
  },
  methods: {
    getCasePriorityTypes: function() {
      return new Promise((resolve, reject) => {
        const url = "https://localhost:44313/prioritytypes";
        axios
          .get(url)
          .then(response => {
            if (response.data.success === true) {
              resolve(response.data.data);
            } else {
              resolve(null);
            }
          })
          .catch(error => {
            reject(error);
          });
      });
    }
  }
};
</script>
