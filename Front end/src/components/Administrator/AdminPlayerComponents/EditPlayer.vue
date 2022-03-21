<script setup>


import { onMounted } from 'vue'
import { useStore } from 'vuex'
const store = useStore()
onMounted(() => {
    store.dispatch('getAllPlayers')
    store.dispatch('getAllGames').then(
        console.log(store.getters.getAllGames))
})
</script>

<template>
     <div class="border m-2">
        <h3 class="d-flex justify-content-center m-3">Create a Player</h3>
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
                    <label for="userId" class="block p-3">User Id:</label>
                    <input
                        id="userId"
                        v-model="userId"
                        type="text"
                        placeholder="User id"
                        class="border border-slate-800 input"
                    />
                </div>
                <div class="m-2">
                    <label for="is_human" class="block p-3">Type:</label>
                    <select v-model="is_human">
                        <option disabled value>Please select one</option>
                        <option :value="true">Human</option>
                        <option :value="false">Zombie</option>
                    </select>
                </div>

                <div class="m-2">
                    <label for="biteCode" class="block p-3">Bite Code:</label>
                    <input
                        id="biteCode"
                        v-model="biteCode"
                        type="text"
                        placeholder="Bite Code"
                        class="border border-slate-800 input"
                    />
                </div>
            </fieldset>
        </form>
        <button class="m-3">Save Changes</button>
    </div>
</template>

<style scoped>
.input{
    width: 80px;
}
</style>