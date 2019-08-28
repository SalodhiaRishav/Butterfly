<template>
  <div role="tablist">
    <b-card no-body>
      <div class="componentHeader">
        <b-card-header
          header-tag="header"
          header="Case Status"
          header-text-variant="white"
          v-b-toggle.accordion-caseStatus
          class="p-1"
          role="tab"
        >
        </b-card-header>
      </div>
      <b-collapse id="accordion-caseStatus" visible role="tabpanel">
        <b-card-body class="componentCard">
          <b-form>
            <b-form-group
              id="status"
              label="Status"
              label-for="statusInput"
              v-if="statusTypesFetched"
            >
              <b-form-select
                id="statusInput"
                v-model="statusForm.status"
                :options="statusTypes"
                required
              ></b-form-select>
            </b-form-group>
          </b-form>
        </b-card-body>
      </b-collapse>
    </b-card>
  </div>
</template>

<script>
import httpClient from "./../Utils/HttpRequestWrapper";

export default {
  mounted() {
    this.getCaseStatusTypes();
  },
  data() {
    return {
      statusTypes: [],
      statusTypesFetched: false,
      statusForm: this.$store.getters.statusForm
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
