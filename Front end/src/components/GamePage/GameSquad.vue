<script setup>
import { onMounted, ref } from 'vue'
import { useRouter } from 'vue-router'
import store from '../../store'
import GameSquadCreation from './GameSquadCreation.vue'


onMounted(()=>{
	store.dispatch('getAllSquads',{gameId:store.getters.getCurrentGameId})
})


function joinSquad(squadid, IsHuman){
  	store.commit('setSelectedSquadId',squadid)
  	console.log('SquadId: '+store.getters.getSelectedSquadId)
	if(IsHuman){
		console.log('You: '+store.getters.getCurrentPlayerId+'have joined a human squad wtih id :'+squadid+', Welcome!')
		
	} else {
		console.log('You have joined a zombie squad with id:'+squadid+', Time to hunt!')
	}
	let member = {
		Rank: 'Private',
		SquadId:squadid
	}


	store.dispatch('PostSquadmemberIfNotFound',member)
}


function showSquadmembers(squadid){
	hidden.value = !hidden.value

	store.dispatch('getAllSquadmembers',{gameId:store.getters.getCurrentGameId, squadId:squadid})

	
}

let hidden = ref(false)
</script>

<template>
  <GameSquadCreation />
  <div class='text-center'>
    <h3>List of Squads</h3>
    <div>
      <ul>
        <li
          v-for='squadItem in $store.getters.getAllSquads '
          :key='squadItem'
        >
          <template v-if='squadItem.isHuman === true || squadItem.isHuman === 1'>
            <div class='Human'>
              <h5>{{ squadItem.name }}</h5>
              <p> Squad Id: {{ squadItem.id }}</p>
              <template v-if='$store.getters.getSelectedPlayer.is_Human'> 
                <button @click='joinSquad(squadItem.id, squadItem.isHuman)'>
                  Join Squad
                </button>
                <button @click='showSquadmembers(squadItem.id)'>
                  Console members
                </button>
              </template>
            </div>
          </template>
          <template v-else>
            <div class='Zombie'>
              <h5>{{ squadItem.name }}</h5>
              <p> Squad Id: {{ squadItem.id }}</p>
              <template v-if='!$store.getters.getSelectedPlayer.is_Human'> 
                <button @click='joinSquad(squadItem.id, squadItem.isHuman)'>
                  Join Squad
                </button>
                <button @click='showSquadmembers(squadItem.id)'>
                  Console members
                </button>
              </template>
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
li{
    border: 2px solid black;
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