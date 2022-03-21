<template>
  <ul>
    <li
      v-for='gameItem in $store.getters.getAllGames '
      :key='gameItem'
    >
      <div class='list-group w-75 p-3 border'>
        <!-- <button type="button" class="list-group-item list-group-item-action">Game Lobbies</button> -->
        <button class='list-group-item list-group-item-action active'>
          Game {{ gameItem.id }}
        </button>
        <p>{{ gameItem.name }}</p>
        <template v-if='gameItem.game_state === 1'>
          Starting soon
        </template>

        <template v-else-if='gameItem.game_state ===2'>
          Ongoing
        </template>
        <template v-else-if='gameItem.game_state ===3'>
          Finish
        </template>
      </div>
    </li>
  </ul>
</template>

<script setup>
import { onMounted } from 'vue'
import { useStore } from 'vuex'
const store = useStore()
onMounted(() => {
	store.dispatch('getAllGames'),
	store.dispatch('getAllSquads', {gameId:1})
	store.dispatch('getSquad', {gameId:1, squadId:1})
})
</script>

<style>
</style>