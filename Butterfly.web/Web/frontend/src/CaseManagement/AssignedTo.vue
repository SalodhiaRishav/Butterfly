<template>
  <div role="tablist">
    <b-card no-body>
      <div class="componentHeader">
        <b-card-header
          header-tag="header"
          header="Assigned to"
          header-text-variant="white"
          v-b-toggle.accordion-assignedTo
          class="p-1"
          role="tab"
        >
        </b-card-header>
      </div>

      <b-collapse id="accordion-assignedTo" visible role="tabpanel">
        <b-card-body class="componentCard">
          <b-form>
            <b-form-group
              id="organizationalUnit"
              label="Organizational unit"
              label-for="organizationalUnitInput"
            >
              <b-form-select
                id="organizationalUnitInput"
                v-model="assignedToCpaForm.organizationalUnit"
                :options="organizationalUnits"
                required
              ></b-form-select>
            </b-form-group>
            <b-form-group
              id="assignedToCpa"
              label="Assigned to CPA"
              label-for="assignedToCpaInput"
            >
              <b-form-select
                id="assignedToCpaInput"
                v-model="assignedToCpaForm.cpa"
                :options="cpas"
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
      assignedToCpaForm: this.$store.getters.assignedToCpaForm
    };
  },
  computed: {
    organizationalUnits: () => {
      return [
        { text: "Select organizational unit", value: null },
        "KGHCS",
        "ABCD",
        "EFGH"
      ];
    },
    cpas: () => {
      return [{ text: "Select CPA", value: null }, "ABDC", "EFGH", "JKLM"];
    }
  }
};
</script>
