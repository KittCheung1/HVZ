<template>
  <ul >
    <li
      v-for='gameItem in $store.getters.getAllGames '
      :key='gameItem'
    >
      <div class='list-group w-75 p-3 border'>
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
        <p>Amount of Players : {{ gameItem.players }}</p>
      </div>
    </li>
  </ul>
</template>

<script setup>
import { onMounted } from 'vue'
import { useStore } from 'vuex'
const store = useStore()
onMounted(() => {
	store.dispatch('getAllGames').then(
	console.log(store.getters.getAllGames))
})

</script>

<style>
</style>