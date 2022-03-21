<script setup>

import { onMounted } from 'vue'
import { useStore } from 'vuex'
const store = useStore()
onMounted(() => {
	store.dispatch('getAllMissions')
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
        <form class>
            <fieldset class="border-2 border-solid border-slate-500">
                <div class="m-2">
                    <label for="missionName" class="block p-3">Mission List:</label>
                    <select v-model="selectedMission" id="selectMission">
                        <option
                            v-for="mission in $store.getters.getAllMissions"
                            :key="mission"
                        >{{ mission.name }}</option>
                    </select>
                </div>
                <button class="m-3" @click="deleteMission()">Delete Mission</button>
            </fieldset>
        </form>
    </div>
</template>

<style>
</style>