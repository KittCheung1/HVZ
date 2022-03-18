<script setup>
</script>

<template>
      <div class="border m-2">
        <h3 class="d-flex justify-content-center m-3">Edit a Kill</h3>
        <form class>
            <fieldset class="border-2 border-solid border-slate-500">
                <div class="m-2">
                    <label for="killerId" class="block p-3">Killer Id:</label>
                    <input
                        id="killerId"
                        v-model="killerId"
                        type="text"
                        placeholder="Killer id"
                        class="border border-slate-800 input"
                        
                    />
                </div>
                <div class="m-2">
                    <label for="victimId" class="block p-3">Victim Id:</label>
                    <input
                        id="victimId"
                        v-model="victimId"
                        type="text"
                        placeholder="victimId"
                        class="border border-slate-800 input"
                    />
                </div>
                <div class="m-2">
                    <label for="tod" class="block p-3">Time of Death:</label>
                    <input
                        id="tod"
                        v-model="tod"
                        type="time"
                        placeholder="tod"
                        class="border border-slate-800"
                    />
                </div>
                <div class="m-4">
                    <textarea
                        id="kill_description"
                        v-model="kill_description"
                        type="textarea"
                        placeholder="Story Description"
                        class="border border-slate-800"
                        rows="4"
                        cols="33"
                    ></textarea>
                </div>
                <div class="m-2 coordinates">
                    <label for="Lat" class="block p-3">Coordinates:</label>
                    <input
                        id="Lat"
                        v-model="Lat"
                        type="text"
                        placeholder="Lat"
                        class="border border-slate-800 m-2 input "
                    />
                    <input
                        id="Lng"
                        v-model="Lng"
                        type="text"
                        placeholder="Lng"
                        class="border border-slate-800 m-2 input"
                    />
                </div>
            </fieldset>
        </form>
        <button class="m-3">Save Changes</button>
    </div>
</template>

<style scoped>
.input{
    width: 70px;
}
</style>