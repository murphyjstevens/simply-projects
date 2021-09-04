<template>
  <div class="sidebar">
    <h3 class="sidebar-title">Simply Projects</h3>
  </div>
</template>

<script>
export default {
  name: 'Sidebar'
}
</script>

<style scoped lang="scss">
  .sidebar {
    position: fixed;
    top: 0;
    bottom: 0;
    width: 200px;
    background-color: white;
    box-shadow: 0 0.5px 5px #888888;

    .sidebar-title {
      margin: 15px 5px 15px 5px;
      text-align: center;
    }
  }
</style>
