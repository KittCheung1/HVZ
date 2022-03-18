<script setup>
</script>

<template>
    <div class="border m-2">
        <h3 class="d-flex justify-content-center m-3">Edit Squad</h3>
        <form class>
            <fieldset class="border-2 border-solid border-slate-500">
                <div class="m-4">
                    <label for="squadName" class="block p-3">Squad Name:</label>
                    <input
                        id="squadName"
                        v-model="squadName"
                        type="text"
                        placeholder="Squad Name"
                        class="border border-slate-800"
                    />
                </div>

                <div class="m-4">
                    <label for="is_human" class="block p-3">Type:</label>
                    <select v-model="ishuman">
                        <option disabled value>Please select one</option>
                        <option :value="true">Human</option>
                        <option :value="false">Zombie</option>
                    </select>
                </div>
            </fieldset>
        </form>
        <button class="m-3 ">Save Changes</button>
    </div>
</template>

<style scoped>
.input{
    width: 70px;
}
</style>