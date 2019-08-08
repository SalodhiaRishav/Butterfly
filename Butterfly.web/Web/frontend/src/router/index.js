import Vue from 'vue';
import Router from 'vue-router';
import DeclarationForm from '../Declaration/DeclarationForm.vue'; 
import AddNewCase from "./../CaseManagement/AddNewCase.vue";
import EditCase from "./../CaseManagement/EditCase.vue";
import Dashboard from './../CommonComponent/Dashboard.vue';


Vue.use(Router);

const router = new Router({
  routes: [
  {
    path: '/declarationform',
    name: 'DeclarationForm',
    component: DeclarationForm,
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
  ],
  mode: 'history',
}
)
export default router;
