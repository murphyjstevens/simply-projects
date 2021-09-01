import Vue from 'vue'
import VueRouter from 'vue-router'

import App from './App.vue'

import './assets/variables.css'
import './assets/global.css'

import ProjectList from './components/ProjectList'
import Project from './components/Project'

Vue.use(VueRouter)

const router = new VueRouter({
  mode: 'history',
  base: __dirname,
  routes: [
    { path: '/', name: 'ProjectList', component: ProjectList },
    { path: '/Project', name: 'Project', component: Project }
  ]
})

new Vue({
  render: h => h(App),
  router
}).$mount('#app')