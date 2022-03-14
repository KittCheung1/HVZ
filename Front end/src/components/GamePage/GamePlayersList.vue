<script setup>
import { onMounted } from 'vue';
import { useStore } from 'vuex'
const store = useStore()

let URL = 'http://apitest.northeurope.azurecontainer.io/'

function bite(bite) {
    alert(String(bite))
}
onMounted(() => {
    store.dispatch('getAllPlayers', {id:3})
})
</script>

<template>
    <div class="text-center">
        <h3>List of Players</h3>
        <div v-for="player in $store.getters.getAllPlayers" :key="player">
            <div>
                <p>{{ player.id }}</p>
            </div>
            <button @click="bite(player.bite_Code)">Bite</button>
        </div>
    </div>
</template>


<style>
</style>