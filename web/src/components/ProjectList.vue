<template>
  <div class="d-flex justify-content-center mb-3">
    <button type="button"
      @click="openAddProjectDialog()"
      class="btn btn-outline-light btn-lg">
      <i class="bi-plus-lg"></i>
      Add Project
    </button>
  </div>

  <div class="container">
    <div class="masonry-grid">
      <div v-for="project in projects"
        :key="project.id"
        class="masonry-item">
        <router-link :to="{ name: 'Project', params: { id: project.id }}" class="card">
          <div class="card-body">
            <h4 class="card-title">{{ project.name }}</h4>
            <h5 class="card-text">{{ convertToCurrency(project.totalCost) }}</h5>
            <p class="card-text">{{ project.description }}</p>
          </div>
        </router-link>
      </div>
    </div>
  </div>

  <AddProject ref="addModal" />
</template>

<script>
import { mapState } from 'vuex'
import AddProject from './AddProject.vue'

export default {
  name: 'ProjectList',
  components: {
    AddProject
  },
  computed: {
    ...mapState({
      projects: state => state.projects.all
    })
  },
  methods: {
    openAddProjectDialog () {
      if (this.$refs.addModal) {
        this.$refs.addModal.open()
      }
    },
    convertToCurrency (valueToConvert) {
      return this.$filters.toCurrency(valueToConvert)
    }
  },
  created () {
    this.$store.dispatch('projects/get')
  }
}
</script>

<style scoped lang="scss">
.card {
  background-color: white;
  color: inherit;
  text-decoration: none;
}
</style>
