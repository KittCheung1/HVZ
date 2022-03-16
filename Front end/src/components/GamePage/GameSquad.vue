<script setup>
import { onMounted, ref } from 'vue'
import { useRouter } from 'vue-router'
import store from '../../store'
import GameSquadCreation from './GameSquadCreation.vue'


onMounted(()=>{
	store.dispatch('getAllSquads',{gameId:store.getters.getCurrentGameId})
})


function joinSquad(squadid, IsHuman){
	if(IsHuman){
		console.log('You have joined a human squad wtih id :'+squadid+', Welcome!')
	} else {
		console.log('You have joined a zombie squad with id:'+squadid+', Time to hunt!')
	}
}

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
              <button @click='joinSquad(squadItem.id, squadItem.isHuman)'>
                Join Squad
              </button>
            </div>
          </template>
          <template v-else>
            <div class='Zombie'>
              <h5>{{ squadItem.name }}</h5>
              <p> Squad Id: {{ squadItem.id }}</p>
              <button @click='joinSquad(squadItem.id)'>
                Join Squad
              </button>
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