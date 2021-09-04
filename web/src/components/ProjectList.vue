<template>
  <div class="page-header">
    <span class="page-title">Project List</span>
    <button type="button" @click="openAddProjectDialog()" class="btn btn-primary">Add</button>
  </div>

  <div class="container-fluid">
    <div class="row justify-content-center">
      <div v-for="project in projects" :key="project.id" class="col-sm-12 col-md-6 col-lg-3 col-xl-2">
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
import AddProject from './AddProject.vue'

export default {
  name: 'ProjectList',
  components: {
    AddProject
  },
  data () {
    return {
      projects: this.$store.state.projects
    }
  },
  methods: {
    openAddProjectDialog () {
      if (this.$refs.addModal) {
        this.$refs.addModal.open()
      }
    }
  }
}
</script>

<style scoped>
.card {
  color: inherit;
  text-decoration: none;
}
</style>
