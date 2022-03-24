<script setup>
import { onMounted, ref } from 'vue'
import store from '../../../store'

let id = ref(0)
let playerId = ref(0)

function submitGame(){
	store.dispatch('getGame', {gameId: id.value})
	store.dispatch('getAllPlayers', {gameId: id.value})
	store.commit('setCurrentGameId', id.value)
	console.log(store.getters.getAllPlayers)
}

function submitPlayer(){
	store.dispatch('getSelectedPlayer', {gameId:id.value, id:playerId.value })
	store.commit('setCurrentPlayerId', playerId.value)
	console.log(store.getters.getSelectedPlayer)

}

function editPlayer(){
	store.dispatch('PutPlayer', store.getters.getSelectedPlayer)
	console.log(store.getters.getSelectedPlayer)
}

onMounted(() => {
	store.dispatch('getAllGames').then(
		console.log(store.getters.getAllGames))
})


</script>

<template>
  <div class='border m-2'>
    <h3 class='d-flex justify-content-center m-3'>
      Edit a Player
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
            for='playerName'
            class='block p-3'
          >Player List:</label>
          <select
            id='selectPlayer'
            v-model='playerId'
          >
            <option
              v-for='player in store.getters.getAllPlayers'
              :key='player'
              :value='player.id'
            >
              {{ player.id }}
            </option>
          </select>
          <button
            class='m-2'
            type='button'
            @click='submitPlayer()'
          >
            Submit
          </button>
        </div>
        <div class='m-2'>
          <label
            for='userId'
            class='block p-3'
          >User Id:</label>
          <input
            id='userId'
            v-model='store.getters.getSelectedPlayer.userId'
            type='text'
            placeholder='User id'
            class='border border-slate-800 input'
          >
        </div>
        <div class='m-2'>
          <label
            for='is_human'
            class='block p-3'
          >Is Human:</label>
          <select v-model='store.getters.getSelectedPlayer.is_Human'>
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
        <div class='m-2'>
          <label
            for='is_zombie'
            class='block p-3'
          >Is Patient Zero:</label>
          <select v-model='store.getters.getSelectedPlayer.is_Patient_Zero'>
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

        <div class='m-2'>
          <label
            for='biteCode'
            class='block p-3'
          >Bite Code:</label>
          <input
            id='biteCode'
            v-model='store.getters.getSelectedPlayer.bite_Code'
            type='text'
            placeholder='Bite Code'
            class='border border-slate-800 input'
          >
        </div>
      </fieldset>
    </form>
    <button
      class='m-3'
      @click='editPlayer()'
    >
      Save Changes
    </button>
  </div>
</template>

<style scoped>
.input{
    width: 80px;
}
</style>