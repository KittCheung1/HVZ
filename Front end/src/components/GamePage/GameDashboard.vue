<script setup>
import GameSquad from './GameSquad.vue'
import GameMission from './GameMission.vue'
import GameBiteList from './GameBiteList.vue'
import GameChat from './GameChat.vue'
import GamePlayersList from './GamePlayersList.vue'
import GameMap from './GameMap.vue'
import { ref } from 'vue'
import GameShowBiteCode from './GameShowBiteCode.vue'
import GameLanding from './GameLanding.vue'

const activeComponent = ref('1')
</script>


<template>
  <div class='row mt-5 d-flex justify-content-left'>
    <div class='col-md-3'>
      <div class='border border-solid d-flex justify-content-center'>
        <div
          class='btn-group btn-group-vertical btn-group-toggle w-75 m-4'
          aria-label='GameDashboard'
          role='group'
          data-toggle='buttons'
        >
          <input
            id='btnradio1'
            type='radio'
            class='btn-check'
            name='btnradio'
            autocomplete='off'
            checked
            @click='activeComponent = &apos;1&apos;'
          >
          <label
            class='btn btn-outline-primary'
            for='btnradio1'
          >Rules</label>

          <input
            id='btnradio2'
            type='radio'
            class='btn-check'
            name='btnradio'
            autocomplete='off'
            @click='activeComponent = &apos;2&apos;'
          >
          <label
            class='btn btn-outline-primary'
            for='btnradio2'
          >Map</label>

          <input
            id='btnradio3'
            type='radio'
            class='btn-check'
            name='btnradio'
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
            name='btnradio'
            autocomplete='off'
            @click='activeComponent = &apos;4&apos;'
          >
          <label
            class='btn btn-outline-primary'
            for='btnradio4'
          >Mission</label>
          <input
            id='btnradio5'
            type='radio'
            class='btn-check'
            name='btnradio'
            autocomplete='off'
            @click='activeComponent = &apos;5&apos;'
          >
          <label
            class='btn btn-outline-primary'
            for='btnradio5'
          >Bite List</label>

          <input
            id='btnradio6'
            type='radio'
            class='btn-check'
            name='btnradio'
            autocomplete='off'
            @click='activeComponent = &apos;6&apos;'
          >
          <label
            class='btn btn-outline-primary'
            for='btnradio6'
          >Player List</label>

          <input
            id='btnradio7'
            type='radio'
            class='btn-check'
            name='btnradio'
            autocomplete='off'
            @click='activeComponent = &apos;7&apos;'
          >
          <label
            class='btn btn-outline-primary'
            for='btnradio7'
          >Chat</label>

        </div>
      </div>
    </div>
    <div class='col-md-9 border'>
      <GameLanding v-if='activeComponent === &apos;1&apos;' />
      <GameMap v-if='activeComponent === &apos;2&apos;' />
      <GameSquad v-if='activeComponent === &apos;3&apos;' />
      <GameMission v-if='activeComponent === &apos;4&apos;' />
      <GameBiteList v-if='activeComponent === &apos;5&apos;' />
      <GamePlayersList v-if='activeComponent === &apos;6&apos;' />
      <GameChat v-if='activeComponent === &apos;7&apos;' />
    </div>
  </div>
</template>




<style>
.active {
}
</style>

