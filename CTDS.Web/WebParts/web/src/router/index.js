import Vue from "vue";
import Router from "vue-router";
import DeclarationForm from "../declaration/DeclarationForm.vue";
import AddNewCase from "./../caseManagement/AddNewCase.vue";
import EditCase from "./../caseManagement/EditCase.vue";
import EditDeclaration from "./../declaration/EditDeclaration.vue";
import Login from "./../commonComponent/Login.vue";
import Unauthorize from "./../commonComponent/Unauthorize.vue";
import Dashboard2 from "./../commonComponent/Dashboard2.vue";
import SearchCases from "./../caseManagement/SearchCases.vue";
import SearchDeclarations from "./../declaration/SearchDeclarations.vue";

Vue.use(Router);

const router = new Router({
  routes: [
    {
      path: "/login",
      name: "login",
      component: Login,
      beforeEnter: (to, from, next) => {
        const user = sessionStorage.getItem("accessToken");
        if (user != null) {
          next("/home");
        } else {
          next();
        }
      }
    },
    {
      path: "/dash2",
      name: "Dashboard2.0",
      component: Dashboard2,
      beforeEnter: (to, from, next) => {
        const user = sessionStorage.getItem("accessToken");
        if (user == null) {
          next("/login");
        } else {
          next();
        }
      }
    },
    {
      path: "/declarationform",
      name: "DeclarationForm",
      component: DeclarationForm,
      beforeEnter: (to, from, next) => {
        const user = sessionStorage.getItem("accessToken");
        if (user == null) {
          next("/login");
        } else {
          next();
        }
      }
    },
    {
      path: "/editdeclaration/:id",
      name: "EditDeclaration",
      component: EditDeclaration,
      beforeEnter: (to, from, next) => {
        const user = sessionStorage.getItem("accessToken");
        if (user == null) {
          next("/login");
        } else {
          next();
        }
      }
    },
    {
      path: "/case",
      name: "NewCase",
      component: AddNewCase,
      beforeEnter: (to, from, next) => {
        const user = sessionStorage.getItem("accessToken");
        if (user == null) {
          next("/login");
        } else {
          next();
        }
      }
    },
    {
      path: "/searchcases",
      name: "Search Cases",
      component: SearchCases,
      beforeEnter: (to, from, next) => {
        const user = sessionStorage.getItem("accessToken");
        if (user == null) {
          next("/login");
        } else {
          next();
        }
      }
    },
    {
      path: "/searchdeclarations",
      name: "Search Declarations",
      component: SearchDeclarations,
      beforeEnter: (to, from, next) => {
        const user = sessionStorage.getItem("accessToken");
        if (user == null) {
          next("/login");
        } else {
          next();
        }
      }
    },
    {
      path: "/case/:id",
      name: "EditCase",
      component: EditCase,
      beforeEnter: (to, from, next) => {
        const user = sessionStorage.getItem("accessToken");
        if (user == null) {
          next("/login");
        } else {
          next();
        }
      }
    },
    {
      path: "/default.html",
      name: "Default",
      component: Login
    },
    {
      path: "/unauthorize",
      name: "unauthorize",
      component: Unauthorize
    },
  ],
  mode: "history"
});
export default router;
