<script setup>
import GameDashboard from '../components/GamePage/GameDashboard.vue'
import store from '../store'

</script>


<template>
  <h1>
    Game Page
  </h1>

  <div class='m-5'>
    <GameDashboard />
  </div>

  <div>
    <router-link to='/'>
      home
    </router-link>
  </div>
</template>

<style></style>