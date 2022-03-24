<script setup>
import { onMounted, reactive, ref } from 'vue'
import { useRouter } from 'vue-router'
import store from '../../store'
import GameSquadCreation from './GameSquadCreation.vue'


onMounted(()=>{
	store.dispatch('getAllSquads',{gameId:store.getters.getCurrentGameId})
	console.log(store.getters.getAllSquadmembersInGame)
	store.dispatch('getAllSquadmembersInGame',{ gameId:store.getters.getCurrentGameId}).then(checkIfInSquad())

})


function joinSquad(squadid, IsHuman, i){
  	store.commit('setSelectedSquadId',squadid)
  	console.log('SquadId: '+store.getters.getSelectedSquadId)
	if(IsHuman){
		console.log('You: '+store.getters.getCurrentPlayerId+'have joined a human squad wtih id :'+squadid+', Welcome!')
		
	} else {
		console.log('You'+store.getters.getCurrentPlayerId+' have joined a zombie squad with id:'+squadid+', Time to hunt!')
	}
	let member = {
		Rank: rank[i],
		SquadId:squadid
	}

	console.log(member)
	store.dispatch('PostSquadmemberIfNotFound',member)
	if(member.Rank != undefined){
		inSquad.value = true
	}
}

function checkIfInSquad(){
  
	for(let i = 0; i < store.getters.getAllSquadmembersInGame.length; i++){
		console.log(store.getters.getAllSquadmembersInGame[i].playerId)
		if(store.getters.getCurrentPlayerId === store.getters.getAllSquadmembersInGame[i].playerId){
			inSquad.value = true
			return
			
		}
	}
	
}

function leaveSquad(squadId, squadmemberId){
	console.log('squad Id:'+squadId+'memberId: '+squadmemberId)
	store.dispatch('deleteSquadmember',{SquadId:squadId,SquadmemberId:squadmemberId})
	inSquad.value = false
}

let rank = reactive([])
let inSquad = ref(false)
let hidden = ref(false)
</script>

<template>
  <GameSquadCreation />
  <div class='text-center'>
    <h3>List of Squads</h3>
    <div>
      <ul>
        <li
          v-for='(squadItem,i) in $store.getters.getAllSquads '
          :key='squadItem'
        >
          <template v-if='squadItem.isHuman === true || squadItem.isHuman === 1'>
            <div class='Human'>
              <h5>{{ squadItem.name }}</h5>
              <p> Squad Id: {{ squadItem.id }}</p>
              <template v-if='$store.getters.getSelectedPlayer.is_Human'> 
                <div v-if='inSquad == false'>
                  <select
                    v-model='rank[i]'
                  >
                    <option
                      value=''
                      disabled
                    >
                      Choose your rank
                    </option>
                    <option selected>
                      Scout
                    </option>
                    <option selected>
                      Fighter
                    </option>
                    <option> Technician </option>
                  </select>
                  <button @click='joinSquad(squadItem.id, squadItem.isHuman,i)'>
                    Join Squad
                  </button>
                </div>
             
                <ul>
                  <li
                    v-for='memberItem, in $store.getters.getAllSquadmembersInGame'
                    :key='memberItem'
                    class='squadmember'
                  >
                    <template v-if='memberItem.squadId === squadItem.id'>
                      <p> Rank: {{ memberItem.rank }}</p>
                      <button @click='leaveSquad(squadItem.id,memberItem.id)'>
                        Leave Squad
                      </button>
                    </template>
                  </li>
                </ul>
              </template>
            </div>
          </template>
          <template v-else>
            <div class='Zombie'>
              <h5>{{ squadItem.name }}</h5>
              <p> Squad Id: {{ squadItem.id }}</p>
              <template v-if='!$store.getters.getSelectedPlayer.is_Human'> 
                <div v-if='inSquad == false'>
                  <select
                    v-model='rank[i]'
                    required
                  >
                    <option
                      value=''
                      disabled
                    >
                      Choose your rank
                    </option>
                    <option>
                      Biter
                    </option>
                    <option selected>
                      Runner
                    </option>
                    <option> Tank </option>
                  </select>
                  <button @click='joinSquad(squadItem.id, squadItem.isHuman,i)'>
                    Join Squad
                  </button>
                </div>
                <ul>
                  <li
                    v-for='memberItem in $store.getters.getAllSquadmembersInGame'
                    :key='memberItem'
                    class='squadmember'
                  >
                    <template v-if='memberItem.squadId === squadItem.id'>
                      <div class='members'>
                        <p>Rank: {{ memberItem.rank }}</p>
                        <p>Player ID: {{ memberItem.playerId }}</p>
                        <div>
                          <button @click='leaveSquad(squadItem.id,memberItem.id)'>
                            Leave Squad
                          </button>
                        </div>
                      </div>
                    </template>
                  </li>
                </ul>
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
.squadmember{
   border: none;
}
.members{
  border: 2px solid black;
  margin-bottom: 10px;
}
</style>
