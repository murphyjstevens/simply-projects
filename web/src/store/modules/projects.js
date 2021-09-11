import axios from 'axios'

const baseUrl = 'https://localhost:5001'

const state = () => ({
  all: []
})

const getters = {
  find (state) {
    return (id) => state.all.find(project => project.id === id)
  }
}

const actions = {
  async get ({ commit }) {
    try {
      const response = await axios.get(baseUrl + '/projects/calculated')
      commit('setProjects', response.data)
    } catch (error) {
      console.error(error)
    }
  },
  async create ({ commit }, project) {
    try {
      const response = await axios.post(baseUrl + '/projects', project)
      commit('addProject', response.data)
    } catch (error) {
      console.error(error)
    }
  },
  async update ({ commit }, project) {
    try {
      const response = await axios.patch(baseUrl + '/projects', project)
      commit('updateProject', response.data)
    } catch (error) {
      console.error(error)
    }
  },
  async delete ({ commit }, projectId) {
    try {
      await axios.delete(baseUrl + '/projects/' + projectId)
      commit('deleteProject', projectId)
    } catch (error) {
      console.error(error)
    }
  }
}

const mutations = {
  setProjects (state, projects) {
    state.all = projects
  },
  addProject (state, project) {
    state.all.push(project)
  },
  updateProject (state, project) {

  },
  deleteProject (state, projectId) {
    state.all = state.all.filter(project => project.id !== projectId)
  }
}

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations
}
