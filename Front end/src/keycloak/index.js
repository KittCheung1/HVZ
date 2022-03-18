import Keycloak from 'keycloak-js'

const keycloakConf = {
	url: 'http://localhost:8080/', realm: 'myrealm', clientId: 'case', 
}

export function initKeycloak(pathTargetAfterLogin) {
	return keycloak.init({
		onLoad: 'login-required',
		redirectUri: pathTargetAfterLogin
	})
}

const keycloak = Keycloak(keycloakConf)
export default keycloak