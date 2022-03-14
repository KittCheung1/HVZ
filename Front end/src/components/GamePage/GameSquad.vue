<script setup>
import {useStore} from 'vuex'

const store = useStore()

</script>

<template>
    <div class="text-center">
        <h3>Squad Information</h3>
        <ul v-for="gameItem in Squads" :key="gameItem">
            <div>
                <h6>{{ gameItem.name }}</h6>
                <p>{{ gameItem.players }}</p>
                <p>Test Text</p>
            </div>
        </ul>
    </div>
</template>


<style>
</style>