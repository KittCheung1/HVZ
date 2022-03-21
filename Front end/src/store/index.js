import { createStore } from 'vuex'
import axios from 'axios'

let URL = 'http://apitest.northeurope.azurecontainer.io/'

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
		setSelectedGame (state, payload) {state.selectedGame = payload},
		setAllGames (state, payload) { state.allGames = payload },
		setSelectedPlayer (state, payload) {state.selectedPlayer = payload},
		setAllPlayers (state, payload) {state.allPlayers = payload},
		setSelectedMission (state, payload) {state.selectedMission = payload},
		setAllMissions (state, payload) {state.allMissions = payload},
		setSelectedKill (state, payload) {state.selectedKill = payload},
		setAllKills (state, payload) {state.allKills = payload},
		setSelectedSquad (state, payload) {state.selectedSquad = payload},
		setAllSquads (state, payload) {state.allSquads = payload}
	},
	actions:{
        getAllGames({ commit }){
            axios.get(URL+'game/').then(response => {
                commit('setAllGames', response.data)
            })
        },
        getGame({ commit }, {gameId}){
            axios.get(URL+'game/'+gameId).then(response => {
                commit('setSelectedGame', response.data)
            })
        },
        getAllPlayers({ commit }, {gameId}){
            axios.get(URL+'game/'+gameId+'/player').then(response => {
                commit('setAllPlayers', response.data)
                console.log('reponse: ', response.data)
                console.log('allPlayers: ', store.getters.getAllPlayers)
            })
        },
        getPlayer({ commit }, {gameId, playerId}){
            axios.get(URL+'game/'+gameId+'/player/'+playerId).then(response => {
                commit('setSelectedPlayer', response.data)
                console.log('response: ', response.data)
                console.log('selectedPlayer: ', store.getters.getSelectedPlayer)
            })
        },
        getAllMissions({ commit }, {gameId}){
            axios.get(URL+'game/'+gameId+'/mission').then(response =>{
                commit('setAllMissions', response.data)
                console.log('response: ', response.data)
                console.log('allMissions: ', store.getters.getAllMissions)
            })
        },
        getMission({ commit }, {gameId, missionId}){
            axios.get(URL+'game/'+gameId+'/mission/'+missionId).then(response => {
                commit('setSelectedMission', response.data)
                console.log('response: ', response.data)
                console.log('selectedMission: ', store.getters.getSelectedMission)
            })
        },
        getAllKills({ commit }, {gameId}){
            axios.get(URL+'game/'+gameId+'/kill').then(response =>{
                commit('setAllKills', response.data)
                console.log('response: ', response.data)
                console.log('allKills: ', store.getters.getAllKills)
            })
        },
        getKill({ commit }, {gameId, killId}){
            axios.get(URL+'game/'+gameId+'/kill/'+killId).then(response => {
                commit('setSelectedKill', response.data)
                console.log('response: ', response.data)
                console.log('selectedKill: ', store.getters.getSelectedKill)
            })
        },
        getAllSquads({ commit }, {gameId}){
            axios.get(URL+'game/'+gameId+'/squad').then(response =>{
                commit('setAllSquads', response.data)
                console.log('response: ', response.data)
                console.log('allSquads: ', store.getters.getAllSquads)
            })
        },
        getSquad({ commit }, {gameId, squadId}){
            axios.get(URL+'game/'+gameId+'/squad/'+squadId).then(response => {
                commit('setSelectedSquad', response.data)
                console.log('response: ', response.data)
                console.log('selectedSquad: ', store.getters.getSelectedSquad)
            })
        },
        postPlayer({ userId, is_Human, is_Patient_Zero, bite_Code}){
            axios.post(URL+'game/1', {
                userId: userId,
                is_Human: is_Human,
                is_Patient_Zero: is_Patient_Zero,
                bite_Code: bite_Code
    }).then((response) => {console.log(response);});
        }

	}
})

export default store