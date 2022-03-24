import { createStore, Store } from 'vuex'
import axios from 'axios'
import { reactive,ref } from 'vue'

let URL = 'http://hvzapi.northeurope.azurecontainer.io/'

const store = createStore({
	state:{
		selectedGame: ref({}),
		allGames: reactive([]),
		selectedPlayer: {},
		allPlayers: reactive([]),
		selectedMission: {},
		allMissions : reactive([]),
		selectedKill: {},
		allKills: reactive([]),
		selectedSquad: {},
		allSquads: reactive([]),
		selectedChat: {},
		allChats: reactive([]),
		currentGameId: 1,
		currentMissionId: 1,
		currentUserId: 4,
		currentPlayerId: 0,
		currentBiteCode: '',
		currentVictimId: 1,
		allSquadmembers: reactive([]) 	,
		selectedSquadmember: {},
		selectedSquadId: 0,
		selectedGameState: '',
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
		getCurrentMissionId: state=> state.currentMissionId,
		getCurrentUserId: state => state.currentUserId,
		getCurrentPlayerId: state => state.currentPlayerId,
		getCurrentBiteCode: state => state.currentBiteCode,
		getCurrentVictimId: state => state.currentVictimId,
		getAllSquadmembers: state => state.allSquadmembers,
		getCurrentSquadmember: state => state.selectedChat,
		getCurrentSquadId: state => state.selectedSquadId,
		getAllSquadmembersInGame: state => state.allSquadmembersInGame
	
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
		setCurrentMissionId (state,payload) {state.currentMissionId = payload},
		setCurrentUserId (state,payload) {state.currentUserId = payload},
		setCurrentPlayerId (state,payload) {state.currentPlayerId = payload},
		setCurrentBiteCode (state,payload) {state.currentBiteCode = payload},
		setCurrentVictimId (state,payload) {state.currentVictimId = payload},
		setAllSquadmembers (state,payload) {state.allSquadmembers = payload},
		setSelectedSquadId (state,payload) {state.selectedSquadId = payload},
		setAllSquadmembersInGame (state,payload) {state.allSquadmembersInGame = payload}

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
		getMission({commit}, {gameId, id}){
			axios.get(URL+'game/'+gameId+'/mission/'+id).then(response =>{
				commit('setSelectedMission',response.data)
				commit('setCurrentMissionId',response.data.id)
				console.log(response.data)
				console.log(store.getters.getCurrentMissionId)
			})
		},
		getAllPlayers({commit}, {gameId}){
			axios.get(URL+'game/'+gameId+'/player').then(response =>{
				commit('setAllPlayers',response.data)
				console.log(response.data)
			})
		},
		makeid({commit},{length}) {
			var result           = ''
			var characters       = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789'
			var charactersLength = characters.length
			for ( var i = 0; i < length; i++ ) {
				result += characters.charAt(Math.floor(Math.random() * 
		 charactersLength))
			}
			 commit('setCurrentBiteCode',result)
		},
		getAllPlayersAndCheck({commit}, {gameId}){
			axios.get(URL+'game/'+gameId+'/player').then(response =>{
				commit('setAllPlayers',response.data)
				console.log(response.data)
				for(let i = 0; i < store.getters.getAllPlayers.length; i++){
					if(store.getters.getCurrentUserId === store.getters.getAllPlayers[i].userId){
						console.log('id: '+store.getters.getAllPlayers[i].userId)
						store.commit('setSelectedPlayer',store.getters.getAllPlayers[i])
						store.commit('setCurrentPlayerId',store.getters.getAllPlayers[i].id)
						console.log(store.getters.getSelectedPlayer)
						return
					} 
				}
				let player = {
					userId: store.getters.getCurrentUserId,
					is_Human: true,
					is_Patient_Zero: false,
					bite_Code: store.getters.getCurrentBiteCode
				}
				console.log('created a new player')
				store.dispatch('postPlayer',player)
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
		getAllSquadmembers({commit}, {gameId,squadId}){
			axios.get(URL+'game/'+gameId+'/squad/'+squadId+'/squadmember').then(response =>{
				commit('setAllSquadmembers',response.data)
				console.log(response.data)
				return(response.data)
			})

		},
		postGame({commit}, {Name, GameState, Nw_Lat, Nw_Lng, Se_Lat, Se_Lng}){
			axios.post(URL+'game/', {
				Name:Name,
				Game_state:parseInt(GameState),
				Nw_Lat:Nw_Lat,
				Nw_Lng:Nw_Lng,
				Se_Lat:Se_Lat,
				Se_Lng:Se_Lng
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
		postMission({commit}, {name, is_Human_Visible, is_Zombie_Visible, description, start_time, end_time}){
			axios.post(URL+'game/'+ store.getters.getCurrentGameId +'/mission', {
				name:name,
				is_Human_Visible:is_Human_Visible,
				is_Zombie_Visible:is_Zombie_Visible,
				description:description,
				start_time:start_time,
				end_time:end_time
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
		postPlayer({commit},{userId,is_Human,is_Patient_Zero,bite_Code}){
			axios.post(URL+'game/'+store.getters.getCurrentGameId+'/player', {
				userId: userId, 
				is_Human: is_Human, 
				is_Patient_Zero: is_Patient_Zero,
				bite_Code: bite_Code
			})
				.then(response => { 
					console.log(response)
					store.commit('setSelectedPlayer',response)
					store.commit('setCurrentPlayerId',response.id)
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
					store.dispatch('getAllSquads',{gameId:store.getters.getCurrentGameId})
				})
				.catch((error) => {
					if( error.response ){
						console.log(error.response.data) 
					}
				})
		},
		postKill({commit}, {KillerId,VictimId,Time_Of_Death,Story,Lat,Lng} ){
			axios.post(URL+'game/'+store.getters.getCurrentGameId+'/kill', {
				KillerId:KillerId,
				VictimId:VictimId,
				Time_Of_Death:Time_Of_Death,
				Story:Story,
				Lat:Lat,
				Lng:Lng
			})
				.then(response => { 
					console.log(response)
					commit('setCurrentVictimId',response.VictimId)
					setTimeout(function() { store.dispatch('getAllPlayers',{gameId:store.getters.getCurrentGameId}) }, 100)
					changedUser = {
						userId: VictimId, 
						is_Human: false, 
						is_Patient_Zero: false,
						bite_Code: '123'
					}
					
					
				})
				.catch((error) => {
					if( error.response ){
						console.log(error.response.data) 
					}
				})
		},
		PutPlayerToZombie({commit},{userId,is_Human,is_Patient_Zero,bite_Code}){
			axios.put(URL+'game/'+store.getters.getCurrentGameId+'/player/', {
				userId: userId, 
				is_Human: false, 
				is_Patient_Zero: false,
				bite_Code: bite_Code
			})
				.then(response => { 
					console.log(response)
					setTimeout(function() { store.dispatch('getAllKills',{gameId:store.getters.getCurrentGameId}) }, 100)
					
				})
				.catch((error) => {
					if( error.response ){
						console.log(error.response.data) 
					}
				})

		},
		postSquadmember({commit},{PlayerId,Rank}){
			axios.post(URL+'game/'+store.getters.getCurrentGameId+'/squad/'+store.getters.getCurrentSquadId+'/squadmember', {
				PlayerId:PlayerId,
				Rank:Rank
			})
				.then(response => { 
					console.log(response)
					store.dispatch('getAllSquadmembersInGame',{gameId:store.getters.getCurrentGameId})
				})
				.catch((error) => {
					if( error.response ){
						console.log(error.response.data) 
					}
				})

		},
		PostSquadmemberIfNotFound({commit}, {SquadId, Rank}){
			axios.get(URL+'game/'+store.getters.getCurrentGameId+'/squad/'+SquadId+'/squadmember').then(response =>{
				commit('setAllSquadmembers',response.data)
				console.log(response.data)
				for(let i = 0; i < store.getters.getAllSquadmembers.length; i++){
					if(store.getters.getCurrentPlayerId === store.getters.getAllSquadmembers[i].playerId){
						console.log('id: '+store.getters.getAllSquadmembers[i].playerId)
						console.log(store.getters.getSelectedPlayer)
						commit('setSelectedSquadId',response.id)
						return
					} 
				}
				let squadmember = {
					PlayerId:store.getters.getCurrentPlayerId,
					Rank:Rank
				}
				
				console.log('created a new squadmember')
				console.log(squadmember)
				//store.dispatch('postPlayer', player)
				store.dispatch('postSquadmember',squadmember)
			}).catch((error) =>{
				if( error.response ){
					console.log(error.response.data) 
				}
			})
		},
		PutGame({commit},{name,game_state,nw_lat,nw_lng,se_lat,se_lng}){
			axios.put(URL+'game/'+store.getters.getCurrentGameId, {
				name:name,
				game_state:game_state,
				nw_lat:nw_lat,
				nw_lng:nw_lng,
				se_lat:se_lat,
				se_lng:se_lng
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
		PutMission({commit}, {name, is_Human_Visible, is_Zombie_Visible, description, start_time, end_time}){
			axios.put(URL+'game/'+ store.getters.getCurrentGameId +'/mission/'+store.getters.getCurrentMissionId, {
				Name:name,
				is_Human_Visible:is_Human_Visible,
				is_Zombie_Visible:is_Zombie_Visible,
				description:description,
				start_time:start_time,
				end_time:end_time
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
		PutPlayerToZombie({commit},{userId,is_Human,is_Patient_Zero,bite_Code}){
			axios.put(URL+'game/'+store.getters.getCurrentGameId+'/player/', {
				userId: userId, 
				is_Human: false, 
				is_Patient_Zero: false,
				bite_Code: bite_Code
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