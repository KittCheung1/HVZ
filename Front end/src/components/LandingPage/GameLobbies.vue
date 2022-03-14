<template>
  <ul>
    <li
      v-for='gameItem in $store.getters.getAllGames '
      :key='gameItem'
    >
      <div class='list-group w-75 p-3 border'>
        <!-- <button type="button" class="list-group-item list-group-item-action">Game Lobbies</button> -->
        <button class='list-group-item list-group-item-action active'>
          Game {{ gameItem.id }}
        </button>
        <p>{{ gameItem.name }}</p>
        <template v-if='gameItem.game_state === 1'>
          Starting soon
        </template>

        <template v-else-if='gameItem.game_state ===2'>
          Ongoing
        </template>
        <template v-else-if='gameItem.game_state ===3'>
          Finish
        </template>
        <p>Amount of Players : {{ gameItem.players }}</p>
        <!-- <button
          type="button"
          class="list-group-item list-group-item-action"
          data-toggle="collapse"
          data-target="#demo"
        ></button>-->
      </div>
    </li>
  </ul>
</template>

<script setup>
import { onMounted } from 'vue'
import { useStore } from 'vuex'
const store = useStore()
onMounted(() => {
	store.dispatch('getAllGames').then(
	console.log(store.getters.getAllGames))
})

let APIgameReq =
  [
  	{
  		'id': 1,
  		'name': 'Norrköpings zombie spel',
  		'game_state': 1,
  		'nw_lat': null,
  		'nw_lng': null,
  		'se_lat': null,
  		'se_lng': null
  	},
  	{
  		'id': 2,
  		'name': 'Norrköpings zombie spel 2',
  		'game_state': 2,
  		'nw_lat': null,
  		'nw_lng': null,
  		'se_lat': null,
  		'se_lng': null
  	},
  	{
  		'id': 3,
  		'name': 'Norrköpings zombie spel 3',
  		'game_state': 3,
  		'nw_lat': null,
  		'nw_lng': null,
  		'se_lat': null,
  		'se_lng': null
  	}
  ]

let PlayerCount =
  [
  	{
  		'id': 1,
  		'userId': 1,
  		'gameId': 1,
  		'is_Human': 1,
  		'is_Patient_Zero': 0,
  		'bite_Code': 'JagBetDig434'  },
  	{
  		'id': 2,
  		'userId': 2,
  		'gameId': 1,
  		'is_Human': 0,
  		'is_Patient_Zero': 1,
  		'bite_Code': 'JagBetDig123'  }
  ]

function addProp (){
  
	let count = PlayerCount.length

	APIgameReq[0]['players']=count
	return count
}
addProp()
</script>

<style>
</style>