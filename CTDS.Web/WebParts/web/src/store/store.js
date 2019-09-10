import Vue from "vue";
import Vuex from "vuex";
import caseManagement from "./modules/caseManagement";

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    caseManagement
  }
});
