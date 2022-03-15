import { createStore } from 'vuex'
import axios from 'axios'

let URL = 'http://apitest.northeurope.azurecontainer.io/'
// let urlPlayers =`${URL}game/ ${id}/player`

const store = createStore({
	state:{
		selectedGame: {},
		allGames: [],
		selectedPlayer: {},
		allPlayers: [],
		selectedMission: {},
		allMissions : [],
		selectedKill: {},
		allKills: [],
		selectedSquad: {},
		allSquads: []
	},
	getters:{
		getSelectedGame: state => state.selectedGame,
		getAllGames: state => state.allGames,
		getSelectedPlayer: state => state.selectedPlayer,
		getAllPlayers: state => state.allPlayers,
		getSelectedMission: state => state.selectedMission,
		getAllMissions: state => state.allMissions,
		getSelectedKill: state => state.selectedKill,
		getAllKills: state => state.allKills,
		getSelectedSquad: state => state.selectedSquad,
		getAllSquads: state => state.allSquads
	},
	mutations:{
		setCurrentGame (state, payload) {state.selectedGame = payload},
		setAllGames (state, payload) { state.allGames = payload },
		setSelectedPlayer (state, payload) {state.selectedPlayer = payload},
		setAllPlayers (state, payload) {state.allPlayers = payload},
		setSelectedMission (state, payload) {state.selectedMission = payload},
		setAllMissions (state, payload) {state.allMissions = payload},
		setSelectedKill (state, payload) {state.selectedKill = payload},
		setAllKills (state, payload) {state.allKills = payload},
		setSelectedSquad (state, payload) {state.selectedSquad = payload},
		setAllSquad (state, payload) {state.allSquads = payload}
	},
	actions:{
        getAllGames({ commit }){
            axios(`${URL}game/`).then(response => {
                commit('setAllGames', response.data)
            })
        },
		getAllPlayers({ commit }, {id}){
            axios.get(`${URL}game/${id}/player`).then(response => {
                commit('setAllPlayers', response.data)
            })
        },
		getAllSquads({ commit }, {id}){
            axios.get(`${URL}game/${id}/squad`).then(response => {
                commit('setAllSquad', response.data)
            })
        },
		getSelectedGame({ commit }, {id}){
            axios.get(`${URL}game/${id}`).then(response => {
                commit('setCurrentGame', response.data)
            })
        },

	}
})

export default store