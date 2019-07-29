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
            <b-form-group id="status" label="Status" label-for="statusInput">
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
export default {
  data() {
    return {
      statusForm: this.$store.getters.statusForm
    };
  },
  computed: {
    statusTypes: () => {
      const statusTypes = [
        { text: "Select Status", value: null },

        "New",
        "In progress",
        "Closed"
      ];
      return statusTypes;
    }
  }
};
</script>
