<script setup>

import { onMounted } from 'vue'
import { useStore } from 'vuex'
const store = useStore()
onMounted(() => {
	store.dispatch('getAllGames').then(
	console.log(store.getters.getAllGames))
})

function deleteMission(){
alert("Deleted mission")
}

</script>

<template>
    <div class="border m-2">
        <h3 class="d-flex justify-content-center m-3">Delete Mission</h3>
        <ul class="m-3 p-3" v-for="missionItem in $store.getters.getAllMissions " :key="missionItem">
                <div class="list-group p-3 border">
                    <button
                        class="list-group-item list-group-item-action active"
                        @click="deleteMission()"
                    >Delete Mission {{ missionItem.id }}</button>
                    <p>{{ missionItem.name }}</p>
                </div>
        </ul>
    </div>
</template>

<style>
</style>