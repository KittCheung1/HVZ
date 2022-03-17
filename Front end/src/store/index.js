import { createStore } from 'vuex'
import axios from 'axios'

let URL = 'http://hvzapi.westeurope.azurecontainer.io/'

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
		allSquads: [],
		selectedChat: {},
		allChats: [],
		currentGameId: 0,
		currentUserId: 1,
		currentPlayerId: 1,

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
		getAllSquads: state => state.allSquads,
		getAllChats: state => state.allChats,
		getCurrentGameId: state => state.currentGameId,
		getCurrentUserId: state => state.currentUserId,
		getCurrentPlayerId: state => state.currentPlayerId,
	
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
		setAllSquads (state, payload) {state.allSquads = payload},
		setAllChats (state,payload) {state.allChats = payload},
		setCurrentGameId (state,payload) {state.currentGameId = payload},
		setCurrentUserId (state,payload) {state.currentUserId = payload},
		setCurrentPlayerId (state,payload) {state.currentPlayerId = payload},

	},
	actions:{
		getAllGames({ commit }){
			axios(URL+'game/').then(response => {
				commit('setAllGames', response.data)
			})
		},
		getGame({commit}, {gameId}){
			axios.get(URL+'game/'+gameId).then(response =>{
				commit('setSelectedGame',response.data)
				commit('setCurrentGameId',response.data.id)
				console.log(response.data)
				console.log(store.getters.getCurrentGameId)
			})
		},
		getAllPlayers({commit}, {gameId}){
			axios.get(URL+'game/'+gameId+'/player').then(response =>{
				commit('setAllPlayers',response.data)
				console.log(response.data)
			})
		},
		getAllMissions({commit}, {gameId}){
			axios.get(URL+'game/'+gameId+'/mission').then(response =>{
				commit('setAllMissions',response.data)
				console.log(response.data)
			})
		},
		getAllSquads({commit}, {gameId}){
			axios.get(URL+'game/'+gameId+'/squad').then(response =>{
				commit('setAllSquads',response.data)
				console.log(response.data)
			})
		},
		getAllChats({commit}, {gameId}){
			axios.get(URL+'game/'+gameId+'/chat').then(response =>{
				commit('setAllChats',response.data)
				console.log(response.data)
			})
		},
		getAllKills({commit}, {gameId}){
			axios.get(URL+'game/'+gameId+'/kill').then(response =>{
				commit('setAllKills',response.data)
				console.log(response.data)
			})
		},
		postPlayer(){
			axios.post(URL+'game/'+store.getters.getCurrentGameId+'/player', {
				userId: 1, 
				is_Human: 1, 
				is_Patient_Zero: 0,
				bite_Code: 'dsadsad1'
			})
				.then(response => { 
					console.log(response)
				})
				.catch((error) => {
					if( error.response ){
						console.log(error.response.data) 
					}
				})
		},
		postSquad({commit}, {Name, IsHuman}){
			axios.post(URL+'game/'+store.getters.getCurrentGameId+'/squad', {
				Name:Name,
				IsHuman:IsHuman
			})
				.then(response => { 
					console.log(response)
				})
				.catch((error) => {
					if( error.response ){
						console.log(error.response.data) 
					}
				})
		},
	}
})

export default store