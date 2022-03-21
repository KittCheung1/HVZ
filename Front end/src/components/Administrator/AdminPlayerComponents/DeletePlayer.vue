<script setup>

import { onMounted } from 'vue'
import { useStore } from 'vuex'
const store = useStore()
onMounted(() => {
	store.dispatch('getAllPlayers').then(
		console.log(store.getters.getAllPlayers))
})

function deletePlayer(){
	alert('Deleted player')
}

</script>

<template>
  <div class='border m-2'>
    <h3 class='d-flex justify-content-center m-3'>
      Delete Player
    </h3>
    <form class>
      <fieldset class='border-2 border-solid border-slate-500'>
        <div class='m-2'>
          <label
            for='playerName'
            class='block p-3'
          >Player List:</label>
          <select
            id='selectPlayer'
            v-model='selectedPlayer'
          >
            <option
              v-for='player in $store.getters.getAllPlayers'
              :key='player'
            >
              {{ player.name }}
            </option>
          </select>
        </div>
        <button
          class='m-3'
          @click='deletePlayer()'
        >
          Delete Player
        </button>
      </fieldset>
    </form>
  </div>
</template>

<style>
</style>