<script setup>
import LoginPage from '../components/LandingPage/LoginPage.vue'
import GameLobbies from '../components/LandingPage/GameLobbies.vue'
</script>

<template>
  <div class='row mt-5 d-flex justify-content-center'>
    <div class='LobbyDiv col-md-6'>
      <LoginPage />
    </div>
    <div class='LoginDiv col-md-6'>
      <GameLobbies />
    </div>
    <div>
      <router-link
        class='nav-link'
        to='/game'
      >
        Game page
      </router-link>
      <router-link
        class='nav-link'
        to='/admin'
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
