<template>
  <header>
    <router-link to="/" class="btn btn-secondary">Back</router-link>
    <span class="page-title">{{project.name}}</span>
    <button type="button" @click="save()" class="btn btn-primary">Save</button>
  </header>

  <div class="project-wrapper">
    <div class="project-content">
      <div class="container-fluid">
        <div class="row">
          <div class="col-sm-12 col-md-6">
            <label for="name">Name</label>
            <input id="name" v-model="project.name" type="text" class="form-control" placeholder="Name">
          </div>
          <div class="col-sm-12 col-md-6">
            <label for="totalCost">Total Cost</label>
            <div class="input-group">
              <span class="input-group-text">$</span>
              <input id="totalCost" v-model="project.totalCost" type="text" class="form-control" placeholder="Total Cost">
            </div>
          </div>
          <div class="col-sm-12 col-md-6">
            <label for="description">Description</label>
            <textarea id="description" v-model="project.description" class="form-control"></textarea>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Project',
  data () {
    return {
      project: {}
    }
  },
  mounted () {
    this.project = this.$store.getters.getProjectById(this.$route.params.id)
  }
}
</script>

<style scoped>
</style>
