import Vue from "vue";
import Vuex from "vuex";
import CaseManagement from "./modules/CaseManagement";

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    CaseManagement
  }
});
