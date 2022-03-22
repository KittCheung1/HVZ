<script setup>
import { reactive, ref } from 'vue'
import store from '../../../store'
    
let gameName = ref('')
let gameState = ref(0)
let Nw_Lat = ref('')
let Nw_Lng = ref('')
let Se_Lat = ref('')
let Se_Lng = ref('')

let obj = reactive({
	Name: gameName.value,
	GameState: gameState.value,
	Nw_Lat: Nw_Lat.value,
	Nw_Lng: Nw_Lng.value,
	Se_Lat: Se_Lat.value,
	Se_Lng: Se_Lng.value
})

function createGame(){
	store.dispatch('postGame',obj)
	console.log(obj)
}

</script>

<template>
  <div class='border m-2 '>
    <h3 class='d-flex justify-content-center m-3'>
      Create Game
    </h3>
    <form class>
      <fieldset class='border-2 border-solid border-slate-500'>
        <div class='m-2'>
          <label
            for='gameName'
            class='block p-3'
          >Game Name:</label>
          <input
            id='gameName'
            v-model='obj.Name'
            type='text'
            placeholder='Game Name'
            class='border border-slate-800'
          >
        </div>

        <div class='m-2 row '>
          <div class='col-xs-6'>
            <label
              for='gameState'
              class='block p-3'
            >Game State:</label>
            <select
              id='selectGameState'
              v-model.number='obj.GameState'
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
          </div>

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
            v-model='obj.Nw_Lat'
            type='number'
            placeholder='number'
            class='border border-slate-800 m-2 input '
          >
          <input
            id='Nw_Lng'
            v-model='obj.Nw_Lng'
            type='number'
            placeholder='Nw_Lng'
            class='border border-slate-800 m-2 input'
          >
          <input
            id='Se_Lat'
            v-model='obj.Se_Lat'
            type='number'
            placeholder='Se_Lat'
            class='border border-slate-800 m-2 input'
          >
          <input
            id='Se_Lng'
            v-model='obj.Se_Lng'
            type='number'
            placeholder='Se_Lng'
            class='border border-slate-800 m-2 input'
          >
        </div>
      </fieldset>
    </form>
    <button
      type='button'
      class='m-3' 
      @click='createGame()'
    >
      Create
    </button>
  </div>
</template>

<style scoped>
.input{
    width: 70px;
}
</style>