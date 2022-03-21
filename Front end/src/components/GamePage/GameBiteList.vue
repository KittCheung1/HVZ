<script setup>
import { onMounted } from 'vue'
import { useRouter } from 'vue-router'
import store from '../../store'



onMounted(()=>{
	store.dispatch('getAllKills',{gameId:store.getters.getCurrentGameId})
})

</script>

<template>
  <div class='text-center'>
    <h3>List of Kills</h3>
    <div>
      <ul>
        <li
          v-for='killItem in $store.getters.getAllKills '
          :key='killItem'
        >
          <p>Player: {{ killItem.killerId }} &#128481; Player: {{ killItem.victimId }} at {{ killItem.time_Of_Death }} by "{{ killItem.story }}"</p>
        </li>
      </ul>
    </div>
  </div>
</template>


<style scoped>
ul{
    list-style-type: none;
}
li{
    border: 2px solid black;
}
</style>