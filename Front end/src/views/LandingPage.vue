<script setup>
import Login from "../components/LandingPage/Login.vue";
import GameLobbies from "../components/LandingPage/GameLobbies.vue";

</script>

<template>
    <div class="row mt-5 d-flex justify-content-center">
        <div class="LobbyDiv col-md-6">
            <Login />
        </div>
        <div class="LoginDiv col-md-6">
            <GameLobbies />
        </div>
    </div>
</template>

<style>
</style>