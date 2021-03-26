let AppRouter = Backbone.Router.extend({
	routes: {
		'': 'listRoute',
		[config.routes.list]: 'listRoute',
		[config.routes.filteredList]: 'filteredListRoute',
		[config.routes.create]: 'createRoute',
		[config.routes.edit]: 'editRoute'
	},

	listRoute: function() {
		this.listView = new ListView({
			collection: new CommentCollection()
		});
		this.setContent('Listado de Comentarios', this.listView.render().el);
	},

	filteredListRoute: function(txt) {
		this.listView = new ListView({
			collection: new CommentCollection(),
			searchTxt: txt
		});
		this.setContent('Listado de Comentarios', this.listView.render().el);
	},

	createRoute: function() {
		this.createView = new CreateView({ model: new Comment() });
		this.setContent('Creación de Comentarios', this.createView.render().el);
	},

	editRoute: async function(id) {
		var m = new Comment({ id: id });
		await m.fetch();
		this.editView = new EditView({ model: m });
		this.setContent('Edición de Comentarios', this.editView.render().el);
	},

	setContent: function(title, el) {
		$(config.nav_title).text(title);
		$(config.content).html(el);
	}
});

let appRouter = new AppRouter();
Backbone.history.start();