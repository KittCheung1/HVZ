<script setup>
import GameSquad from "./GameSquad.vue";
import GameMission from "./GameMission.vue"
import GameBiteList from "./GameBiteList.vue";
import GameChat from "./GameChat.vue";
import {ref} from 'vue'

let visibleSquad = ref(false)
let visibleMission = ref(false)
</script>


<template>
    <div class="row mt-5 d-flex justify-content-left">
        <div class="col-md-3">
            <div class="border border-solid d-flex justify-content-center" >

                <div class="btn-group-vertical w-50 m-4 " role="group" data-toggle="buttons">
                    
                    <label class="btn btn-outline-primary" for="btnradio1">Map</label>
                    <input
                        type="radio"
                        class="btn-check"
                        name="btnradio"
                        id="btnradio1"
                        autocomplete="off"
                        checked
                    />
                        <input
                        type="radio"
                        class="btn-check"
                        name="btnradio"
                        id="btnradio2"
                        autocomplete="off"
                    />
                    <label class="btn btn-outline-primary" @click="visibleSquad = !visibleSquad" for="btnradio2">Squads</label>
                    <input
                        type="radio"
                        class="btn-check"
                        name="btnradio"
                        id="btnradio3"
                        autocomplete="off"
                    />
                    <label class="btn btn-outline-primary" @click="visibleMission = !visibleMission" for="btnradio3">Missions</label>
    
                    <input
                        type="radio"
                        class="btn-check"
                        name="btnradio"
                        id="btnradio2"
                        autocomplete="off"
                    />
                    <label class="btn btn-outline-primary" @click="visibleBiteList = !visibleBiteList" for="btnradio2">Bite List</label>
    
                    <input
                        type="radio"
                        class="btn-check"
                        name="btnradio"
                        id="btnradio2"
                        autocomplete="off"
                    />
                    <label class="btn btn-outline-primary" @click="visibleChat = !visibleChat" for="btnradio2">Chat</label>
                </div>
            </div>
        </div>
        <div class="col-md-9 border">
            <GameSquad v-if="visibleSquad"/>
            <GameMission v-if="visibleMission"/>
            <GameBiteList v-if="visibleBiteList"/>
            <GameChat v-if="visibleChat"/>
        </div>
    </div>
</template>




<style>

</style>

