import Vue from "vue";
import Vuex from "vuex";
import CaseManagement from "./modules/CaseManagement";
import Authentication from "./modules/Authentication";


Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    CaseManagement,
    Authentication
  }
});
