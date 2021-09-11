import axios from 'axios'

const baseUrl = 'https://localhost:5001'

const state = () => ({
  projectMaterials: []
})

const actions = {
  async getByProjectId ({ commit }, projectId) {
    try {
      if (!projectId) {
        console.error('Empty ProjectId')
        return
      }
      const response = await axios.get(baseUrl + '/projects/' + projectId + '/materials')
      commit('setMaterials', response.data)
    } catch (error) {
      console.error(error)
    }
  },
  async create ({ commit }, material) {
    try {
      if (!material) {
        console.error('Empty material object')
        return
      }
      const response = await axios.post(baseUrl + '/materials', material)
      commit('addMaterial', response.data)
    } catch (error) {
      console.error(error)
    }
  },
  async update ({ commit }, material) {
    try {
      if (!material) {
        console.error('Empty material object')
        return
      }
      const response = await axios.patch(baseUrl + '/materials', material)
      commit('updateMaterial', response.data)
    } catch (error) {
      console.error(error)
    }
  },
  async delete ({ commit }, materialId) {
    try {
      if (!materialId) {
        console.error('Empty materialId')
        return
      }
      await axios.delete(baseUrl + '/materials/' + materialId)
      commit('deleteMaterial', materialId)
    } catch (error) {
      console.error(error)
    }
  }
}

const mutations = {
  setMaterials (state, materials) {
    state.projectMaterials = materials
  },
  addMaterial (state, material) {
    state.projectMaterials.push(material)
  },
  updateMaterial (state, material) {
    const index = state.projectMaterials.findIndex(p => p.id === material.id)
    state.projectMaterials[index] = material
  },
  deleteMaterial (state, materialId) {
    state.projectMaterials = state.projectMaterials.filter(material => material.id !== materialId)
  }
}

export default {
  namespaced: true,
  state,
  actions,
  mutations
}
