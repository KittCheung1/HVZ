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
})


function joinGame (gameid){
	store.dispatch('getGame',{gameId:gameid})

	//LOGIK FÖR ATT KOLLA IFALL EN PLAYER REDAN FINNS I GAMET ELLER EJ HÄR. NEDANSTÅENDE POST ÄR EJ KLAR
	//store.dispatch('postPlayer') 
	route.push('/game')
}


function createPlayer(game){

	let player = {
		gameid: game,
		userid: store.getters.getCurrentUserId,
	 	is_human:1,
	 	is_patient_zero:0,
	 	bite_code:'1223sasa'
	}

	
}



</script>

<style scoped>

ul{
    list-style-type: none;
}
</style>