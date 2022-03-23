<script setup>
import { onMounted, reactive, ref } from '@vue/runtime-core'
import store from '../../store'
import axios from 'axios'
import GameShowBiteCode from './GameShowBiteCode.vue'

onMounted(()=>{
	store.dispatch('getAllPlayers',{gameId:store.getters.getCurrentGameId})
  
})





function bitePlayer(CorrectCode,CheckCode,HumanId,story,lat,lng) {
	console.log(CorrectCode)
	console.log(HumanId)
	console.log(store.getters.getCurrentPlayerId)
	let current = new Date()
	console.log(current.toLocaleTimeString())
	let fixed_lat = 0.00
	let fixed_lng = 0.00
	console.log('this is lat: '+lat)
  	console.log('this is lat: '+lng)
	if(lat != undefined){
		fixed_lat = parseFloat(lat)
	} 
  	if(lng != undefined){
		fixed_lng = parseFloat(lng)
	} 
	
  	let kill = {
  	KillerId:store.getters.getCurrentPlayerId,
		VictimId:HumanId,
		Time_Of_Death: current.toLocaleTimeString(),
		Story:story,
		Lat:fixed_lat,
		Lng:fixed_lng
	}

	let changedPlayer = {
		userId: store.getters.getCurrentUserId, 
		bite_Code: CorrectCode
	}

	if(CorrectCode === CheckCode){
		store.dispatch('postKill',kill)

		axios.put('http://hvzapi.northeurope.azurecontainer.io/game/'+store.getters.getCurrentGameId+'/player/'+HumanId, {
			userId: store.getters.getCurrentUserId, 
			is_Human: false, 
			is_Patient_Zero: false,
			bite_Code: CorrectCode
     
		})
		console.log(kill)
	
	} else{
		console.log('Invalid code')
	}
	//store.dispatch('getAllPlayers',{gameId:store.getters.getCurrentGameId})
	store.dispatch('getAllPlayers',{gameId:store.getters.getCurrentGameId})
}


let key = 0

// function forceUpdate(){
// 	key ++
// 	console.log(key)
// }


let hidden = ref(true)

let bittenCode = reactive({})

let story = reactive({})
let lat = reactive({})
let lng = reactive({})
</script>

<template>
  <div
    class='text-center'
  >
    <GameShowBiteCode />
    <h3>List of Players</h3>
    <div>
      <ul>
        <li
          v-for='(playerItem,i) in $store.getters.getAllPlayers '
          :key='playerItem'
        >
          <template v-if='playerItem.is_Human === true || playerItem.is_Human === 1'>
            <div class='Human'>
              <p> Player: {{ playerItem.id }}</p>


              <input
                v-model='bittenCode[i]'
                placeholder='Bite Code'
              >
              <input
                v-model='story[i]'
                placeholder='Story of kill'
              >
              <input
              v-model ='lat[i]'
              placeholder='lat'
              >
               <input
              v-model ='lng[i]'
              placeholder='lng'>
              <button @click='bitePlayer(playerItem.bite_Code,bittenCode[i], playerItem.id,story[i],lat[i],lng[i])'>
                Sumbit Kill
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