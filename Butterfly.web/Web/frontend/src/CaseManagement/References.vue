<template>
  <div role="tablist">
    <b-card no-body>
      <div class="componentHeader">
        <b-card-header
          header-tag="header"
          header="References"
          header-text-variant="white"
          v-b-toggle.accordion-references
          class="p-1"
          role="tab"
        >
        </b-card-header>
      </div>
      <b-collapse id="accordion-references" visible role="tabpanel">
        <b-card-body class="componentCard">
          <b-table fixed striped hover :items="references" :fields="fields">
            <template slot="#" slot-scope="data">
              <button @click="deleteReference(data.index)">Delete</button>
            </template>
          </b-table>
          <b-table fixed :fields="fields">
            <template slot="HEAD_identity" slot-scope="data">
              <b-form-input
                id="identityInput"
                :placeholder="data.label"
                v-model="referenceForm.identity"
              ></b-form-input>
            </template>
            <template slot="HEAD_type" v-if="referenceTypesFetched">
              <b-form-select
                id="referenceTypeInput"
                :options="referenceTypes"
                v-model="referenceForm.type"
              ></b-form-select>
            </template>
            <template slot="HEAD_comment" slot-scope="data">
              <b-form-input
                id="commentInput"
                :placeholder="data.label"
                v-model="referenceForm.comment"
              ></b-form-input>
            </template>
            <template slot="HEAD_#">
              {{&nbsp;}}
            </template>
          </b-table>
          <b-button @click="addNewReference">Add</b-button>
        </b-card-body>
      </b-collapse>
    </b-card>
  </div>
</template>

<script>
import httpClient from "./../Utils/HttpRequestWrapper";

export default {
  mounted() {
    this.getCaseReferenceTypes();
  },
  data() {
    return {
      referenceTypes: [],
      referenceTypesFetched: false,
      showReferenceForm: false,
      fields: ["type", "identity", "comment", "#"],
      references: this.$store.getters.references,
      referenceForm: {
        type: null,
        identity: "",
        comment: ""
      }
    };
  },
  methods: {
    getCaseReferenceTypes: function() {
        const resource = "/referencetypes";
        httpClient
          .get(resource)
          .then(response => {
            if(response.data === "token refreshed")
            {
              this.getCaseReferenceTypes();
              return;
            }
            if (response.data.success === true) {
              this.referenceTypes = response.data.data;
              this.referenceTypesFetched = true;
            } else {
              alert(response.data.message);
            }
          })
          .catch(error => {
            alert(error);
          });
    },
    deleteReference(index) {
      this.references.splice(index, 1);
    },
    resetReferenceForm: function() {
      this.referenceForm.type = null;
      this.referenceForm.identity = "";
      this.referenceForm.comment = "";
    },
    addNewReference: function() {
      this.showReferenceForm = true;
      if (
        this.referenceForm.type !== null &&
        this.referenceForm.identity !== "" &&
        this.referenceForm.comment !== ""
      ) {
        const newReferenceDetails = {
          type: this.referenceForm.type,
          identity: this.referenceForm.identity,
          comment: this.referenceForm.comment
        };
        if (!this.$store.getters.references) {
          this.$store.dispatch("setReferences", []);
          this.references = this.$store.getters.references;
        }
        console.log(this.references);
        this.references.push(newReferenceDetails);
        this.resetReferenceForm();
      }
    }
  }
};
</script>
