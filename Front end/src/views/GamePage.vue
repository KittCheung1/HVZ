<script setup>
import { HOME_ROUTE } from '../router'
</script>

<template>
  <div>
    <h1>Game Page</h1>
    <router-link :to='{ name: HOME_ROUTE }'>
      Home
    </router-link>
  </div>
</template>

<style></style>