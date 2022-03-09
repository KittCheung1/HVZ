<template>
<div class="list-group w-50 p-3">
  <button type="button" class="list-group-item list-group-item-action active">
    Game Lobbies
  </button>
 
  <button type="button" class="list-group-item list-group-item-action" data-toggle="collapse" data-target="#demo">Game 1
    <span class="badge alert-danger">Full</span>
  </button>
  <button type="button" class="list-group-item list-group-item-action">Game 2
    <span class="badge alert-success">Active</span>
  </button>
  <button type="button" class="list-group-item list-group-item-action">Game 3 
    <span class="badge alert-success">Active</span>
  </button>
  <button type="button" class="list-group-item list-group-item-action">Game 4
    <span class="badge alert-secondary">Offline</span>
  </button>
</div>

<div id="demo" class="collapse">
Lorem ipsum dolor text....
</div>



</template>

<script setup>
import GameLobby from './GameLobby.vue'

</script>

<style>

</style>