<script setup>
import CreateGame from './CreateGame.vue'
import EditGame from './EditGame.vue'
import DeleteGame from './DeleteGame.vue'
import { ref } from 'vue'

const activeNavSelect = ref('1')
</script>

<template>
    <ul class="nav nav-pills mt-2 d-flex justify-content-center">
        <input
            type="radio"
            class="btn-check"
            name="btnRadio"
            id="btnRadioCreate"
            autocomplete="off"
            @click="activeNavSelect = '1'"
            checked
        />
        <label class="btn btn-outline-primary m-2" for="btnRadioCreate">Create</label>
        <input
            type="radio"
            class="btn-check"
            name="btnRadio"
            id="btnRadioEdit"
            autocomplete="off"
            @click="activeNavSelect = '2'"
        />
        <label class="btn btn-outline-primary m-2" for="btnRadioEdit">Edit</label>
        <input
            type="radio"
            class="btn-check"
            name="btnRadio"
            id="btnRadioDelete"
            autocomplete="off"
            @click="activeNavSelect = '3'"
        />
        <label class="btn btn-outline-primary m-2" for="btnRadioDelete">Delete</label>
    </ul>
    <div class="m-3" aria-label = "AdminNavBar">
        <CreateGame v-if="activeNavSelect === '1'" />
        <EditGame v-if="activeNavSelect === '2'" />
        <DeleteGame v-if="activeNavSelect === '3'" />
    </div>
</template>

<style>
</style>