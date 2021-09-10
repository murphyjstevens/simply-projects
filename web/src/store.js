import { createStore } from 'vuex'

export const store = createStore({
  state () {
    return {
      projects: [
        { id: 1, name: 'Flooring', userId: 1, totalCost: 50.0, description: '' },
        { id: 2, name: 'Painting', userId: 3, totalCost: 50.0, description: '' },
        { id: 3, name: 'TV', userId: 1, totalCost: 50.0, description: '' },
        { id: 4, name: 'Deck', userId: 1, totalCost: 50.0, description: '' }
      ],
      materials: [
        { id: 1, projectId: 1, name: 'Planks', cost: 50.0, quantity: 250 },
        { id: 2, projectId: 1, name: 'Underlayment', cost: 45.00, quantity: 10 },
        { id: 3, projectId: 1, name: 'Floor Transition', cost: 10.99, quantity: 5 }
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
    },
    getMaterialsByProjectId: (state) => (projectId) => {
      return state.materials.filter(material => material.projectId === projectId)
    }
  }
})
