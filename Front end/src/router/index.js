import { createRouter, createWebHistory } from 'vue-router'
import LandingPage from '../views/LandingPage.vue'
import GamePage from '../views/GamePage.vue'
// import Administrator from '../views/Administrator.vue'

export default createRouter({
	history: createWebHistory(),
	routes: [
		{
			path: '/',
			name: 'home',
			component: LandingPage,
		},
		{
			path: '/game',
			name: 'game',
			component: GamePage,
		},
		// {
		// 	path: '/admin',
		// 	name: 'admin',
		// 	component: Administrator,
		// },
	],
})
