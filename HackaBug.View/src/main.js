import Vue from 'vue'
import App from './App'
import router from './router'
import Vuetity from 'vuetify'
import '../node_modules/vuetify/dist/vuetify.min.css'
import VueResource from 'vue-resource'
import moment from 'moment'

Vue.use(VueResource)
Vue.use(Vuetity)
Vue.config.productionTip = false
Vue.http.options.root = 'http://drogaterra.com.br/api'
Vue.router = router

Vue.http.interceptors.push(function (request, next) {
  request.headers.set('Access-Control-Allow-Origin', '*')

  // continue to next interceptor
  next()
})
Vue.filter('formatedDate', function (value) {
  if (value) {
    return moment(String(value)).format('DD/MM/YYYY')
  }
})
/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  template: '<App/>',
  components: { App }
})
