import Vue from "vue";
import Router from "vue-router";
import DeclarationForm from "../declaration/DeclarationForm.vue";
import AddNewCase from "./../caseManagement/AddNewCase.vue";
import EditCase from "./../caseManagement/EditCase.vue";
import Dashboard from "./../commonComponent/Dashboard.vue";
import DeclarationDashBoard from "./../declaration/DeclarationDashBoard.vue";
import EditDeclaration from "./../declaration/EditDeclaration.vue";
import Login from "./../commonComponent/Login.vue";

Vue.use(Router);

const router = new Router({
  routes: [
    {
      path: "/login",
      name: "login",
      component: Login,
      beforeEnter:(to, from, next)=>{
        const user = sessionStorage.getItem("accessToken");
        if(user != null){
          next('/home');
        }
        else{
          next();
        }
      }
    },
    {
      path: "/declarationform",
      name: "DeclarationForm",
      component: DeclarationForm,
      beforeEnter:(to, from, next)=>{
        const user = sessionStorage.getItem("accessToken");
        if(user == null){
          next('/login')
        }
        else{
          next();
        }
      }
    },
    {
      path: "/declarationdashboard",
      name: "DeclarationDashboard",
      component: DeclarationDashBoard,
      beforeEnter:(to, from, next)=>{
        const user = sessionStorage.getItem("accessToken");
        if(user == null){
          next('/login')
        }
        else{
          next();
        }
      }
    },
    {
      path: "/editdeclaration/:id",
      name: "EditDeclaration",
      component: EditDeclaration,
      beforeEnter:(to, from, next)=>{
        const user = sessionStorage.getItem("accessToken");
        if(user == null){
          next('/login')
        }
        else{
          next();
        }
      }
    },
    {
      path: "/newcase",
      name: "NewCase",
      component: AddNewCase,
      beforeEnter:(to, from, next)=>{
        const user = sessionStorage.getItem("accessToken");
        if(user == null){
          next('/login')
        }
        else{
          next();
        }
      }
    },
    {
      path: "/home",
      name: "Dashboard",
      component: Dashboard,
      beforeEnter:(to, from, next)=>{
        const user = sessionStorage.getItem("accessToken");
        if(user == null){
          next('/login')
        }
        else{
          next();
        }
      }
    },
    {
      path: "/editcase",
      name: "EditCase",
      component: EditCase,
      beforeEnter:(to, from, next)=>{
        const user = sessionStorage.getItem("accessToken");
        if(user == null){
          next('/login')
        }
        else{
          next();
        }
      }
    },
    {
      path: "/default.html",
      name: "Default",
      component: Login,
    }
  ],
  mode: "history"
});
export default router;
