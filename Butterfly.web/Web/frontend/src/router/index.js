import Vue from 'vue';
import Router from 'vue-router';
import DeclarationForm from '../Declaration/DeclarationForm.vue'; 
import temp from '../Declaration/temp.vue';
import CaseManagementHeader from "./../CaseManagement/CaseManagementHeader.vue";
import OpenCases from "./../CaseManagement/OpenCases.vue";

Vue.use(Router);

const router = new Router({
  routes: [
  {
    path: '/declarationform',
    name: 'DeclarationForm',
    component: DeclarationForm,
    },
    {
      path: '/mycase',
      name: 'Case',
      component: CaseManagementHeader,
    },
    {
      path: '/opencases',
      name: 'opencases',
      component: OpenCases,
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
