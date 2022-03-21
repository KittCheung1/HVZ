<script setup>

import { onMounted } from 'vue'
import { useStore } from 'vuex'
const store = useStore()
onMounted(() => {
	store.dispatch('getAllKills').then(
		console.log(store.getters.getAllKills))
})

function deleteKill(){
	alert('Deleted kill')
}

</script>

<template>
  <div class='border m-2'>
    <h3 class='d-flex justify-content-center m-3'>
      Delete Kill
    </h3>
    <form class>
      <fieldset class='border-2 border-solid border-slate-500'>
        <div class='m-2'>
          <label
            for='killName'
            class='block p-3'
          >Kill List:</label>
          <select
            id='selectKill'
            v-model='selectedKill'
          >
            <option
              v-for='kill in $store.getters.getAllKill'
              :key='kill'
            >
              {{ kill.name }}
            </option>
          </select>
        </div>
        <button
          class='m-3'
          @click='deleteKill()'
        >
          Delete Kill
        </button>
      </fieldset>
    </form>
  </div>
</template>

<style>
</style>