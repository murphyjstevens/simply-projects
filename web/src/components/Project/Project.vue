<template>
  <div class="project-content flex-column" v-if="id">
    <div class="d-flex flex-row mb-3">
      <router-link to="/"
        class="btn btn-secondary">Back</router-link>
      <h2 class="page-title">{{stateProject?.name}}</h2>
      <button class="btn btn-danger"
        @click="confirmDeleteProject()">Delete</button>
    </div>
    <label for="name">Name</label>
    <input id="name"
      class="form-control input-column"
      v-model="name"
      @blur="blur()"
      type="text"
      placeholder="Name">

    <label for="totalCost">Total Cost</label>
    <div class="input-group input-column">
      <span class="input-group-text">$</span>
      <input id="totalCost"
        v-model="totalCostInput"
        type="text"
        class="form-control"
        readonly
        placeholder="Total Cost">
    </div>

    <label for="description">Description</label>
    <textarea id="description"
      class="form-control input-column"
      v-model="description"
      @blur="blur()"></textarea>

    <Materials :projectId="id" />
    <DeleteConfirmation ref="deleteConfirmationModal" />
  </div>
</template>

<script>
import { mapState } from 'vuex'
import Materials from './Materials.vue'
import DeleteConfirmation from '../Shared/DeleteConfirmation.vue'

export default {
  name: 'Project',
  components: {
    Materials,
    DeleteConfirmation
  },
  data () {
    return {
      id: null,
      name: null,
      description: null
    }
  },
  computed: {
    ...mapState({
      stateProject: state => state.projects.project,
      totalCost: state => state.materials.totalCost
    }),
    totalCostInput () {
      return this.$filters.toCurrency(this.totalCost).replace('$', '')
    },
    hasChanges () {
      return this.stateProject &&
        this.name === this.stateProject.name &&
        this.description === this.stateProject.description
    }
  },
  methods: {
    blur () {
      if (this.hasChanges) {
        this.$store.dispatch('projects/update', { id: this.id, name: this.name, description: this.description })
      }
    },
    confirmDeleteProject () {
      console.log(this.$refs.deleteConfirmationModal)
      if (this.$refs.deleteConfirmationModal && this.id) {
        this.$refs.deleteConfirmationModal.open(this.deleteProject, this.id, this.name)
      }
    },
    async deleteProject () {
      if (this.id) {
        await this.$store.dispatch('projects/delete', this.id)
        this.$router.push('/')
      }
    }
  },
  watch: {
    '$store.state.projects.project': function () {
      this.name = this.stateProject?.name
      this.description = this.stateProject?.description
    }
  },
  mounted () {
    this.id = +this.$route.params.id
    this.name = null
    this.description = null
    this.$store.dispatch('projects/find', this.id)
  }
}
</script>

<style scoped lang="scss">
  .project-content {
    background-color: #FFFFFFAA;
    padding: 20px 30px 30px 30px;
    margin-top: -10px;
    border-radius: 0 0 50px 50px;

    .page-title {
      margin: 0 10px;
      flex: 1;
      text-overflow: ellipsis;
    }

    .input-column {
      margin-bottom: 10px;
    }

    textarea {
      resize: none;
    }
  }
</style>
