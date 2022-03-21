<script setup>
import CreatePlayer from './CreatePlayer.vue'
import EditPlayer from './EditPlayer.vue'
import DeletePlayer from './DeletePlayer.vue'
import { ref } from 'vue'

const activeNavSelect = ref('1')
</script>

<template>
    <ul class="nav nav-pills mt-2 d-flex justify-content-center">
        <input
            type="radio"
            class="btn-check"
            name="playerBtnradio"
            id="btnradioCreate"
            autocomplete="off"
            @click="activeNavSelect = '1'"
            checked
        />
        <label class="btn btn-outline-primary m-2" for="btnradioCreate">Create</label>
        <input
            type="radio"
            class="btn-check"
            name="playerBtnradio"
            id="btnradioEdit"
            autocomplete="off"
            @click="activeNavSelect = '2'"
        />
        <label class="btn btn-outline-primary m-2" for="btnradioEdit">Edit</label>
        <input
            type="radio"
            class="btn-check"
            name="playerBtnradio"
            id="btnradioDelete"
            autocomplete="off"
            @click="activeNavSelect = '3'"
        />
        <label class="btn btn-outline-primary m-2" for="btnradioDelete">Delete</label>
    </ul>
    <div class="m-3" aria-label = "AdminNavBar">
        <CreatePlayer v-if="activeNavSelect === '1'" />
        <EditPlayer v-if="activeNavSelect === '2'" />
        <DeletePlayer v-if="activeNavSelect === '3'" />
    </div>
</template>

<style>
</style>