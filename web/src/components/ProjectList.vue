<template>
  <div class="page-header">
    <span class="page-title">Project List</span>
    <button type="button" @click="openAddProjectDialog()" class="btn btn-primary">Add</button>
  </div>

  <div class="container">
    <div class="row row-cols-2 justify-content-center">
      <div v-for="project in projects" :key="project.id" class="col">
        <router-link :to="{ name: 'Project', params: { id: project.id }}" class="card">
          <div class="card-body">
            <h4 class="card-title">{{ project.name }}</h4>
            <h5 class="card-text">{{ project.totalCost }}</h5>
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
    }
  },
  created () {
    this.$store.dispatch('projects/get')
  }
}
</script>

<style scoped lang="scss">
.card {
  color: inherit;
  text-decoration: none;
}
</style>
