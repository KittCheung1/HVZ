<script setup>
import leaflet from 'leaflet'
import { onMounted,ref, reactive } from 'vue'
import store from '../../store'



console.log('lat: '+store.getters.getSelectedGame.se_lat)
onMounted(() => {
  	store.dispatch('getAllKills',{gameId:store.getters.getCurrentGameId})
	let lat = (store.getters.getSelectedGame.se_lat+store.getters.getSelectedGame.nw_lat)/2
	let lng = (store.getters.getSelectedGame.se_lng+store.getters.getSelectedGame.nw_lng)/2
      	let map = reactive(leaflet.map('map').setView([lat , lng], 15))

	leaflet.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token=pk.eyJ1Ijoia2x1dGNoYXJuIiwiYSI6ImNsMTBsbm1xeDBlNnIzam14c214NDdxMXYifQ.dWfpaIeSZEXKSHAE05ZM-Q', {
		attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
		maxZoom: 18,
		id: 'mapbox/streets-v11',
		tileSize: 512,
		zoomOffset: -1,
		accessToken: 'pk.eyJ1Ijoia2x1dGNoYXJuIiwiYSI6ImNsMTBsbm1xeDBlNnIzam14c214NDdxMXYifQ.dWfpaIeSZEXKSHAE05ZM-Q'
	}).addTo(map)

	let polygon = L.polygon([
		[store.getters.getSelectedGame.nw_lat, store.getters.getSelectedGame.nw_lng],
		[store.getters.getSelectedGame.nw_lat, store.getters.getSelectedGame.se_lng],
		[store.getters.getSelectedGame.se_lat, store.getters.getSelectedGame.se_lng], 
		[store.getters.getSelectedGame.se_lat, store.getters.getSelectedGame.nw_lng],

	], {color: 'green', opacity: 0.3, stroke: true}).addTo(map)

	for (var i in store.getters.getAllKills) {
		var row = store.getters.getAllKills[i]

		const marker = L.circleMarker([row.lat, row.lng], {
			color: 'red',
			radius: 5
		})
			.addTo(map)
	}
	

})

		
</script>

<template>
  <div class='text-center'>
    <h3>Map</h3>
    <div id='map' />
  </div>
</template>


<style scoped>
#map { height: 420px; }
</style>