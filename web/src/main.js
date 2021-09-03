import { createApp, h } from 'vue'
import { createRouter, createWebHashHistory } from 'vue-router'
import { createStore } from 'vuex'

import App from './App.vue'

import './assets/global.css'

import ProjectList from './components/ProjectList'
import Project from './components/Project'

const routes = [
  { path: '/', name: 'ProjectList', component: ProjectList },
  { path: '/Project/:id', name: 'Project', component: Project }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

const store = createStore({
  state () {
    return {
      projects: [
        { id: 1, name: 'Flooring', userId: 1, totalCost: 50.0, description: '' },
        { id: 2, name: 'Painting', userId: 3, totalCost: 50.0, description: '' },
        { id: 3, name: 'TV', userId: 1, totalCost: 50.0, description: '' },
        { id: 4, name: 'Deck', userId: 1, totalCost: 50.0, description: '' }
      ]
    }
  },
  mutations: {
    setProjects (state, projects) {
      state.projects = projects
    }
  },
  getters: {
    getProjectById: (state) => (id) => {
      return state.projects.find(project => project.id === +id)
    }
  }
})

const app = createApp({
  render: () => h(App)
})

app.use(router)

app.use(store)

app.mount('#app')
