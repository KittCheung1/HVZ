<script setup>
import { onMounted } from 'vue'
import { useStore } from 'vuex'
const store = useStore()
onMounted(() => {
	store.dispatch('getAllGames').then(
		console.log(store.getters.getAllGames))
})
</script>

<template>
  <div class='border m-2'>
    <h3 class='d-flex justify-content-center m-3'>
      Create Squad
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
        <div class='m-2'>
          <label
            for='squadName'
            class='block p-3'
          >Squad Name:</label>
          <input
            id='squadName'
            v-model='squadName'
            type='text'
            placeholder='Squad Name'
            class='border border-slate-800'
          >
        </div>

        <div class='m-2'>
          <label
            for='is_human'
            class='block p-3'
          >Type:</label>
          <select v-model='is_human'>
            <option
              disabled
              value
            >
              Please select one
            </option>
            <option :value='true'>
              Human
            </option>
            <option :value='false'>
              Zombie
            </option>
          </select>
        </div>
      </fieldset>
    </form>
    <button class='m-3'>
      Create
    </button>
  </div>
</template>

<style scoped>
</style>