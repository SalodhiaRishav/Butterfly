import Vue from 'vue';
import App from './App.vue';
import store from "./store/store";
import BootstrapVue from 'bootstrap-vue';
import router from './router/index.js';
import requestInterceptor from './interceptors/requestInterceptor';
import responseInterceptor from './interceptors/responseInterceptor';
import { library } from '@fortawesome/fontawesome-svg-core'
import { faEnvelope,faKey,faSave,faEdit, faBug,  faThumbtack, faPaperPlane, faWindowClose } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { dom } from '@fortawesome/fontawesome-svg-core'
import VueHotkey from 'v-hotkey'


dom.watch()
library.add(faEnvelope, faKey, faSave, faEdit, faBug, faThumbtack, faPaperPlane, faWindowClose )
Vue.component('font-awesome-icon', FontAwesomeIcon)
Vue.use(BootstrapVue)
Vue.use(router)
Vue.use(VueHotkey)

requestInterceptor();
responseInterceptor();

new Vue({
  store,
  router,
  BootstrapVue,
  render: h => h(App)
}).$mount('#app');
