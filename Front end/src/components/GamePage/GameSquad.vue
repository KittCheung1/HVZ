<script setup>

let Squads =
    [
        {
            'id': 1,
            'name': 'Squid-Squad',
            'players': 1,
            'nw_lat': null,
            'nw_lng': null,
            'se_lat': null,
            'se_lng': null
        },
        {
            'id': 2,
            'name': 'Squash-Squad',
            'players': 2,
            'nw_lat': null,
            'nw_lng': null,
            'se_lat': null,
            'se_lng': null
        }
    ]

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