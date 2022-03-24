<script setup>
import {onMounted, reactive, ref } from 'vue'
import store from '../../../store'

let id = ref(0)
let squadId = ref(0)

function submitGame(){
	store.dispatch('getGame', {gameId: id.value})
	store.dispatch('getAllSquads', {gameId: id.value})
	store.commit('setCurrentGameId', id.value)
	console.log(id.value)
}

function submitSquad(){
	store.dispatch('getSquad', {gameId:id.value, id:squadId.value })
	store.commit('setSelectedSquadId', squadId.value)
	console.log(squadId.value)
}

function editSquad(){
	store.dispatch('PutSquad', store.getters.getSelectedSquad)
	console.log(store.getters.getSelectedSquad)
}

onMounted(() => {
	store.dispatch('getAllGames').then(
		console.log(store.getters.getAllGames))
})
</script>

<template>
  <div class='border m-2'>
    <h3 class='d-flex justify-content-center m-3'>
      Edit Squad
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
              v-for='game in store.getters.getAllGames'
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
          >Squad List:</label>
          <select
            id='selectSquad'
            v-model='squadId'
          >
            <option
              v-for='squad in store.getters.getAllSquads'
              :key='squad'
              :value='squad.id'
            >
              {{ squad.name }}
            </option>
          </select>
          <button
            class='m-2'
            type='button'
            @click='submitSquad()'
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
            v-model='store.getters.getSelectedSquad.name'
            type='text'
            class='border border-slate-800'
          >
        </div>
        <div class='m-2'>
          <label
            for='is_human'
            class='block p-3'
          >Is Human:</label>
          <select v-model='store.getters.getSelectedSquad.isHuman'>
            <option
              disabled
              value
            >
              Please select one
            </option>
            <option :value='true'>
              True
            </option>
            <option :value='false'>
              False
            </option>
          </select>
        </div>
      </fieldset>
    </form>
    <button
      class='m-3'
      @click='editSquad()'
    >
      Save Changes
    </button>
  </div>
</template>

<style scoped>
.input {
    width: 70px;
}
</style>