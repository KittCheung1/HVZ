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
        <h3 class="d-flex justify-content-center m-3">Edit Game</h3>
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
                    <label for="gameState" class="block p-3">Game State:</label>
                    <input
                        id="gameState"
                        v-model="gameState"
                        type="text"
                        placeholder="Game State"
                        class="border border-slate-800"
                    />
                </div>
                <div class="m-2 coordinates">
                    <label for="Nw_Lat" class="block p-3">Coordinates:</label>
                    <input
                        id="Nw_Lat"
                        v-model="Nw_Lat"
                        type="text"
                        placeholder="Nw_Lat"
                        class="border border-slate-800 m-2 input "
                    />
                    <input
                        id="Nw_Lng"
                        v-model="Nw_Lng"
                        type="text"
                        placeholder="Nw_Lng"
                        class="border border-slate-800 m-2 input"
                    />
                    <input
                        id="Sw_Lat"
                        v-model="Sw_Lat"
                        type="text"
                        placeholder="Sw_Lat"
                        class="border border-slate-800 m-2 input"
                    />
                    <input
                        id="Sw_Lng"
                        v-model="Sw_Lng"
                        type="text"
                        placeholder="Sw_Lng"
                        class="border border-slate-800 m-2 input"
                    />
                </div>
            </fieldset>
        </form>
        <button class="m-3 ">Save Changes</button>
    </div>
</template>

<style scoped>
.input{
    width: 70px;
}
</style>