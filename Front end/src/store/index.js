import { createStore } from "vuex";

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
        setAllGames (state, payload) {state.allGames = payload},
        setSelectedPlayer (state, payload) {state.selectedPlayer = payload},
        setAllPlayers (state, payload) {state.allPlayers = payload},
        setSelectedMission (state, payload) {state.selectedMission = payload},
        setAllMissions (state, payload) {state.allMissions = payload},
        setSelectedKill (state, payload) {state.selectedKill = payload},
        setAllKills (state, payload) {state.allKills = payload},
        setSelectedSquad (state, payload) {state.selectedSquad = payload},
        setAllSquad (state, payload) {state.selectedSquad = payload}
    },
    actions:{

    }
});

export default store;