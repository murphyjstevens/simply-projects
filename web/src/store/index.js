import { createStore } from 'vuex'

import projects from './modules/projects'
import materials from './modules/materials'

export default createStore({
  strict: true,
  modules: {
    projects,
    materials
  }
})
