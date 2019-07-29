import Vue from 'vue';
import Router from 'vue-router';
import DeclarationForm from '../Declaration/DeclarationForm.vue'; 
import temp from '../Declaration/temp.vue';
Vue.use(Router);

const router = new Router({
  routes: [
  {
    path: '/declarationform',
    name: 'DeclarationForm',
    component: DeclarationForm,
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