import { createApp, provide } from 'vue'
import App from './App.vue'
import 'bootstrap/dist/css/bootstrap.css'
import store from './store/index'
import router from './router/index.js'

createApp(App)
	.use(store)
	.use(router)
	.mount('#app')



