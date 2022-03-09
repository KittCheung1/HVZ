<script setup>
import Lobby from "../components/LandingPage/Lobby.vue";
import Login from "../components/LandingPage/Login.vue";

</script>

<template>
    <div class="row mt-5 d-flex justify-content-center">
        <div class="LobbyDiv col-md-6">
            <Login />
        </div>
        <div class="LoginDiv col-md-6">
            <Lobby />
        </div>
    </div>
</template>

<style>
</style>