<script setup>

import { onMounted } from 'vue'
import { useStore } from 'vuex'
const store = useStore()
onMounted(() => {
	store.dispatch('getAllGames').then(
		console.log(store.getters.getAllGames))
})

function deleteGame(){
	alert('Deleted game')
}

</script>

<template>
  <div class='border m-2'>
    <h3 class='d-flex justify-content-center m-3'>
      Delete Game
    </h3>
    <form class>
      <fieldset class='border-2 border-solid border-slate-500'>
        <div class='m-2'>
          <label
            for='gameName'
            class='block p-3'
          >Game List:</label>
          <select
            id='selectGame'
            v-model='selectedGame'
          >
            <option
              v-for='game in $store.getters.getAllGames'
              :key='game'
            >
              {{ game.name }}
            </option>
          </select>
        </div>
        <button
          class='m-3'
          type='button'
          @click='deleteGame()'
        >
          Delete Game
        </button>
      </fieldset>
    </form>
  </div>
</template>

<style>
</style>