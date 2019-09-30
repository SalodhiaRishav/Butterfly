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
import DateRangePicker from "@gravitano/vue-date-range-picker";
import ToggleSwitch from 'vuejs-toggle-switch'
import moment from 'moment';
Vue.use(ToggleSwitch)

// import moment from 'moment';
// var moment = require('moment');
Vue.prototype.$moment = moment

dom.watch()
library.add(faEnvelope, faKey, faSave, faEdit, faBug, faThumbtack, faPaperPlane, faWindowClose )
Vue.component('font-awesome-icon', FontAwesomeIcon)
Vue.use(BootstrapVue)
Vue.use(router)
Vue.use(VueHotkey)
Vue.use(DateRangePicker);

requestInterceptor();
responseInterceptor();

new Vue({
  store,
  router,
  BootstrapVue,
  DateRangePicker,
  render: h => h(App)
}).$mount('#app');
