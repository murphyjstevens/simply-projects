<template>
  <div class="materials-container">
    <div v-for="material in materials"
      :key="material.id"
      class="list-group">
      <div class="list-group-item d-flex justify-content-between">
        <div class="left-container">
          <div class="mb-1 d-flex">
            <h5 class="me-1">{{ material.name }}</h5>
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

  <MaterialDialog ref="modal"
    :materialId="dialogMaterialId"
    :projectId="dialogProjectId" />
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
      materials: [],
      dialogMaterialId: null,
      dialogProjectId: null
    }
  },
  watch: {
    '$store.state.materials.projectMaterials': function () {
      console.log(this.$store.state.materials.projectMaterials.sort((a, b) => a.sortOrder - b.sortOrder))
      this.materials = this.$store.state.materials.projectMaterials // .sort((a, b) => a.sortOrder - b.sortOrder)
    }
  },
  methods: {
    calculateTotalCost (material) {
      return material ? material.cost * material.quantity : null
    },
    openMaterialDialog (material) {
      if (this.$refs.modal) {
        this.dialogMaterialId = material?.id
        this.dialogProjectId = material?.projectId
        setTimeout(() => {
          this.$refs.modal.open()
        })
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

      this.$store.dispatch('materials/update', { ...otherMaterial, sortOrder: material.sortOrder })

      this.$store.dispatch('materials/update', { ...material, sortOrder: newOrder })
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
  .materials-container {
    width: 500px;

    .material-cost {
      opacity: 0.5;
      margin-top: 0.5rem;
      margin-bottom: 0.5rem;
    }
  }
</style>
