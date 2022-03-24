<script setup>
import {onMounted, reactive, ref } from 'vue'
import store from '../../../store'

let id=ref(0)
let name = ref('')
let isHuman = ref(false)

let obj = reactive({
	name: name,
	is_Human:isHuman,
})

function submitGame(){
	store.dispatch('getGame', {gameId: id.value})
	console.log(id.value)
}

function createSquad(){
	store.dispatch('postSquad',obj)
}

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
            v-model='id'
          >
            <option
              v-for='game in $store.getters.getAllGames'
              :key='game'
              :value='game.id'
            >
              {{ game.name }}
            </option>
          </select>
          <button
            class='m-2'
            type='button'
            @click='submitGame()'
          >
            Submit
          </button>
        </div>
        <div class='m-2'>
          <label
            for='squadName'
            class='block p-3'
          >Squad Name:</label>
          <input
            id='squadName'
            v-model='obj.name'
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
          <select v-model='obj.isHuman'>
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
    <button
      class='m-3'
      @click='createSquad()'
    >
      Create
    </button>
  </div>
</template>

<style scoped>
</style>