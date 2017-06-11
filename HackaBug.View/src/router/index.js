import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/home/Home'
import Pragas from '@/components/praga/Praga'
import Culturas from '@/components/cultura/Cultura'
import Plantio from '@/components/plantio/Plantio'
Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/home',
      name: 'Home',
      component: Home
    },
    {
      path: '/pragas',
      name: 'Pragas',
      component: Pragas
    },
    {
      path: '/culturas',
      name: 'Culturas',
      component: Culturas
    },
    {
      path: '/plantios',
      name: 'Plantios',
      component: Plantio
    }
  ],
  mode: 'history'
})
