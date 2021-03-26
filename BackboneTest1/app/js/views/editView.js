let EditView = Backbone.View.extend({
	tagName: 'div',
	className: 'container',
	model: Comment,
	template: _.template( $(config.templates.edit).html() ),
	events: {
		['click ' + config.saveCommentButton]: 'saveComment'
	},
	bindings: {
		'#name': 'name',
		'#website': 'website',
		'#email': 'email',
		'#content': 'content'
	},
	saveComment: function(event) {
		var errors = this.model.validate();
		if (errors) {
			var msg = Object.values(errors).join('<br/>');
			M.toast({ html: msg, classes: 'red lighten-3 white-text bold'});
		} else {
			this.submit();
		}
	},
	submit: function() {
		this.model.save();

		// Hasta ahora siempre se asume que se ha podido hacer el update.
		// El endpoint devuelve 204 [No content] Entonces los métodos 'success' y 'error' no se disparan.
		M.toast({ html: 'El Comentario ha sido actualizado correctamente.', classes: 'rounded' });
	},
	render: function() {
		Backbone.Validation.bind(this);

		this.$el.html(
			this.template(this.model.toJSON())
		);
		this.stickit();
		return this;
	}
});