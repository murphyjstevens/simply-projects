<template>
  <div id="app">
    <Sidebar />
    <div class="content">
      <router-view />
    </div>
  </div>
</template>

<script>
import Sidebar from './components/Sidebar.vue'

export default {
  name: 'App',
  components: {
    Sidebar
  }
}
</script>

<style>
  body {
    background-color: whitesmoke;
  }

  .content {
    margin-left: 200px;
    padding: 10px;
  }
</style>
