
<script setup>
import { onMounted, reactive, ref } from 'vue'
import { useRouter } from 'vue-router'
import store from '../../store'
    
      

let namer = ref('')
let ishuman = ref(false)

let obj = reactive({
	Name: namer,
	IsHuman: ishuman
})


function createSquad(){
	store.dispatch('postSquad',obj)
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
      v-model='namer'
      placeholder='Squad Name'
    >
    <p>Squad Type</p>
    <select v-model='ishuman'>
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