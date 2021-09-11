import { createStore } from 'vuex'

import projects from './modules/projects'
import materials from './modules/materials'

export default createStore({
  modules: {
    projects,
    materials
  }
})
