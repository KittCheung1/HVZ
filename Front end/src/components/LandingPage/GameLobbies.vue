<template>
  <ul >
    <li
      v-for='gameItem in $store.getters.getAllGames '
      :key='gameItem'
    >
      <div class='list-group w-75 p-3 border'>
        <button class='list-group-item list-group-item-action active'>
          Game {{ gameItem.id }}
        </button>
        <p>{{ gameItem.name }}</p>
        <template v-if='gameItem.game_state === 1'>
          Waiting for more players
          <button @click='joinGame(gameItem.id)'>
            Join Game
          </button>
        </template>

        <template v-else-if='gameItem.game_state ===2'>
          Ongoing
          <!-- Denna knapp skall bort sen -->
          <button @click='joinGame(gameItem.id)'>
            Join Game
          </button>
          <!--  -->
        </template>
        <template v-else-if='gameItem.game_state ===3'>
          <!-- Denna knapp skall bort sen -->
          <button @click='joinGame(gameItem.id)'>
            Join Game
          </button>
          <!--  -->
          Finished
        </template>
       

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
import { useRouter } from 'vue-router'
import { useStore } from 'vuex'
const store = useStore()
const route = useRouter()
onMounted(() => {
	store.dispatch('getAllGames').then(
		console.log(store.getters.getAllGames))
	  store.dispatch('makeid', {length: 10})
})

let player = {
	userId: store.getters.getCurrentUserId,
	 	is_Human: true,
	 	is_Patient_Zero: false ,
	 	bite_Code: makeid(10)
}


function joinGame (gameid){
	store.dispatch('getGame',{gameId:gameid})
		.then(store.dispatch('getAllPlayersAndCheck', {gameId:gameid}))



	//LOGIK FÖR ATT KOLLA IFALL EN PLAYER REDAN FINNS I GAMET ELLER EJ HÄR. NEDANSTÅENDE POST ÄR EJ KLAR
	//store.dispatch('postPlayer') 
	route.push('/game')
}


function makeid(length) {
	var result           = ''
	var characters       = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789'
	var charactersLength = characters.length
	for ( var i = 0; i < length; i++ ) {
		result += characters.charAt(Math.floor(Math.random() * 
 charactersLength))
	}
	return result
}





function createPlayer(game){


	store.dispatch('postPlayer',player)
	
}



</script>

<style scoped>

ul{
    list-style-type: none;
}
</style>