import { createRouter, createWebHistory } from "vue-router"
import LandingPage from "./views/LandingPage.vue"
import GamePage from "./views/GamePage.vue"
import Administrator from "./views/Administrator.vue"

const routes = [{
        path: "/",
        component: LandingPage,
        name: "LandingPage"
    },
    {
        path: "/landingpage/:game",
        component: LandingPage,
        name: "Game"
    },
    {
        path: "/game",
        component: GamePage,
        name: "GamePage"
    },
    {
        path: "/admin",
        component: Administrator,
        name: "Administrator"
    }

]

export default createRouter({
    history: createWebHistory(),
    routes
})