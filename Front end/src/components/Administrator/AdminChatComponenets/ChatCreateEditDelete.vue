<script setup>
import CreateChat from './CreateChat.vue'
import EditChat from './EditChat.vue'
import DeleteChat from './DeleteChat.vue'
import { ref } from 'vue'

const activeNavSelect = ref('1')
</script>

<template>
    <ul class="nav nav-pills mt-2 d-flex justify-content-center">
        <input
            type="radio"
            class="btn-check"
            name="chatBtnRadio"
            id="btnRadioCreate"
            autocomplete="off"
            @click="activeNavSelect = '1'"
            checked
        />
        <label class="btn btn-outline-primary m-2" for="btnRadioCreate">Create</label>
        <input
            type="radio"
            class="btn-check"
            name="chatBtnRadio"
            id="btnRadioEdit"
            autocomplete="off"
            @click="activeNavSelect = '2'"
        />
        <label class="btn btn-outline-primary m-2" for="btnRadioEdit">Edit</label>
        <input
            type="radio"
            class="btn-check"
            name="chatBtnRadio"
            id="btnRadioDelete"
            autocomplete="off"
            @click="activeNavSelect = '3'"
        />
        <label class="btn btn-outline-primary m-2" for="btnRadioDelete">Delete</label>
    </ul>
    <div class="m-3" aria-label = "AdminNavBar">
        <CreateChat v-if="activeNavSelect === '1'" />
        <EditChat v-if="activeNavSelect === '2'" />
        <DeleteChat v-if="activeNavSelect === '3'" />
    </div>
</template>

<style>
</style>