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
              <div class="col-sm-12">
                <label for="dialog-name" class="form-label">Name</label>
                <input id="dialog-name"
                  type="text"
                  class="form-control"
                  :class="{ 'is-invalid': v$.name.$error }"
                  placeholder="Name"
                  v-model="name"
                  @blur="v$.name.$touch">
                <div class="input-errors" v-for="error of v$.name.$errors" :key="error.$uid">
                  <div class="error-msg invalid-feedback d-block">{{ error.$message }}</div>
                </div>
              </div>
              <div class="col-sm-12 col-md-6">
                <label for="dialog-cost" class="form-label">Cost</label>
                <div id="dialog-cost"
                  class="input-group has-validation">
                  <span class="input-group-text">$</span>
                  <input type="number"
                    class="form-control"
                    :class="{ 'is-invalid': v$.cost.$error }"
                    placeholder="Cost"
                    v-model.number="cost"
                    @blur="v$.cost.$touch">
                </div>
                <div class="input-errors" v-for="error of v$.cost.$errors" :key="error.$uid">
                  <div class="error-msg invalid-feedback d-block">{{ error.$message }}</div>
                </div>
              </div>
              <div class="col-sm-12 col-md-6">
                <label for="dialog-quantity" class="form-label">Quantity</label>
                <input id="dialog-quantity"
                  type="number"
                  class="form-control"
                  :class="{ 'is-invalid': v$.quantity.$error }"
                  placeholder="Quantity"
                  v-model.number="quantity"
                  @blur="v$.quantity.$touch">
                <div class="input-errors" v-for="error of v$.quantity.$errors" :key="error.$uid">
                  <div class="error-msg invalid-feedback d-block">{{ error.$message }}</div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="modal-footer">
          <button type="button"
            class="btn btn-primary"
            @click="save()"
            :disabled="!isDirty">Save</button>
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
import useVuelidate from '@vuelidate/core'
import { integer, minValue, numeric, required } from '@vuelidate/validators'

export default {
  name: 'MaterialDialog',
  setup () {
    return { v$: useVuelidate() }
  },
  data () {
    return {
      originalMaterial: null,
      projectId: null,
      name: null,
      cost: null,
      quantity: null
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
      this.$store.commit('materials/setMaterial', null)
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
          sortOrder: this.$store.state.materials.projectMaterials.length
        }
        await this.$store.dispatch('materials/create', updatedMaterial)
      }
      this.close()
    }
  },
  mounted () {
    this.modal = new Modal(this.$refs.modal, {})
  },
  validations () {
    return {
      name: { required },
      cost: { required, numeric },
      quantity: { required, integer, minValue: minValue(1) }
    }
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
