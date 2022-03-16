<script setup>
import GameSquad from './GameSquad.vue'
import GameMission from './GameMission.vue'
import GameBiteList from './GameBiteList.vue'
import GameChat from './GameChat.vue'
import GamePlayersList from './GamePlayersList.vue'
import GameMap from './GameMap.vue'
import { ref } from 'vue'

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
          >Map</label>

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
          >Squad</label>

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
          >Mission</label>
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
          >Bite List</label>

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
          >Player List</label>

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
          >Chat</label>

          <!-- <button
                        @click="activeComponent = '1'"
                        type="radio"
                        class="btn btn-outline-primary active"
                        aria-pressed="true"
                    >Map</button>
                    <button
                        @click="activeComponent = '2'"
                        type="radio"
                        class="btn btn-outline-primary"
                    >Squad</button>
                    <button
                        @click="activeComponent = '3'"
                        type="radio"
                        class="btn btn-outline-primary"
                    >Mission</button>
                    <button
                        @click="activeComponent = '4'"
                        type="button"
                        class="btn btn-outline-primary"
                    >Bite List</button>
                    <button
                        @click="activeComponent = '5'"
                        type="button"
                        class="btn btn-outline-primary"
                    >Players List</button>
                    <button
                        @click="activeComponent = '6'"
                        type="button"
                        class="btn btn-outline-primary"
                    >Chat</button> -->
        </div>
      </div>
    </div>
    <div class='col-md-9 border'>
      <GameMap v-if='activeComponent === &apos;1&apos;' />
      <GameSquad v-if='activeComponent === &apos;2&apos;' />
      <GameMission v-if='activeComponent === &apos;3&apos;' />
      <GameBiteList v-if='activeComponent === &apos;4&apos;' />
      <GamePlayersList v-if='activeComponent === &apos;5&apos;' />
      <GameChat v-if='activeComponent === &apos;6&apos;' />
    </div>
  </div>
</template>




<style>
.active {
}
</style>

