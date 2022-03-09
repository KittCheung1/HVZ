<script setup>
</script>

<template>
    <div class="Title Lobby">
        <h1>Game Lobby</h1>
    </div>
    <div class>
        <div class="m-5">
            <ul class="list-unstyled m-5 ">
                <li v-for="gameItem in APIgameReq" :key="gameItem">
                    <div class="list-group">
                        <a
                            href="#"
                            class="list-group-item list-group-item-action align-items-start active"
                        >
                            <div class="d-flex justify-content-between">
                                <h5 class="mb-1">{{APIgameReq.name}}</h5>
                                <small>{{}}</small>
                            </div>
                            <p class="mb-1">Players 1/10</p>
                            <small>{{APIgameReq.game_state}}</small>
                        </a>
                        
                    </div>
                </li>
            </ul>
        </div>
    </div>
</template>

<style>
.Title {
    text-align: center;
}
.alert {
    padding: 0;
}
</style>