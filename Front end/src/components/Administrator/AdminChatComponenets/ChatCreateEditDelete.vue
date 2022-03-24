<script setup>
import CreateChat from './CreateChat.vue'
import EditChat from './EditChat.vue'
import DeleteChat from './DeleteChat.vue'
import { ref } from 'vue'

const activeNavSelect = ref('1')
</script>

<template>
  <ul class='nav nav-pills mt-2 d-flex justify-content-center'>
    <input
      id='btnRadioCreate'
      type='radio'
      class='btn-check'
      name='chatBtnRadio'
      autocomplete='off'
      checked
      @click='activeNavSelect = &apos;1&apos;'
    >
    <label
      class='btn btn-outline-primary m-2'
      for='btnRadioCreate'
    >Create</label>
    <input
      id='btnRadioEdit'
      type='radio'
      class='btn-check'
      name='chatBtnRadio'
      autocomplete='off'
      @click='activeNavSelect = &apos;2&apos;'
    >
    <label
      class='btn btn-outline-primary m-2'
      for='btnRadioEdit'
    >Edit</label>
    <input
      id='btnRadioDelete'
      type='radio'
      class='btn-check'
      name='chatBtnRadio'
      autocomplete='off'
      @click='activeNavSelect = &apos;3&apos;'
    >
    <label
      class='btn btn-outline-primary m-2'
      for='btnRadioDelete'
    >Delete</label>
  </ul>
  <div
    class='m-3'
    aria-label='AdminNavBar'
  >
    <CreateChat v-if='activeNavSelect === &apos;1&apos;' />
    <EditChat v-if='activeNavSelect === &apos;2&apos;' />
    <DeleteChat v-if='activeNavSelect === &apos;3&apos;' />
  </div>
</template>

<style>
</style>