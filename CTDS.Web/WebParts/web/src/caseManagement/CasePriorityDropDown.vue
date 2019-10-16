<template>
  <div>
    <b-form>
      <div class="myCustomSelect">
        <b-form-select
          id="priorityInput"
          v-model="priorityForm.priority"
          :options="priorityTypes"
          required
        ></b-form-select>
      </div>
    </b-form>
  </div>
</template>

<script>
import httpClient from "./../utils/httpRequestWrapper";

export default {
  props: ["defaultValue"],
   data() {
    return {
      priorityTypes: [],
      priorityTypesFetched: false,
      priorityForm: { priority: this.defaultValue }
    };
  },
  mounted() {
    this.getCasePriorityTypes();
  },
  methods: {
    getCasePriorityTypes: function() {
      const resource = "/prioritytypes";
      httpClient
        .get(resource)
        .then(response => {
          if (response.data === "token refreshed") {
            this.getPriorityTypes();
            return;
          }
          if (response.data.success === true) {
            this.priorityTypes = response.data.data;
            this.priorityTypesFetched = true;
          } else {
            alert(response.data.message);
          }
        })
        .catch(error => {
          alert(error);
        });
    }
  }
};
</script>

<style scoped>
@import url("./styles/casePriorityDropDownStyle.css");
</style>
