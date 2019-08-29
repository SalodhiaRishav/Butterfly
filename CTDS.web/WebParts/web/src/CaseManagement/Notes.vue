<template>
  <div role="tablist">
    <b-card no-body>
      <div class="componentHeader">
        <b-card-header
          header-tag="header"
          header="Notes"
          header-text-variant="white"
          v-b-toggle.accordion-notes
          class="p-1"
          role="tab"
        >
        </b-card-header>
      </div>
      <b-collapse id="accordion-notes" visible role="tabpanel">
        <b-card-body class="componentCard">
          <b-form>
            <b-form-group
              id="notesByCpa"
              label="Notes by CPA"
              label-for="notesByCpaInput"
            >
              <b-form-textarea
                id="notesByCpaInput"
                v-model="notes.notesByCpa"
              ></b-form-textarea>
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
      notes: this.$store.getters.notes
    };
  }
};
</script>
