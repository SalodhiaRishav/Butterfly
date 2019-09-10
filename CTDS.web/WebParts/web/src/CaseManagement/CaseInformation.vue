<template>
  <div>
    <div role="tablist">
      <b-card no-body>
        <div class="componentHeader">
          <b-card-header
            header-tag="header"
            :header="labels.caseInformation"
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
                :label="labels.description"
                label-for="descriptionInput"
              >
                <b-form-textarea
                  id="descriptionInput"
                  v-model="caseInformation.description"
                ></b-form-textarea>
              </b-form-group>
              <b-form-group
                id="messageFromClient"
                :label="labels.messageFromClient"
                label-for="messageFromClientInput"
              >
                <b-form-textarea
                  id="messageFromClientInput"
                  v-model="caseInformation.messageFromClient"
                ></b-form-textarea>
              </b-form-group>
              <div v-if="priorityFetched">
                <b-form-group
                  id="priority"
                  :label="labels.priority"
                  label-for="priorityInput"
                >
                  <b-form-select
                    id="priorityInput"
                    v-model="caseInformation.priority"
                    :options="priorities"
                  ></b-form-select>
                </b-form-group>
              </div>
            </b-form>
          </b-card-body>
        </b-collapse>
      </b-card>
    </div>
  </div>
</template>

<script>
import httpClient from "./../utils/httpRequestWrapper";

export default {
  props: ["labels"],
  mounted() {
    this.getPriorityTypes();
  },
  data() {
    return {
      priorities: [],
      priorityFetched: false,
      caseInformation: this.$store.getters.caseInformation
    };
  },
  methods: {
    getPriorityTypes: function() {
      const resource = "/prioritytypes";
      httpClient
        .get(resource)
        .then(response => {
          if (response.data === "token refreshed") {
            this.getPriorityTypes();
            return;
          }
          if (response.data.success === true) {
            this.priorities = response.data.data;
            this.priorityFetched = true;
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
