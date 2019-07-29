<template>
  <div>
    <div role="tablist">
      <b-card no-body>
        <div class="componentHeader">
          <b-card-header
            header-tag="header"
            header="Case Information"
            header-text-variant="white"
            v-b-toggle.accordion-caseInfomation
            class="p-1"
            role="tab"
          >
          </b-card-header>
        </div>
        <b-collapse id="accordion-caseInfomation" visible role="tabpanel">
          <b-card-body class="componentCard">
            <b-form>
              <b-form-group
                id="description"
                label="Description"
                label-for="descriptionInput"
              >
                <b-form-textarea
                  id="descriptionInput"
                  v-model="caseInformation.description"
                ></b-form-textarea>
              </b-form-group>
              <b-form-group
                id="messageFromClient"
                label="Messsage from client"
                label-for="messageFromClientInput"
              >
                <b-form-textarea
                  id="messageFromClientInput"
                  v-model="caseInformation.messageFromClient"
                ></b-form-textarea>
              </b-form-group>
              <b-form-group
                id="priority"
                label="Priority"
                label-for="priorityInput"
              >
                <b-form-select
                  id="priorityInput"
                  v-model="caseInformation.priority"
                  :options="priorities"
                ></b-form-select>
              </b-form-group>
            </b-form>
          </b-card-body>
        </b-collapse>
      </b-card>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      caseInformation: this.$store.getters.caseInformation
    };
  },
  computed: {
    priorities: () => {
      return [
        { text: "Select priority", value: null },
        "High",
        "Medium",
        "Low"
      ];
    }
  }
};
</script>
