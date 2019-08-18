<template>
  <div>
    <b-form>
      <b-form-select
        id="statusInput"
        v-model="statusForm.status"
        :options="statusTypes"
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
    this.getCaseStatusTypes().then(response => {
      this.statusTypes = response;
      this.statusTypesFetched = true;
    });
  },
  data() {
    return {
      statusTypes: [],
      statusTypesFetched: false,
      statusForm: { status: this.defaultValue }
    };
  },
  methods: {
    getCaseStatusTypes: function() {
      return new Promise((resolve, reject) => {
        const url = "https://localhost:44313/statustypes";
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
