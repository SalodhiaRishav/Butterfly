import Vue from 'vue';
import Router from 'vue-router';
import DeclarationForm from '../Declaration/DeclarationForm.vue'; 
import temp from '../Declaration/temp.vue';
import AddNewCase from "./../CaseManagement/AddNewCase.vue";
import EditCase from "./../CaseManagement/EditCase.vue";
import OpenCases from "./../CaseManagement/OpenCases.vue";
import DeclarationDashboard from './../Declaration/DeclarationDashboard.vue';

Vue.use(Router);

const router = new Router({
  routes: [
  {
    path: '/declarationform',
    name: 'DeclarationForm',
    component: DeclarationForm,
    },
    {
      path: '/declarationdashboard',
      name: 'DeclarationDashboard',
      component: DeclarationDashboard,
      },
    {
      path: '/newcase',
      name: 'Case',
      component: AddNewCase,
    },
    {
      path: '/opencases',
      name: 'opencases',
      component: OpenCases,
    },
    {
      path: '/editcase',
      name: 'Case',
      component: EditCase,
    },
  {
      path:'/temp',
      name:'temp',
      component: temp,
  }
  ],
  mode: 'history',
}
)
export default router;
