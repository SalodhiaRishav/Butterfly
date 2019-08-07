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
import axios from "axios";

export default {
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
      statusForm: this.$store.getters.statusForm
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
