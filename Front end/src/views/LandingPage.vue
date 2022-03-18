<script setup>
import LoginForm from '../components/LoginForm.vue'
import GameLobbies from '../components/GameLobbies.vue'
import { GAME_ROUTE, ADMIN_ROUTE } from '../router'
</script>

<template>
  <div class='row mt-5 d-flex justify-content-center'>
    <div class='LobbyDiv col-md-6'>
      <LoginForm />
    </div>
    <div class='LoginDiv col-md-6'>
      <GameLobbies />
    </div>
    <div>
      <router-link
        class='nav-link'
        :to='{ name: GAME_ROUTE }'
      >
        Gamepage
      </router-link>
      <router-link
        class='nav-link'
        :to='{ name: ADMIN_ROUTE }'
      >
        Admin page
      </router-link>
    </div>
  </div>
</template>

<style>
.nav-link {
    text-decoration: none;
    color: inherit;
}
</style>
