import axios from 'axios'

const baseUrl = 'https://localhost:5001'

const state = () => ({
  projectMaterials: [],
  material: null,
  totalCost: 0.00
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
  async find ({ commit, state }, materialId) {
    try {
      if (!materialId) {
        console.error('Empty MaterialId')
        return
      }
      if (state.projectMaterials.length) {
        const material = state.projectMaterials.find(material => material.id === materialId)
        if (material) {
          commit('setMaterial', material)
          return
        }
      }
      const response = await axios.get(baseUrl + '/materials/' + materialId)
      commit('setMaterial', response.data)
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
      const response = await axios.put(baseUrl + '/materials', material)
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
    state.projectMaterials = materials.sort((a, b) => a.sortOrder - b.sortOrder)
    this.commit('materials/setTotalCost')
  },
  setMaterial (state, material) {
    state.material = material
  },
  addMaterial (state, material) {
    state.projectMaterials.push(material)
    state.projectMaterials.sort((a, b) => a.sortOrder - b.sortOrder)
    this.commit('materials/setTotalCost')
  },
  updateMaterial (state, material) {
    const index = state.projectMaterials.findIndex(p => p.id === material.id)
    state.projectMaterials[index] = material
    state.projectMaterials.sort((a, b) => a.sortOrder - b.sortOrder)
    this.commit('materials/setTotalCost')
  },
  deleteMaterial (state, materialId) {
    state.projectMaterials = state.projectMaterials
      .filter(material => material.id !== materialId)
      .sort((a, b) => a.sortOrder - b.sortOrder)
    this.commit('materials/setTotalCost')
  },
  setTotalCost (state) {
    const totalCost = state.projectMaterials
      .map(material => material ? material.cost * material.quantity : 0)
      .reduce((previous, current) => previous + current)

    state.totalCost = totalCost
  }
}

export default {
  namespaced: true,
  state,
  actions,
  mutations
}
