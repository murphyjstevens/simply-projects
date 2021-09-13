<template>
  <div class="page-header" v-if="project">
    <router-link to="/"
      class="btn btn-secondary">Back</router-link>
    <span class="page-title">{{stateProject.name}}</span>
    <button type="button"
      @click="save()"
      class="btn btn-primary">Save</button>
  </div>

  <div class="project-wrapper" v-if="project">
    <div class="project-content flex-column">
      <label for="name">Name</label>
      <input id="name"
        class="form-control input-column"
        v-model="project.name"
        @blur="blur()"
        type="text"
        placeholder="Name">

      <label for="totalCost">Total Cost</label>
      <div class="input-group input-column">
        <span class="input-group-text">$</span>
        <input id="totalCost"
          v-model.number="totalCost"
          type="text"
          class="form-control"
          readonly
          placeholder="Total Cost">
      </div>

      <label for="description">Description</label>
      <textarea id="description"
        class="form-control input-column"
        v-model="project.description"
        @blur="blur()"></textarea>

      <Materials :projectId="project?.id" />
    </div>
  </div>
</template>

<script>
import { mapState } from 'vuex'
import Materials from './Materials.vue'

export default {
  name: 'Project',
  components: {
    Materials
  },
  data () {
    return {
      project: null
    }
  },
  computed: {
    ...mapState({
      stateProject: state => state.projects.project,
      totalCost: state => state.projects.totalCost
    })
  },
  methods: {
    blur () {
      const hasChanges = !this.checkProjectEquals(this.project, this.stateProject)
      if (hasChanges) {
        this.$store.dispatch('projects/update', this.project)
      }
    },
    checkProjectEquals (a, b) {
      return (!a && !b) || (a && b && a.name === b.name && a.description === b.description)
    }
  },
  watch: {
    '$store.state.projects.project': function () {
      this.project = { ...this.stateProject }
    }
  },
  mounted () {
    this.project = null
    this.$store.dispatch('projects/find', +this.$route.params.id)
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
