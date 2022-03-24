<script setup>
import { ref } from 'vue'
import GameCreateEditDelete from './AdminGameComponents/GameCreateEditDelete.vue'
import MissionCreateEditDelete from './AdminMissionComponent/MissionCreateEditDelete.vue'
import SquadCreateEditDelete from './AdminSquadComponents/SquadCreateEditDelete.vue'
import KillCreateEditDelete from './AdminKillComponents/KillCreateEditDelete.vue'
import PlayerCreateEditDelete from './AdminPlayerComponents/PlayerCreateEditDelete.vue'
import ChatCreateEditDelete from './AdminChatComponenets/ChatCreateEditDelete.vue'

const activeComponent = ref('1')

</script>

<template>
  <div class='row mt-5 '>
    <div class='col-md-3'>
      <div class='border border-solid d-flex justify-content-center'>
        <div
          class='btn-group btn-group-vertical btn-group-toggle w-75 m-4'
          aria-label='AdminDashboard'
          role='group'
          data-toggle='buttons'
        >
          <input
            id='btnradio1'
            type='radio'
            class='btn-check'
            name='adminBtnRadio'
            autocomplete='off'
            checked
            @click='activeComponent = &apos;1&apos;'
          >
          <label
            class='btn btn-outline-primary'
            for='btnradio1'
          >Game</label>

          <input
            id='btnradio2'
            type='radio'
            class='btn-check'
            name='adminBtnRadio'
            autocomplete='off'
            @click='activeComponent = &apos;2&apos;'
          >
          <label
            class='btn btn-outline-primary'
            for='btnradio2'
          >Mission</label>

          <input
            id='btnradio3'
            type='radio'
            class='btn-check'
            name='adminBtnRadio'
            autocomplete='off'
            @click='activeComponent = &apos;3&apos;'
          >
          <label
            class='btn btn-outline-primary'
            for='btnradio3'
          >Squad</label>
          <input
            id='btnradio4'
            type='radio'
            class='btn-check'
            name='adminBtnRadio'
            autocomplete='off'
            @click='activeComponent = &apos;4&apos;'
          >
          <label
            class='btn btn-outline-primary'
            for='btnradio4'
          >Kill List</label>

          <input
            id='btnradio5'
            type='radio'
            class='btn-check'
            name='adminBtnRadio'
            autocomplete='off'
            @click='activeComponent = &apos;5&apos;'
          >
          <label
            class='btn btn-outline-primary'
            for='btnradio5'
          >Player</label>

          <input
            id='btnradio6'
            type='radio'
            class='btn-check'
            name='adminBtnRadio'
            autocomplete='off'
            @click='activeComponent = &apos;6&apos;'
          >
          <label
            class='btn btn-outline-primary'
            for='btnradio6'
          >Chat</label>
        </div>
      </div>
    </div>
    <div class='col-md-9 border'>
      <GameCreateEditDelete v-if='activeComponent === &apos;1&apos;' />
      <MissionCreateEditDelete v-if='activeComponent === &apos;2&apos;' />
      <SquadCreateEditDelete v-if='activeComponent === &apos;3&apos;' />
      <KillCreateEditDelete v-if='activeComponent === &apos;4&apos;' />
      <PlayerCreateEditDelete v-if='activeComponent === &apos;5&apos;' />
      <ChatCreateEditDelete v-if='activeComponent === &apos;6&apos;' />
    </div>
  </div>
</template>

<style>
</style>