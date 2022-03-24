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
      Create a Kill
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
            for='killerId'
            class='block p-3'
          >Killer Id:</label>
          <select
            id='killerId'
            v-model='selectedKiller'
          >
            <option
              v-for='killer in $store.getters.getAllKillerIds'
              :key='killer'
            >
              {{ killer.id }}
            </option>
          </select>
        </div>
        <div class='m-2'>
          <label
            for='victimId'
            class='block p-3'
          >Victim Id:</label>
          <select
            id='victimId'
            v-model='selectedVictim'
          >
            <option
              v-for='victim in $store.getters.getAllVictimIds'
              :key='victim'
            >
              {{ victim.id }}
            </option>
          </select>
        </div>
        <div class='m-2'>
          <label
            for='tod'
            class='block p-3'
          >Time of Death:</label>
          <input
            id='tod'
            v-model='tod'
            type='time'
            placeholder='tod'
            class='border border-slate-800'
          >
        </div>
        <div class='m-4'>
          <textarea
            id='kill_description'
            v-model='kill_description'
            type='textarea'
            placeholder='Story Description'
            class='border border-slate-800'
            rows='4'
            cols='33'
          />
        </div>
        <div class='m-2 coordinates'>
          <label
            for='Lat'
            class='block p-3'
          >Coordinates:</label>
          <input
            id='Lat'
            v-model='Lat'
            type='text'
            placeholder='Lat'
            class='border border-slate-800 m-2 input'
          >
          <input
            id='Lng'
            v-model='Lng'
            type='text'
            placeholder='Lng'
            class='border border-slate-800 m-2 input'
          >
        </div>
      </fieldset>
    </form>
    <button class='m-3'>
      Create
    </button>
  </div>
</template>

<style scoped>
.input {
    width: 70px;
}
</style>