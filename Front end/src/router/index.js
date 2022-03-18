import { createRouter, createWebHistory } from 'vue-router'
import LandingPage from '../views/LandingPage.vue'
import GamePage from '../views/GamePage.vue'
import AdminPage from '../views/AdminPage.vue'
import { initKeycloak } from '../keycloak'
import { BASE_URL } from '../options'

export const HOME_ROUTE = 'home'
export const GAME_ROUTE = 'game'
export const ADMIN_ROUTE = 'admin'
const protectedRoutes = new Set([GAME_ROUTE, ADMIN_ROUTE])

const router = createRouter({
	history: createWebHistory(),
	routes: [
		{
			path: '/',
			name: HOME_ROUTE,
			component: LandingPage,
		},
		{
			path:'/game',
			name: GAME_ROUTE,
			component: GamePage
		},
		{
			path:'/admin',
			name: ADMIN_ROUTE, 
			component: AdminPage
		}
	],
})

router.beforeEach(async (to, from, next) => {
	let hasCalledNext = false
	const yieldNext = () => {
		if(!hasCalledNext) {
			next()
			hasCalledNext = true
		}
	}
	if(to.name !== undefined && to.name !== null && protectedRoutes.has(to.name)) {
		await initKeycloak(buildUrl(to.path))
		yieldNext()
	}

	yieldNext()
})

export default router

function buildUrl(path) {
	return BASE_URL + path
}