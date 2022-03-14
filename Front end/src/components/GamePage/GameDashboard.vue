<script setup>
import GameSquad from "./GameSquad.vue";
import GameMission from "./GameMission.vue"
import GameBiteList from "./GameBiteList.vue";
import GameChat from "./GameChat.vue";
import GamePlayersList from "./GamePlayersList.vue"
import GameMap from "./GameMap.vue"
import { ref } from 'vue'

const activeComponent = ref('1')
</script>


<template>
    <div class="row mt-5 d-flex justify-content-left">
        <div class="col-md-3">
            <div class="border border-solid d-flex justify-content-center">
                <div class="btn-group btn-group-vertical btn-group-toggle w-75 m-4" aria-label="GameDashboard" role="group" data-toggle="buttons">
                    <button
                        @click="activeComponent = '1'"
                        type="radio"
                        class="btn btn-outline-primary active"
                        aria-pressed="true"
                    >Map</button>
                    <button
                        @click="activeComponent = '2'"
                        type="radio"
                        class="btn btn-outline-primary"
                    >Squad</button>
                    <button
                        @click="activeComponent = '3'"
                        type="radio"
                        class="btn btn-outline-primary"
                    >Mission</button>
                    <button
                        @click="activeComponent = '4'"
                        type="button"
                        class="btn btn-outline-primary"
                    >Bite List</button>
                    <button
                        @click="activeComponent = '5'"
                        type="button"
                        class="btn btn-outline-primary"
                    >Players List</button>
                    <button
                        @click="activeComponent = '6'"
                        type="button"
                        class="btn btn-outline-primary"
                    >Chat</button>
                </div>
            </div>
        </div>
        <div class="col-md-9 border">
            <GameMap v-if="activeComponent === '1'" />
            <GameSquad v-if="activeComponent === '2'" />
            <GameMission v-if="activeComponent === '3'" />
            <GameBiteList v-if="activeComponent === '4'" />
            <GamePlayersList v-if="activeComponent === '5'" />
            <GameChat v-if="activeComponent === '6'" />
        </div>
    </div>
</template>




<style>
.active {
}
</style>

