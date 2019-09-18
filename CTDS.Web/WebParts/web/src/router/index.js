import Vue from "vue";
import Router from "vue-router";
import DeclarationForm from "../declaration/DeclarationForm.vue";
import AddNewCase from "./../caseManagement/AddNewCase.vue";
import EditCase from "./../caseManagement/EditCase.vue";
import Dashboard from "./../commonComponent/Dashboard.vue";
import DeclarationDashBoard from "./../declaration/DeclarationDashBoard.vue";
import EditDeclaration from "./../declaration/EditDeclaration.vue";
import Login from "./../commonComponent/Login.vue";
import Unauthorize from "./../commonComponent/Unauthorize.vue";
import Dashboard2 from "./../commonComponent/Dashboard2.vue";
import TileChecker from "./../commonComponent/TileChecker.vue";

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
      path: "/declarationdashboard",
      name: "DeclarationDashboard",
      component: DeclarationDashBoard,
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
      path: "/home",
      name: "Dashboard",
      component: Dashboard,
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
    {
      path: "/dash2",
      name: "dashboard2.0",
      component: Dashboard2
    },
    {
      path: "/tilechecker",
      name: "dashboard2.0",
      component: TileChecker
    },
  ],
  mode: "history"
});
export default router;
