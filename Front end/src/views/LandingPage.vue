<script setup>
import Login from '../components/LandingPage/Login.vue';
import GameLobbies from '../components/LandingPage/GameLobbies.vue';

</script>

<template>
    <div class='row mt-5 d-flex justify-content-center'>
        <div class='LobbyDiv col-md-6'>
            <Login />
        </div>
        <div class='LoginDiv col-md-6'>
            <GameLobbies />
        </div>
    </div>
    <div>
        <router-link class='nav-link' to='/game'>Game page</router-link>
        <router-link class='nav-link' to='/admin'>Admin page</router-link>
    </div>
</template>

<style> 
.nav-link{
    text-decoration: none;
    color: inherit;
}
</style>