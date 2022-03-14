module.exports = {
	'env': {
		'browser': true,
		'es2021': true,
		'node': 1
	}, 
	'extends': [
		'plugin:vue/vue3-recommended',
	],
	'parserOptions': {
		'ecmaVersion': 'latest',
		'sourceType': 'module'
	},
	'plugins': [
		'vue'
	],
	'rules': {
		'no-mixed-spaces-and-tabs': 'off',
		'vue/comment-directive': 0,
		'indent': [
			'error',
			'tab',
		],
		'linebreak-style': [
			'error',
			'windows'
		],
		'quotes': [
			2,
			'single',
		],
		'vue/html-quotes': [ 
			'error', 'single', { 'avoidEscape': false } 
		],
		'semi': [
			'error',
			'never'
		],
	}
}
