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
      Edit Chat
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
            for='playerId'
            class='block p-3'
          >Player Id:</label>
          <input
            id='playerId'
            v-model='playerId'
            type='text'
            placeholder='Player id'
            class='border border-slate-800 input'
          >
        </div>
        <div class='m-2'>
          <label
            for='squadId'
            class='block p-3'
          >Squad Id:</label>
          <input
            id='squadId'
            v-model='squadId'
            type='text'
            placeholder='Squad id'
            class='border border-slate-800 input'
          >
        </div>
        <div class='m-4'>
          <textarea
            id='chat_message'
            v-model='chat_message'
            type='textarea'
            placeholder='Message'
            class='border border-slate-800'
            rows='4'
            cols='33'
          />
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

        <div class='m-2'>
          <label
            for='chatTime'
            class='block p-3'
          >Chat time:</label>
          <input
            id='chatTime'
            v-model='chatTime'
            type='time'
            class='border border-slate-800 input'
          >
        </div>
      </fieldset>
    </form>
    <button class='m-3'>
      Save Changes
    </button>
  </div>
</template>

<style scoped>
.input{
    width: 70px;
}
</style>