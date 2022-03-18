<script setup>
import keycloak from '../keycloak/index'
import { BASE_URL } from '../options'

function logout(){
	keycloak.logout({
		redirectUri: BASE_URL
	})
}
</script>

<template>
  <div class='Title Login'>
    <div class='m-5'>
      <div class='m-5'>
        <h1>Login</h1>
        <div class='border border-solid border-dark'>
          <form class>
            <fieldset class='border-2 border-solid border-slate-500'>
              <div class='m-4'>
                <label for='username&quot; class=&quot;block p-3'>Username: </label>
                <input
                  id='username'
                  v-model='username'
                  type='text'
                  placeholder='Username'

                  class='border border-slate-800'
                >
              </div>
              <div class='m-4'>
                <label
                  for='password'
                  class='block p-3'
                >Password: </label>
                <input
                  id='password'
                  v-model='username'
                  type='password'
                  placeholder='Password'
                  class='border border-slate-800'
                >
              </div>
            </fieldset>
          </form>
          <div class='mb-4 d-flex justify-content-center'>
            <button
              type='button'
              class='btn btn-primary m-3'
              @click='login'
            >
              Login
            </button>
            <button
              type='button'
              class='btn btn-primary m-3'
              @click='logout'
            >
              Logout
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style>
</style>