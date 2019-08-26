import Vue from 'vue';
import Router from 'vue-router';
import DeclarationForm from '../Declaration/DeclarationForm.vue'; 
import AddNewCase from "./../CaseManagement/AddNewCase.vue";
import EditCase from "./../CaseManagement/EditCase.vue";
import Dashboard from './../CommonComponent/Dashboard.vue';
import DeclarationDashBoard from './../Declaration/DeclarationDashBoard.vue';
import EditDeclaration from './../Declaration/editDeclaration.vue';
import Login from './../CommonComponent/Login.vue'


Vue.use(Router);

const router = new Router({
  routes: [
    {
      path: '/login',
      name: 'login',
      component: Login,
      },
  {
    path: '/declarationform',
    name: 'DeclarationForm',
    component: DeclarationForm,
    },
    {
      path: '/declarationdashboard',
      name: 'DeclarationDashboard',
      component: DeclarationDashBoard,
      },
      {
        path: '/editdeclaration/:id',
        name: 'EditDeclaration',
        component: EditDeclaration,
        },
    {
      path: '/newcase',
      name: 'NewCase',
      component: AddNewCase,
    },
    {
      path: '/home',
      name: 'Dashboard',
      component: Dashboard,
    },
    {
      path: '/editcase',
      name: 'EditCase',
      component: EditCase,
    },
    {
      path: '/default.html',
      name: 'Default',
      component: Login,
    },
  ],
  mode: 'history',
}
)
router.beforeEach((to, from, next) => {
  const user = sessionStorage.getItem("accessToken");
  if (to.fullPath === '/home' || to.fullPath === '/declarationform' || to.fullPath === '/newcase') {
    if (user == null) {
      next('/login');
    }
  }
  if (to.fullPath === '/' || to.fullPath === '/login') {
    if (user != null) {
      next('/home');
    }
  }
  next();
});
export default router;