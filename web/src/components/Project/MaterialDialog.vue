<template>
  <div class="modal fade" ref="modal" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">
            <span v-if="!originalMaterial">Add Material</span>
            <span v-if="originalMaterial">Modify Material: {{originalMaterial.name}}</span>
          </h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <div class="container-fluid">
            <div class="row gy-3">
              <p v-if="errors.length">
                <b>Please correct the following error(s):</b>
                <ul>
                  <li v-for="error in errors" :key="error">{{ error }}</li>
                </ul>
              </p>
              <div class="col-sm-12">
                <label for="dialog-name" class="form-label">Name</label>
                <input id="dialog-name"
                  type="text"
                  class="form-control"
                  placeholder="Name"
                  v-model="name">
              </div>
              <div class="col-sm-12 col-md-6">
                <label for="dialog-cost" class="form-label">Cost</label>
                <div id="dialog-cost"
                  class="input-group">
                  <span class="input-group-text">$</span>
                  <input type="number"
                    class="form-control"
                    placeholder="Cost"
                    v-model.number="cost">
                </div>
              </div>
              <div class="col-sm-12 col-md-6">
                <label for="dialog-quantity" class="form-label">Quantity</label>
                <input id="dialog-quantity"
                  type="number"
                  class="form-control"
                  placeholder="Quantity"
                  v-model.number="quantity">
              </div>
            </div>
          </div>
        </div>
        <div class="modal-footer">
          <button type="button"
            class="btn btn-primary"
            @click="save()"
            :disabled="errors.length || !isDirty">Save</button>
          <button type="button"
            class="btn btn-secondary"
            @click="close()">Close</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapState } from 'vuex'
import { Modal } from 'bootstrap'

export default {
  name: 'MaterialDialog',
  data () {
    return {
      originalMaterial: null,
      projectId: null,
      name: null,
      cost: null,
      quantity: null,
      errors: []
    }
  },
  computed: {
    ...mapState({
      stateMaterial: state => state.materials.material
    }),
    isDirty: function () {
      return !this.originalMaterial ||
        this.name !== this.originalMaterial.name ||
        this.cost !== this.originalMaterial.cost ||
        this.quantity !== this.originalMaterial.quantity
    }
  },
  watch: {
    '$store.state.materials.material': function () {
      this.originalMaterial = this.stateMaterial ? { ...this.stateMaterial } : null
      this.name = this.stateMaterial?.name
      this.cost = this.stateMaterial?.cost
      this.quantity = this.stateMaterial?.quantity
    }
  },
  methods: {
    open (materialId, projectId) {
      this.modal.show()

      this.originalMaterial = null
      this.projectId = projectId
      if (materialId) {
        this.$store.dispatch('materials/find', materialId)
      } else {
        this.$store.commit('materials/setMaterial', null)
      }
    },
    close () {
      this.modal.hide()
    },
    async save () {
      const updatedMaterial = { name: this.name, cost: this.cost, quantity: this.quantity }
      if (this.originalMaterial) {
        const combinedMaterial = Object.assign({ ...this.originalMaterial }, updatedMaterial)
        await this.$store.dispatch('materials/update', combinedMaterial)
      } else {
        const updatedMaterial = {
          projectId: this.projectId,
          name: this.name,
          cost: this.cost,
          quantity: this.quantity,
          sortOrder: this.$store.state.materials.materials.length
        }
        await this.$store.dispatch('materials/create', updatedMaterial)
      }
      this.modal.hide()
    }
    // checkValidity () {
    //   const errors = []
    //   if (!this.name || !this.name.trim()) {
    //     errors.concat('Name is a required field')
    //   }

    //   if (!this.cost) {
    //     errors.concat('Cost is a required field')
    //   }
    //   if (this.cost < 0) {
    //     errors.concat('Cost can not be negative')
    //   }

    //   if (!this.quantity) {
    //     errors.concat('Quantity is a required field')
    //   }
    //   if (this.quantity < 0) {
    //     errors.concat('Quantity is a required field')
    //   }
    // }
  },
  mounted () {
    this.modal = new Modal(this.$refs.modal, {})
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
