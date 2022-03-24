<script setup>

import { onMounted } from 'vue'
import { useStore } from 'vuex'
const store = useStore()
onMounted(() => {
	store.dispatch('getAllSquads').then(
		console.log(store.getters.getAllSquads))
})

function deleteSquad() {
	alert('Deleted squad')
}

</script>

<template>
  <div class='border m-2'>
    <h3 class='d-flex justify-content-center m-3'>
      Delete Squad
    </h3>
    <form class>
      <fieldset class='border-2 border-solid border-slate-500'>
        <div class='m-2'>
          <label
            for='squadName'
            class='block p-3'
          >Squad List:</label>
          <select
            id='selectSquad'
            v-model='selectedSquad'
          >
            <option
              v-for='squad in $store.getters.getAllSquads'
              :key='squad'
            >
              {{ squad.name }}
            </option>
          </select>
        </div>
        <button
          class='m-3'
          @click='deleteSquad()'
        >
          Delete Squad
        </button>
      </fieldset>
    </form>
  </div>
</template>

<style>
</style>