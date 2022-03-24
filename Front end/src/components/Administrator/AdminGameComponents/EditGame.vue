<script setup>
import { onMounted, reactive, ref } from 'vue'
import store from '../../../store'

let id=ref(0)

function submitGame(){
	store.dispatch('getGame', {gameId: id.value})
	store.commit('setCurrentGameId', id.value)
}


function editGame(){
	store.dispatch('PutGame',store.getters.getSelectedGame)
	console.log(store.getters.getCurrentGameId)
	console.log(store.getters.getSelectedGame)
}

onMounted(() => {
	store.dispatch('getAllGames').then(
		console.log(store.getters.getAllGames))
})


</script>

<template>
  <div class='border m-2'>
    <h3 class='d-flex justify-content-center m-3'>
      Edit Game
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
      </fieldset>
    </form>
    <form>
      <div>
        <div class='m-2'>
          <label
            for='gameName'
            class='block p-3'
          >Game Name:</label>
          <input
            id='gameState'
            v-model='store.getters.getSelectedGame.name'
            type='text'
            class='border border-slate-800'
          >
        </div>
        <div class='m-2'>
          <label
            for='gameState'
            class='block p-3'
          >Game State:</label>
          <select
            id='selectGame'
            v-model.number='store.getters.getSelectedGame.game_state'
          >
            <option
              selected
            >
              Select game state 
            </option>
            <option>
              0
            </option>
            <option>
              1
            </option>
            <option>
              2
            </option>
            <option>
              3
            </option>
          </select>
          <div class='col-xs-6'>
            <p>0 = Stateless</p>
            <p>1 = Waiting for more players</p>
            <p>2 = Ongoing</p>
            <p>3 = Finished</p>
          </div>
        </div>
        <div class='m-2 coordinates'>
          <label
            for='Nw_Lat'
            class='block p-3'
          >Coordinates:</label>
          <input
            id='Nw_Lat'
            v-model='store.getters.getSelectedGame.nw_lat'
            type='text'
            placeholder='Nw_Lat'
            class='border border-slate-800 m-2 input '
          >
          <input
            id='Nw_Lng'
            v-model='store.getters.getSelectedGame.nw_lng'
            type='text'
            placeholder='Nw_Lng'
            class='border border-slate-800 m-2 input'
          >
          <input
            id='Se_Lat'
            v-model='store.getters.getSelectedGame.se_lat'
            type='text'
            placeholder='Se_Lat'
            class='border border-slate-800 m-2 input'
          >
          <input
            id='Se_Lng'
            v-model='store.getters.getSelectedGame.se_lng'
            type='text'
            placeholder='Se_Lng'
            class='border border-slate-800 m-2 input'
          >
        </div>
      </div>
    </form>
    <button
      type='button'
      class='m-3'
      @click='editGame()'
    >
      Save Changes
    </button>
  </div>
</template>

<style scoped>
.input{
    width: 70px;
}
</style>