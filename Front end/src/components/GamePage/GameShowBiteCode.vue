
<script setup>
import { onMounted, reactive, ref } from 'vue'
import { useRouter } from 'vue-router'
import store from '../../store'
    
let currentPlayer = store.getters.getSelectedPlayer

let isHidden = ref(true)



</script>

<template>
  <div>
    <button @click='isHidden = !isHidden'>
      Show my bite-code
    </button>
  </div>

  <div v-if='!isHidden'>
    <p>{{ currentPlayer.bite_Code }}</p>
  </div>
</template>