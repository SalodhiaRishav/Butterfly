<template>
  <div>
    <div>
      <b-table
        striped
        hover
        :fields="fields"
        :items="openCases"
        :current-page="currentPage"
        :per-page="perPage"
      ></b-table>
    </div>
    <b-row>
      <b-col md="6" class="my-1">
        <b-pagination
          v-model="currentPage"
          :total-rows="3"
          :per-page="perPage"
          class="my-0"
        ></b-pagination>
      </b-col>
    </b-row>
  </div>
</template>

<script>
import openCases from "@/assets/tempData";

export default {
  data() {
    return {
      openCases: openCases,
      currentPage: 1,
      perPage: 2,
      fields: [
        {
          key: "caseId",
          sortable: true
        },
        {
          key: "createdDate",
          sortable: true
        },
        {
          key: "status",
          sortable: true
        },
        {
          key: "description",
          sortable: true
        },
        {
          key: "client",
          sortable: true
        },
        {
          key: "priority",
          sortable: true
        },
        {
          key: "references",
          sortable: true
        },
        {
          key: "eta",
          sortable: true
        },
        {
          key: "notes",
          sortable: true
        },
        {
          key: "eta",
          sortable: true
        },
        {
          key: "organizationalUnit",
          label: "org. unit",
          sortable: true
        },
        {
          key: "cpa",
          sortable: true
        }
      ]
    };
  }
};
</script>
