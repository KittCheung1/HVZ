
<script setup>
import { onMounted, reactive, ref } from 'vue'
import { useRouter } from 'vue-router'
import store from '../../store'
    
      
let name = ref('')
let isHuman = ref(false)

let obj = reactive({
	name: name,
	is_Human:isHuman,
})

function createSquad(){
	store.dispatch('postSquad',obj)

	console.log(obj)
}

let isHidden = ref(true)
</script>

<template>
  <div>
    <button @click='isHidden = !isHidden'>
      Create a squad
    </button>
  </div>

  <div v-if='!isHidden'>
    <p>Squad Name</p>
    <input
      v-model='obj.name'
      placeholder='Squad Name'
    >
    <p>Squad Type</p>
    <select v-model='obj.isHuman'>
      <option
        disabled
        value=''
      >
        Please select one
      </option>
      
      <option :value='true'>
        Human
      </option>
      <option :value='false'>
        Zombie
      </option>
    </select>
    <button @click='createSquad()'>
      Submit
    </button>
  </div>
</template>