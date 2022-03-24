<script setup>
import CreatePlayer from './CreatePlayer.vue'
import EditPlayer from './EditPlayer.vue'
import DeletePlayer from './DeletePlayer.vue'
import { ref } from 'vue'

const activeNavSelect = ref('1')
</script>

<template>
  <ul class='nav nav-pills mt-2 d-flex justify-content-center'>
    <input
      id='btnradioCreate'
      type='radio'
      class='btn-check'
      name='playerBtnradio'
      autocomplete='off'
      checked
      @click='activeNavSelect = &apos;1&apos;'
    >
    <label
      class='btn btn-outline-primary m-2'
      for='btnradioCreate'
    >Create</label>
    <input
      id='btnradioEdit'
      type='radio'
      class='btn-check'
      name='playerBtnradio'
      autocomplete='off'
      @click='activeNavSelect = &apos;2&apos;'
    >
    <label
      class='btn btn-outline-primary m-2'
      for='btnradioEdit'
    >Edit</label>
    <input
      id='btnradioDelete'
      type='radio'
      class='btn-check'
      name='playerBtnradio'
      autocomplete='off'
      @click='activeNavSelect = &apos;3&apos;'
    >
    <label
      class='btn btn-outline-primary m-2'
      for='btnradioDelete'
    >Delete</label>
  </ul>
  <div
    class='m-3'
    aria-label='AdminNavBar'
  >
    <CreatePlayer v-if='activeNavSelect === &apos;1&apos;' />
    <EditPlayer v-if='activeNavSelect === &apos;2&apos;' />
    <DeletePlayer v-if='activeNavSelect === &apos;3&apos;' />
  </div>
</template>

<style>
</style>