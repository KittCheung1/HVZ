<script setup>
import { ref } from 'vue'
import GameCreateEditDelete from './AdminGameComponents/GameCreateEditDelete.vue'
import MissionCreateEditDelete from './AdminMissionComponent/MissionCreateEditDelete.vue';

const activeComponent = ref('1')

</script>

<template>
    <div class="row mt-5 ">
        <div class="col-md-3">
            <div class="border border-solid d-flex justify-content-center">
                <div
                    class="btn-group btn-group-vertical btn-group-toggle w-75 m-4"
                    aria-label="GameDashboard"
                    role="group"
                    data-toggle="buttons"
                >

                        <input
                            type="radio"
                            class="btn-check"
                            name="btnradio"
                            id="btnradio1"
                            autocomplete="off"
                            @click="activeComponent = '1'"
                            checked
                        />
                        <label class="btn btn-outline-primary" for="btnradio1">Game</label>

                        <input
                            type="radio"
                            class="btn-check"
                            name="btnradio"
                            id="btnradio2"
                            autocomplete="off"
                             @click="activeComponent = '2'"
                        />
                        <label class="btn btn-outline-primary" for="btnradio2">Mission</label>

                        <input
                            type="radio"
                            class="btn-check"
                            name="btnradio"
                            id="btnradio3"
                            autocomplete="off"
                            @click="activeComponent = '3'"
                        />
                        <label class="btn btn-outline-primary" for="btnradio3">Squad</label>
                        <input
                            type="radio"
                            class="btn-check"
                            name="btnradio"
                            id="btnradio4"
                            autocomplete="off"
                            @click="activeComponent = '4'"
                        />
                        <label class="btn btn-outline-primary" for="btnradio4">Bite List</label>

                        <input
                            type="radio"
                            class="btn-check"
                            name="btnradio"
                            id="btnradio5"
                            autocomplete="off"
                             @click="activeComponent = '5'"
                        />
                        <label class="btn btn-outline-primary" for="btnradio5">Player</label>

                        <input
                            type="radio"
                            class="btn-check"
                            name="btnradio"
                            id="btnradio6"
                            autocomplete="off"
                            @click="activeComponent = '6'"
                        />
                        <label class="btn btn-outline-primary" for="btnradio6">Chat</label>
                </div>
            </div>
        </div>
        <div class="col-md-9 border">
            <GameCreateEditDelete v-if="activeComponent === '1'" />
            <MissionCreateEditDelete v-if="activeComponent === '2'" />
            <GameMission v-if="activeComponent === '3'" />
            <GameBiteList v-if="activeComponent === '4'" />
            <GamePlayersList v-if="activeComponent === '5'" />
            <GameChat v-if="activeComponent === '6'" />
        </div>
    </div>
</template>

<style>
</style>