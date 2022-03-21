<script setup>
import CreateKill from './CreateKill.vue'
import EditKill from './EditKill.vue'
import DeleteKill from './DeleteKill.vue'
import { ref } from 'vue'

const activeNavSelect = ref('1')
</script>

<template>
    <ul class="nav nav-pills mt-2 d-flex justify-content-center">
        <input
            type="radio"
            class="btn-check"
            name="killBtnradio"
            id="btnradioCreate"
            autocomplete="off"
            @click="activeNavSelect = '1'"
            checked
        />
        <label class="btn btn-outline-primary m-2" for="btnradioCreate">Create</label>
        <input
            type="radio"
            class="btn-check"
            name="killBtnradio"
            id="btnradioEdit"
            autocomplete="off"
            @click="activeNavSelect = '2'"
        />
        <label class="btn btn-outline-primary m-2" for="btnradioEdit">Edit</label>
        <input
            type="radio"
            class="btn-check"
            name="killBtnradio"
            id="btnradioDelete"
            autocomplete="off"
            @click="activeNavSelect = '3'"
        />
        <label class="btn btn-outline-primary m-2" for="btnradioDelete">Delete</label>
    </ul>
    <div class="m-3" aria-label = "AdminNavBar">
        <CreateKill v-if="activeNavSelect === '1'" />
        <EditKill v-if="activeNavSelect === '2'" />
        <DeleteKill v-if="activeNavSelect === '3'" />
    </div>
</template>

<style>
</style>