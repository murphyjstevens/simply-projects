import axios from 'axios'

const baseUrl = 'https://localhost:5001'

const state = () => ({
  all: [],
  project: undefined,
  totalCost: 0.00
})

const getters = {
  find (state) {
    return (id) => {
      state.all.find(project => project.id === id)
    }
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
  async find ({ commit, state }, projectId) {
    try {
      if (!projectId) {
        console.error('Empty ProjectId')
        return
      }
      if (state.all.length) {
        commit('setProject', state.all.find(project => project.id === projectId))
      } else {
        const response = await axios.get(baseUrl + '/projects/' + projectId)
        commit('setProject', response.data)
      }
    } catch (error) {
      console.error(error)
    }
  },
  async create ({ commit }, project) {
    try {
      if (!project) {
        console.error('Empty Project object')
        return
      }
      const response = await axios.post(baseUrl + '/projects', project)
      commit('addProject', response.data)
    } catch (error) {
      console.error(error)
    }
  },
  async update ({ commit }, project) {
    try {
      if (!project) {
        console.error('Empty Project object')
        return
      }
      const response = await axios.put(baseUrl + '/projects', project)
      commit('updateProject', response.data)
    } catch (error) {
      console.error(error)
    }
  },
  async delete ({ commit }, projectId) {
    try {
      if (!projectId) {
        console.error('Empty ProjectId')
        return
      }
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
  setProject (state, project) {
    state.project = project
  },
  addProject (state, project) {
    state.all.push(project)
  },
  updateProject (state, project) {
    if (state.all.length) {
      const index = state.all.findIndex(p => p.id === project.id)
      if (index !== -1) {
        state.all[index] = project
      }
    }
    state.project = project
  },
  deleteProject (state, projectId) {
    state.all = state.all.filter(project => project.id !== projectId)
  },
  setTotalCost (state, totalCost) {
    state.totalCost = totalCost
  }
}

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations
}
