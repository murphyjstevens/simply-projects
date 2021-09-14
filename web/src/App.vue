<template>
  <div id="app" class="app-content d-flex flex-row justify-content-center">
    <div class="content">
      <router-view />
    </div>
  </div>
</template>

<script>
export default {
  name: 'App'
}
</script>

<style scoped lang="scss">
  .app-content {
    .content {
      padding: 10px;
      width: 800px;
    }
  }
</style>
