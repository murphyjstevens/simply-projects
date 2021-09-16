<template>
  <div class="d-flex flex-column">
    <div class="d-flex flex-row mb-1 justify-content-between">
      <h4 class="align-self-end mb-0">Materials</h4>
      <button class="btn btn-primary btn-sm"
        @click="openMaterialDialog()">
        <i class="bi-plus-lg me-1"></i>
        <span>Add</span>
      </button>
    </div>
    <div v-for="material in materials"
      :key="material.id"
      class="list-group">
      <div class="list-group-item d-flex justify-content-between">
        <div class="left-container">
          <div class="mb-1 d-flex">
            <h5 class="me-2">{{ material.name }}</h5>
            <button class="button-icon"
              @click="openMaterialDialog(material)">
              <i class="bi-pencil-fill"></i>
            </button>
          </div>

          <p class="mb-1">{{ $filters.toCurrency(material.cost) }} each</p>
          <small>x {{ material.quantity }}</small>
        </div>
        <div class="d-flex flex-column justify-content-center align-items-end">
          <button class="button-icon"
            @click="reorder(material, true)"
            :disabled="material.sortOrder === 0">
            <i class="bi-chevron-up"></i>
          </button>
          <h5 class="material-cost">{{ $filters.toCurrency(calculateTotalCost(material)) }}</h5>
          <button class="button-icon"
            @click="reorder(material, false)"
            :disabled="material.sortOrder === materials.length - 1">
            <i class="bi-chevron-down"></i>
          </button>
        </div>
      </div>
    </div>
  </div>

  <MaterialDialog ref="modal" />
</template>

<script>
import MaterialDialog from './MaterialDialog.vue'

export default {
  name: 'Materials',
  components: {
    MaterialDialog
  },
  props: ['projectId'],
  data () {
    return {
      materials: []
    }
  },
  watch: {
    '$store.state.materials.projectMaterials': function () {
      this.materials = this.$store.state.materials.projectMaterials
    }
  },
  methods: {
    calculateTotalCost (material) {
      return material ? material.cost * material.quantity : null
    },
    openMaterialDialog (material) {
      if (this.$refs.modal) {
        this.$refs.modal.open(material?.id, this.projectId)
      }
    },
    reorder (material, isUp) {
      if ((isUp && material.sortOrder === 0) ||
        (!isUp && material.sortOrder === this.materials.reduce((a, b) => a.sortOrder > b.sortOrder ? a : b))) {
        return
      }

      const newOrder = isUp ? material.sortOrder - 1 : material.sortOrder + 1
      const otherMaterial = this.materials.find(mat => mat.sortOrder === newOrder)

      if (!otherMaterial) {
        console.error('Could not find sort order')
      }

      const reorderRequest = {
        item1: {
          id: material.id,
          sortOrder: newOrder
        },
        item2: {
          id: otherMaterial.id,
          sortOrder: material.sortOrder
        }
      }

      this.$store.dispatch('materials/reorder', reorderRequest)
    }
  },
  created () {
    this.materials = []
    this.$store.dispatch('materials/getByProjectId', this.projectId)
  },
  setTotalCost (state, totalCost) {
    state.totalCost = totalCost
  }
}
</script>

<style scoped lang="scss">
  .material-cost {
    opacity: 0.7;
    margin-top: 0.5rem;
    margin-bottom: 0.5rem;
  }
</style>
