import Vue from 'vue';
import App from './App.vue';
import BootstrapVue from 'bootstrap-vue';
import router from './router/index.js';

Vue.use(BootstrapVue)
Vue.use(router)

new Vue({
  router,
  BootstrapVue,
  render: h => h(App)
}).$mount('#app');
