<script setup>
import CreateGame from './CreateGame.vue'
import EditGame from './EditGame.vue'
import DeleteGame from './DeleteGame.vue'
import { ref } from 'vue'

const activeNavSelect = ref('1')
</script>

<template>
  <ul class='nav nav-pills mt-2 d-flex justify-content-center'>
    <input
      id='btnRadioCreate'
      type='radio'
      class='btn-check'
      name='gameBtnRadio'
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
      name='gameBtnRadio'
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
      name='gameBtnRadio'
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
    <CreateGame v-if='activeNavSelect === &apos;1&apos;' />
    <EditGame v-if='activeNavSelect === &apos;2&apos;' />
    <DeleteGame v-if='activeNavSelect === &apos;3&apos;' />
  </div>
</template>

<style>
</style>