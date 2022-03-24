<script setup>
import { onMounted, ref } from '@vue/runtime-core'
import store from '../../store'


let current = new Date()




function sendChat(message) {
	let chatObj ={
		PlayerId: store.getters.getCurrentPlayerId,
		SquadId: null,
		Message: message,
		Is_Human_Global: true,
		Is_Zombie_Global: true,
		Chat_Time:current.toLocaleTimeString() ,
 
	}


	current = new Date()

	console.log(chatObj)
	store.dispatch('postChat',chatObj)
}
let message = ref('')
</script>

<template>
  <div>
    <input
      v-model='message'
      placeholder='Message'
    >
    <button @click='sendChat(message)'>
      Send
    </button>
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