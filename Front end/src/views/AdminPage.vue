<script setup>
import AdminDashboard from '../components/Administrator/AdminDashboard.vue';

</script>

<template>
  <div>
    <div>
      <h1 class="d-flex justify-content-center">Admin page</h1>
      <div class="m-5">
        <AdminDashboard />
      </div>
      <router-link class="nav-link" to="/">home</router-link>
    </div>
  </div>
</template>

<style>
.nav-link {
  text-decoration: none;
  color: inherit;
}
</style>
