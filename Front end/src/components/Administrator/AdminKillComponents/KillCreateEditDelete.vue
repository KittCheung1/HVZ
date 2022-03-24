<script setup>
import CreateKill from './CreateKill.vue'
import EditKill from './EditKill.vue'
import DeleteKill from './DeleteKill.vue'
import { ref } from 'vue'

const activeNavSelect = ref('1')
</script>

<template>
  <ul class='nav nav-pills mt-2 d-flex justify-content-center'>
    <input
      id='btnradioCreate'
      type='radio'
      class='btn-check'
      name='killBtnradio'
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
      name='killBtnradio'
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
      name='killBtnradio'
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
    <CreateKill v-if='activeNavSelect === &apos;1&apos;' />
    <EditKill v-if='activeNavSelect === &apos;2&apos;' />
    <DeleteKill v-if='activeNavSelect === &apos;3&apos;' />
  </div>
</template>

<style>
</style>