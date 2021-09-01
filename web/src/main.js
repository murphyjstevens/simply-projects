import { createApp, h } from 'vue'
import { createRouter, createWebHashHistory } from 'vue-router'

import App from './App.vue'

import './assets/global.css'

import ProjectList from './components/ProjectList'
import Project from './components/Project'

const routes = [
  { path: '/', name: 'ProjectList', component: ProjectList },
  { path: '/Project', name: 'Project', component: Project }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

const app = createApp({
  render: () => h(App)
})

app.use(router)

app.mount('#app')
