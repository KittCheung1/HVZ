<script setup>
import { HOME_ROUTE } from '../router'
</script>

<template>
  <h1>Admin page</h1>

  <div>
    <router-link
      class='nav-link'
      :to='{ name: HOME_ROUTE }'
    >
      Home
    </router-link>
  </div>
</template>

<style>
.nav-link {
  text-decoration: none;
  color: inherit;
}
</style>
