<script setup>
import GameSquad from "./GameSquad.vue";
</script>


<template>
    <div class="row mt-5 d-flex justify-content-left">
        <div class="col-md-3">
            <div class="border border-solid d-flex justify-content-center" >

                <div class="btn-group-vertical w-50 m-4 " role="group">
                    <input
                        type="radio"
                        class="btn-check"
                        name="btnradio"
                        id="btnradio1"
                        autocomplete="off"
                        checked
                    />
                    <label class="btn btn-outline-primary" for="btnradio1">Join Squad</label>
    
                    <input
                        type="radio"
                        class="btn-check"
                        name="btnradio"
                        id="btnradio2"
                        autocomplete="off"
                    />
                    <label class="btn btn-outline-primary" for="btnradio2">Missions</label>
    
                    <input
                        type="radio"
                        class="btn-check"
                        name="btnradio"
                        id="btnradio2"
                        autocomplete="off"
                    />
                    <label class="btn btn-outline-primary" for="btnradio2">Bite List</label>
    
                    <input
                        type="radio"
                        class="btn-check"
                        name="btnradio"
                        id="btnradio2"
                        autocomplete="off"
                    />
                    <label class="btn btn-outline-primary" for="btnradio2">Chat</label>
                </div>
            </div>
        </div>
        <div class="col-md-9 border">
            <GameSquad />
        </div>
    </div>
</template>




<style>
.ml-1{
    margin-left: .25rem !important;
}
</style>

