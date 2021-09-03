<template>
  <div class="modal fade" id="exampleModal" ref="modal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <div class="container-fluid">
            <div class="row">
              <div class="col-sm-12 col-md-6">
                <input type="text" class="form-control" placeholder="Name" v-model="name">
              </div>
              <div class="col-sm-12 col-md-6">
                <div class="input-group">
                  <span class="input-group-text">$</span>
                  <input type="text" class="form-control" placeholder="Total Cost" v-model="totalCost">
                </div>
              </div>
              <div class="col-sm-12">
                <textarea class="form-control" v-model="description"></textarea>
              </div>
            </div>
          </div>
        </div>
        <div class="modal-footer">
          <button type="button" label="Save" class="btn btn-primary" v-on:click="save()"></button>
          <button type="button" label="Close" class="btn btn-secondary" v-on:click="close()"></button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { Modal } from 'bootstrap'

export default {
  name: 'AddProject',
  data () {
    return {
      modal: Modal,
      name: String,
      totalCost: Number,
      description: String
    }
  },
  mounted () {
    // this.modal = new Modal(this.$refs.modal, {})
  },
  methods: {
    open () {
      // this.modal.open()
    },
    close () {
      // this.modal.hide()
    }
  }
}
</script>

<style scoped>
</style>
