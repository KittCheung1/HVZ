<script setup>
import { onMounted } from 'vue'
import { useRouter } from 'vue-router'
import store from '../../store'



onMounted(()=>{
	store.dispatch('getAllMissions',{gameId:store.getters.getCurrentGameId})
})

</script>

<template>
  <div class='text-center'>
    <h3>List of Missions</h3>
    <div>
      <ul>
        <li
          v-for='missionItem in $store.getters.getAllMissions '
          :key='missionItem'
        >
          <h5> Mission {{ missionItem.id }}</h5>
          <p>Name: {{ missionItem.name }}</p>
          <p>Objective:</p>
          <p>{{ missionItem.description }}</p>
          <p>Start Time: {{ missionItem.start_time }}</p>
          <p>End Time: {{ missionItem.end_time }}</p>
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