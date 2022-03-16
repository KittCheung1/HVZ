<script setup>
import { onMounted } from '@vue/runtime-core'
import store from '../../store'


onMounted(()=>{
	store.dispatch('getAllPlayers',{gameId:store.getters.getCurrentGameId})
})


function bitePlayer(bitecode) {
	console.log(bitecode)
}
</script>

<template>
  <div class='text-center'>
    <h3>List of Players</h3>
    <div>
      <ul>
        <li
          v-for='playerItem in $store.getters.getAllPlayers '
          :key='playerItem'
        >
          <template v-if='playerItem.is_Human === true || playerItem.is_Human === 1'>
            <div class='Human'>
              <p> Player: {{ playerItem.id }}</p>
              <button @click='bitePlayer(playerItem.bite_Code)'>
                Bite
              </button>
            </div>
          </template>
          <template v-else>
            <div class='Zombie'>
              <p> Player: {{ playerItem.id }}</p>
            </div>
          </template>
        </li>
      </ul>
    </div>
  </div>
</template>


<style scoped>

ul{
    list-style-type: none;
}
.Zombie{
    background-color: #f7ae9c;
    border: 2px solid black;
    margin-bottom: 2%;
}
.Human{
    background-color: #befaea;
    border: 2px solid black;
    margin-bottom: 2%;
}


</style>