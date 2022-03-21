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
        <h3 class="d-flex justify-content-center m-3">Create Mission</h3>
        <form class>
            <fieldset class="border-2 border-solid border-slate-500">
                <div class="m-2">
                    <label for="gameName" class="block p-3">Game List:</label>
                    <select v-model="selectedGame" id="selectGame">
                        <option
                            v-for="game in $store.getters.getAllGames"
                            :key="game"
                        >{{ game.name }}</option>
                    </select>
                </div>
                <div class="m-2">
                    <label for="missionName" class="block p-3">Mission name:</label>
                    <input
                        id="missionName"
                        v-model="missionName"
                        type="text"
                        placeholder="Mission name"
                        class="border border-slate-800"
                    />
                </div>

                <div class="m-4">
                    <textarea
                        id="m_description"
                        v-model="m_description"
                        type="textarea"
                        placeholder="Mission Description"
                        class="border border-slate-800"
                        rows="4"
                        cols="33"
                    ></textarea>
                </div>
                <div class="m-2">
                    <label for="Nw_Lat" class="block p-3">Type:</label>
                    <select v-model="is_human">
                        <option disabled value>Please select one</option>
                        <option :value="true">Human</option>
                        <option :value="false">Zombie</option>
                    </select>
                </div>
                <div class="m-2">
                    <label for="startTime" class="block p-3">Start Time:</label>
                    <input
                        id="startTime"
                        v-model="startTime"
                        type="time"
                        class="border border-slate-800 m-2 input"
                    />
                    <label for="endTime" class="block p-3">End Time:</label>
                    <input
                        id="endTime"
                        v-model="endTime"
                        type="time"
                        class="border border-slate-800 m-2 input"
                    />
                </div>
            </fieldset>
        </form>
        <button class="m-3">Create</button>
    </div>
</template>

<style scoped>
.input {
    width: 70px;
}
</style>