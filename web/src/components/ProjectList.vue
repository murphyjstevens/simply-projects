<template>
  <header>
    <span class="page-title">Project List</span>
    <button type="button" v-on:click="openAddProjectDialog()" class="btn btn-primary">Add</button>
  </header>

  <div class="container-fluid">
    <div class="row justify-content-center">
      <div v-for="project in projects" :key="project.id" class="col-sm-12 col-md-6 col-lg-3 col-xl-2">
        <div class="card">
          <div class="card-body">
            <h4 class="card-title">{{ project.name }}</h4>
            <h5 class="card-text">{{ project.totalCost }}</h5>
            <p class="card-text">{{ project.description }}</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'ProjectList',
  data () {
    return {
      projects: [
        { id: 1, name: 'Flooring', userId: 1, totalCost: 50.0, description: '' },
        { id: 2, name: 'Painting', userId: 3, totalCost: 50.0, description: '' },
        { id: 3, name: 'TV', userId: 1, totalCost: 50.0, description: '' },
        { id: 4, name: 'Deck', userId: 1, totalCost: 50.0, description: '' }
      ]
    }
  },
  methods: {
    openAddProjectDialog () {
      console.log('open')
    }
  }
}
</script>

<style scoped>
</style>
