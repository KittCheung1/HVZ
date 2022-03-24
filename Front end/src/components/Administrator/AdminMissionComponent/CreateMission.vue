<script setup>
import {onMounted, reactive, ref } from 'vue'
import store from '../../../store'

let id=ref(0)
let is_Human_Visible = ref(false)
let is_Zombie_Visible =ref(false)
let description = ref('')
let start_time = ref('')
let end_time = ref('')

let obj = reactive({
	name: name,
	is_Human_Visible:is_Human_Visible,
	is_Zombie_Visible:is_Zombie_Visible,
	description:description,
	start_time:start_time,
	end_time:end_time
})

function createMission(){
  	store.dispatch('postMission',obj)
	console.log(obj)
}

function submitGame(){
	store.dispatch('getGame', {gameId: id.value})
	console.log(id.value)
}

onMounted(() => {
	store.dispatch('getAllGames')
})

</script>

<template>
  <div class='border m-2'>
    <h3 class='d-flex justify-content-center m-3'>
      Create Mission
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
            for='missionName'
            class='block p-3'
          >Mission name:</label>
          <input
            id='missionName'
            v-model='obj.name'
            type='text'
            placeholder='Mission name'
            class='border border-slate-800'
          >
        </div>

        <div class='m-4'>
          <textarea
            id='m_description'
            v-model='obj.description'
            type='textarea'
            placeholder='Mission Description'
            class='border border-slate-800'
            rows='4'
            cols='33'
          />
        </div>
        <div class='m-2'>
          <label
            for='is_human'
            class='block p-3'
          >Is Human:</label>
          <select v-model='is_Human_Visible'>
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
          >Is Zombie:</label>
          <select v-model='is_Zombie_Visible'>
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
            for='startTime'
            class='block p-3'
          >Start Time:</label>
          <input
            id='startTime'
            v-model='obj.start_time'
            type='time'
            class='border border-slate-800 m-2 input'
          >
          <label
            for='endTime'
            class='block p-3'
          >End Time:</label>
          <input
            id='endTime'
            v-model='obj.end_time'
            type='time'
            class='border border-slate-800 m-2 input'
          >
        </div>
      </fieldset>
    </form>
    <button
      class='m-3'
      @click='createMission()'
    >
      Create Mission
    </button>
  </div>
</template>

<style scoped>
.input {
    width: 70px;
}
</style>