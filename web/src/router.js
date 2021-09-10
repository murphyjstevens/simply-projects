import { createRouter, createWebHashHistory } from 'vue-router'

import ProjectList from './components/ProjectList'
import Project from './components/Project/Project'

const routes = [
  { path: '/', name: 'ProjectList', component: ProjectList },
  { path: '/Project/:id', name: 'Project', component: Project }
]

export const router = createRouter({
  history: createWebHashHistory(),
  routes
})
