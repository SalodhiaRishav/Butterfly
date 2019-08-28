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
import httpClient from "./../Utils/HttpRequestWrapper";

export default {
  props: ["defaultValue"],
  mounted() {
    this.getCaseStatusTypes();
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
      const resource = "/statustypes";
      httpClient
        .get(resource)
        .then(response => {
          if (response.data === "token refreshed") {
            this.getCaseStatusTypes();
            return;
          }
          if (response.data.success === true) {
            this.statusTypes = response.data.data;
            this.statusTypesFetched = true;
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
