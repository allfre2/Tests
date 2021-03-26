let build = {
	src: 'app/',
	dest: 'build/',
	libs: 'node_modules/',
};

build.include = {
	require: build.libs + 'requirejs/require.js',
	materialize: {
		js: build.libs + 'materialize-css/dist/js/materialize.min.js',
		css: build.libs + 'materialize-css/dist/css/materialize.min.css',
		init: build.src + 'js/materialize/init.js'
	},
	jquery: build.libs + 'jquery/dist/jquery.min.js',
	underscore: build.libs + 'underscore/underscore-min.js',
	stickit: build.libs + 'backbone.stickit/backbone.stickit.js',
	validation: build.libs + 'backbone-validation/dist/backbone-validation-min.js',
	backbone: build.libs + 'backbone/backbone-min.js'
};

build.modules = [
	{
		name: 'comments',
		dir: build.src + 'js/modules/comments'
	}
];

build.views = {
	nav: build.src + 'js/views',
	routes: build.src + 'js/routes.js'
};

build.output = {
	js: 'main.js',
	css: 'main.css'
};

build.config = {
	file: './config.js'
};

exports.build = build;
