<script setup>

import { onMounted } from 'vue'
import { useStore } from 'vuex'
const store = useStore()
onMounted(() => {
	store.dispatch('getAllGames').then(
	console.log(store.getters.getAllGames))
})

</script>

<template>
    <div class="border m-2">
        <h3 class="d-flex justify-content-center m-3">Delete Game</h3>
        <ul class="m-3 p-3" v-for="gameItem in $store.getters.getAllGames " :key="gameItem">
                <div class="list-group p-3 border">
                    <button
                        class="list-group-item list-group-item-action active"
                    >Game {{ gameItem.id }}</button>
                    <p>{{ gameItem.name }}</p>
                    <template v-if="gameItem.game_state === 1">Starting soon</template>

                    <template v-else-if="gameItem.game_state === 2">Ongoing</template>
                    <template v-else-if="gameItem.game_state === 3">Finish</template>
                    <p>Amount of Players : {{ gameItem.players }}</p>
                </div>
        </ul>
    </div>
</template>

<style>
</style>