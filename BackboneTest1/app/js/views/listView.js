let ListView = Backbone.View.extend({

	tagName: 'div',
	className: 'container',

	events: {
		['keyup ' + config.searchBar]: 'filterComments'
	},

	filterComments: function(event) {
		if ((event.keyCode == 13 || event.which == 13)) {
			var route = event.target.value ? 
				config.routes.filteredList.replace(':txt', event.target.value)
				: '';

			Backbone.history.navigate(route, { trigger: true });
		}
	},

	initialize: function (attrs) {
		this.options = attrs;
		
		// Fix this!
		this.searchText = Object.values(this.options)[1];

		this.listenTo(this.collection, 'success-fetch', this.render);
		return this;
	},

	createTableHead: function() {
		var thead = $('<thead>');
		var tr = $('<tr>');
		tr.append(
			$('<th>').text('Nombre'),
			$('<th>').text('Email'),
			$('<th>').text('Website'),
			$('<th>').text('Acción'),
		);

		thead.append(tr);

		return thead;
	},

	createSearchBar: function() {
		var container = $('<div>').addClass('center-align');

		var addBtn = $('<a href="#/' + config.routes.create + '">').addClass('btn grey darken-2');
		addBtn.text('Agregar Comentario');

		var div = $('<div>').addClass('input-field');
		var id = config.searchBar.substring(1);
		var input = $('<input type=text id=' + id + ' value="' + (this.searchText || '') + '">');
		var label = $('<label for=searchComments>');
		div.append(input).append(label);

		container.append(addBtn).append(div);

		return container;
	},

	containsSearchText: function(model) {
		if(!this.searchText) return true;
		var m = model.toJSON();
		return [m.name, m.email, m.website, m.content]
			.filter(p => p)
			.some(p => p.toLowerCase().includes(this.searchText.toLowerCase()));
	},

	render: function () {
		var tbody = $('<tbody>');
		this.collection.models
			.filter(model => this.containsSearchText(model))
			.forEach(model => {
				tbody.append(
					new CommentView({ 
						model: model 
					}).render().el
				);
			});

		var table = $('<table class=striped>');
		table
			.append(this.createTableHead())
			.append(tbody);

		var div = $('<div>');
		div.append(this.createSearchBar())
			.append(table);

		this.$el.html(div.html());

		return this;
	}
});