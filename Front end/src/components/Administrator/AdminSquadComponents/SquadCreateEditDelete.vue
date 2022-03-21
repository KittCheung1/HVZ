<script setup>
import CreateSquad from './CreateSquad.vue'
import EditSquad from './EditSquad.vue'
import DeleteSquad from './DeleteSquad.vue'
import { ref } from 'vue'

const activeNavSelect = ref('1')
</script>

<template>
    <ul class="nav nav-pills mt-2 d-flex justify-content-center">
        <input
            type="radio"
            class="btn-check"
            name="squadBtnRadio"
            id="btnRadioCreate"
            autocomplete="off"
            @click="activeNavSelect = '1'"
            checked
        />
        <label class="btn btn-outline-primary m-2" for="btnRadioCreate">Create</label>
        <input
            type="radio"
            class="btn-check"
            name="squadBtnRadio"
            id="btnRadioEdit"
            autocomplete="off"
            @click="activeNavSelect = '2'"
        />
        <label class="btn btn-outline-primary m-2" for="btnRadioEdit">Edit</label>
        <input
            type="radio"
            class="btn-check"
            name="squadBtnRadio"
            id="btnRadioDelete"
            autocomplete="off"
            @click="activeNavSelect = '3'"
        />
        <label class="btn btn-outline-primary m-2" for="btnRadioDelete">Delete</label>
    </ul>
    <div class="m-3" aria-label = "AdminNavBar">
        <CreateSquad v-if="activeNavSelect === '1'" />
        <EditSquad v-if="activeNavSelect === '2'" />
        <DeleteSquad v-if="activeNavSelect === '3'" />
    </div>
</template>

<style>
</style>