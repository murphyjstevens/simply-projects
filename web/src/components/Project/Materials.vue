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
        <div class="d-flex align-items-center">
          <h5 class="material-cost">{{ $filters.toCurrency(calculateTotalCost(material)) }}</h5>
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
      if (!this.materials.length) {
        this.materials = this.$store.state.materials.projectMaterials
      }
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
    }
  }
</style>
