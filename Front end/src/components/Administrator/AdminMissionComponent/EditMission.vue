<script setup>
import { onMounted, ref } from 'vue'
import store from '../../../store'

let id=ref(0)
let missionId=ref(0)

function submitGame(){
	store.dispatch('getGame', {gameId: id.value})
	store.dispatch('getAllMissions', {gameId: id.value})
	store.commit('setCurrentGameId', id.value)
	console.log(id.value)
}

function submitMission(){
	store.dispatch('getMission', {gameId:id.value, id:missionId.value })
	store.commit('setCurrentMissionId', missionId.value)

}

function editMission(){
	store.dispatch('PutMission', store.getters.getSelectedMission)
	console.log(store.getters.getSelectedMission)
}

onMounted(() => {
	store.dispatch('getAllGames').then(
		console.log(store.getters.getAllGames))
})
</script>

<template>
  <div class='border m-2'>
    <h3 class='d-flex justify-content-center m-3'>
      Edit Mission
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
            for='missionName'
            class='block p-3'
          >Mission List:</label>
          <select
            id='selectMission'
            v-model='missionId'
          >
            <option
              v-for='mission in store.getters.getAllMissions'
              :key='mission'
              :value='mission.id'
            >
              {{ mission.name }}
            </option>
          </select>
          <button
            class='m-2'
            type='button'
            @click='submitMission()'
          >
            Submit
          </button>
        </div>
        <div class='m-2'>
          <label
            for='missionName'
            class='block p-3'
          >Mission Name:</label>
          <input
            id='missionName'
            v-model='store.getters.getSelectedMission.name'
            type='text'
            class='border border-slate-800'
          >
        </div>

        <div class='m-4'>
          <textarea
            id='m_description'
            v-model='store.getters.getSelectedMission.description'
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
          <select v-model='store.getters.getSelectedMission.is_Human_Visible'>
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
          <select v-model='store.getters.getSelectedMission.is_Zombie_Visible'>
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
            v-model='store.getters.getSelectedMission.start_time'
            type='time'
            class='border border-slate-800 m-2 input'
          >
          <label
            for='endTime'
            class='block p-3'
          >End Time:</label>
          <input
            id='endTime'
            v-model='store.getters.getSelectedMission.end_time'
            type='time'
            class='border border-slate-800 m-2 input'
          >
        </div>
      </fieldset>
    </form>
    <button
      class='m-3'
      @click='editMission()'
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