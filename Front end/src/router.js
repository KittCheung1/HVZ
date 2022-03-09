import { createRouter, createWebHistory} from 'vue-router';
import LandingPage from './views/LandingPage.vue';
import GamePage from './views/GamePage.vue';
import Administrator from './views/Administrator.vue';

const routes = [
    {
        path: '/',
        component: LandingPage,
    },
    {
        path: '/gamepage',
        component: GamePage,
    },
    {
        path: '/admin',
        component: Administrator
    }
];

export default createRouter({
    history: createWebHistory(),
    routes,
});