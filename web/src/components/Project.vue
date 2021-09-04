<template>
  <div class="page-header">
    <router-link to="/"
      class="btn btn-secondary">Back</router-link>
    <span class="page-title">{{project.name}}</span>
    <button type="button"
      @click="save()"
      class="btn btn-primary">Save</button>
  </div>

  <div class="project-wrapper">
    <div class="project-content flex-column">
      <label for="name">Name</label>
      <input id="name"
        class="form-control input-column"
        v-model="project.name"
        type="text"
        placeholder="Name">

      <label for="totalCost">Total Cost</label>
      <div class="input-group input-column">
        <span class="input-group-text">$</span>
        <input id="totalCost"
          v-model="project.totalCost"
          type="text"
          class="form-control"
          placeholder="Total Cost">
      </div>

      <label for="description">Description</label>
      <textarea id="description"
        class="form-control input-column"
        v-model="project.description"></textarea>
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

<style scoped lang="scss">

  .project-content {
    .input-column {
      width: 300px;
      max-width: 100%;
      margin-bottom: 10px;
    }

    textarea {
      resize: none;
    }
  }
</style>
