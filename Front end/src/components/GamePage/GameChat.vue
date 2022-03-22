<script setup>
import { onMounted } from '@vue/runtime-core'
import store from '../../store'
import GameSendChat from './GameSendChat.vue'


onMounted(()=>{
	store.dispatch('getAllChats',{gameId:store.getters.getCurrentGameId})
})


function bitePlayer(bitecode) {
	console.log(bitecode)
}
</script>

<template>
  <div class='text-center'>
    <h3>Global Game Chat</h3>
    <div>
      <ul>
        <GameSendChat />
        <p>Time | Player Id| Message</p>
        <li
          v-for='chatItem in $store.getters.getAllChats '
          :key='chatItem'
        >
          <p>{{ chatItem.chat_Time }}| Player Id: {{ chatItem.playerId }} | Message: {{ chatItem.message }}</p>
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