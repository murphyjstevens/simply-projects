<template>
  <div class="materials-container">
    <div v-for="material in materials" :key="material.id" class="list-group">
      <div class="list-group-item list-group-item-action d-flex justify-content-between">
        <div class="left-container">
          <h5 class="mb-1">{{ material.name }}</h5>
          <p class="mb-1">{{ $filters.toCurrency(material.cost) }} each</p>
          <small>x {{ material.quantity }}</small>
        </div>
        <div class="d-flex align-items-center">
          <h5 class="material-cost">{{ $filters.toCurrency(calculateTotalCost(material)) }}</h5>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Materials',
  props: ['projectId'],
  data () {
    return {
      materials: []
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
    }
  },
  created () {
    this.materials = []
    this.$store.dispatch('materials/getByProjectId', this.projectId)
  }
}
</script>

<style scoped lang="scss">
  .material-cost {
    opacity: 0.5;
  }
</style>
