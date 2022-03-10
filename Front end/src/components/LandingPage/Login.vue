<script setup>
import { useRouter } from "vue-router";
const router = useRouter()

function onclick(){

    router.push("game")
}

</script>

<template>
    <div class="Title Login">
        <h1>Login</h1>
        <div class="m-5">
            <div class="m-5">
                <div class="border border-solid border-dark">
                    <form class>
                        <fieldset class=" border-2 border-solid border-slate-500">
                            <div class="m-4">
                                <label for="username" class="block p-3">Username: </label>
                                <input
                                    type="text"
                                    id="username"
                                    placeholder="Username"
                                    class="border border-slate-800"
                                    v-model="username"
                                />
                            </div>
                            <div class="m-4">
                                <label for="password" class="block p-3">Password: </label>
                                <input
                                    type="text"
                                    id="password"
                                    placeholder="Password"
                                    class="border border-slate-800"
                                    v-model="username"
                                />
                            </div>
                        </fieldset>
                    </form>
                <div class=" mb-4 d-flex justify-content-center">
                    <button type="button" class="btn btn-primary m-3">Login</button>
                    <button type="button" class="btn btn-primary m-3">Register</button>
                </div>
                <button type="button" @click="onclick()" class="btn btn-secondary m-3"> Game Page</button>
                </div>
            </div>
        </div>
    </div>
</template>

<style>
</style>