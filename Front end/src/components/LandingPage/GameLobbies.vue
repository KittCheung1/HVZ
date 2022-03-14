<template>
  <ul >
    <li v-for="gameItem in APIgameReq" :key="gameItem">
      <div class="list-group w-75 p-3 border">
        <!-- <button type="button" class="list-group-item list-group-item-action">Game Lobbies</button> -->
        <button class="list-group-item list-group-item-action active">Game {{ gameItem.id }}</button>
        <p>{{ gameItem.name }}</p>
        <template v-if="gameItem.game_state === 1">Starting soon</template>

        <template v-else-if="gameItem.game_state ===2">Ongoing</template>
        <template v-else="gameItem.game_state ===3">Finish</template>
        <p>Route:{{this.$route.params.game}}</p>
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

import { useRouter } from "vue-router";
const router = useRouter()

let APIgameReq =
  [
    {
      "id": 1,
      "name": "Norrköpings zombie spel",
      "game_state": 1,
      "nw_lat": null,
      "nw_lng": null,
      "se_lat": null,
      "se_lng": null
    },
    {
      "id": 2,
      "name": "Norrköpings zombie spel 2",
      "game_state": 2,
      "nw_lat": null,
      "nw_lng": null,
      "se_lat": null,
      "se_lng": null
    },
    {
      "id": 3,
      "name": "Norrköpings zombie spel 3",
      "game_state": 3,
      "nw_lat": null,
      "nw_lng": null,
      "se_lat": null,
      "se_lng": null
    }
  ]
// function onClick(){
// router.push()
// }

</script>

<style>
</style>